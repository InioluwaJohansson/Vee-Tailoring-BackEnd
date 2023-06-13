using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;
using Vee_Tailoring.Emails;
using Vee_Tailoring.Payments;
using Mastercard.Developer.OAuth1Signer.Core.Utils;
using Mastercard.Developer.OAuth1Signer.Core;

namespace Vee_Tailoring.Implementations.Services;

public class PaymentService : IPaymentService
{
    IPaymentRepo _repository;
    IOrderService _orderService;
    ICustomerRepo _customerRepo;
    IOrderRepo _orderRepo;
    IEmailSend _email;
    ITokenService _tokenService;
    IDefaultPriceRepo _defaultPriceRepo;
    ICardRepo _cardRepo;
    IConfiguration _configuration;
    public PaymentService(IPaymentRepo repository, IOrderService orderService, ICustomerRepo customerRepo, IOrderRepo orderRepo, ITokenService tokenService, IDefaultPriceRepo defaultPriceRepo, IEmailSend email, ICardRepo cardRepo, IConfiguration configuration)
    {
        _repository = repository;
        _orderService = orderService;
        _customerRepo = customerRepo;
        _orderRepo = orderRepo;
        _email = email;
        _tokenService = tokenService;
        _defaultPriceRepo = defaultPriceRepo;
        _cardRepo = cardRepo;
        _configuration = configuration;
    }
    public async Task<BaseResponse> GenerateToken(int id)
    {
        var status = await _tokenService.GenerateToken(id, TokenType.Payment);
        if (status == true)
        {
            return new BaseResponse()
            {
                Message = "Token Generated Successfully!",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Generate Token!",
            Status = false
        };
    }
    public async Task<BaseResponse> MakePayment(int id, MakePaymentDto makePayment)
    {
        var customer = await _customerRepo.GetByUserId(id);
        if (customer != null)
        {
            var token = await _tokenService.CheckToken(id, TokenType.Payment, makePayment.Token);
            if (token == true)
            {
                var cart = await _orderService.GetCartOrdersByCustomerId(id);
                if (cart != null && customer != null)
                {
                    var generateRef = Guid.NewGuid().ToString().Substring(0, 15);
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage catchresponse = new HttpResponseMessage();
                    if (makePayment.paymentMethod == PaymentMethod.Paystack)
                    {
                        var url = "https://api.paystack.co/transaction/initialize";
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["EmailSettings:SendInBlueKey"]);
                        var content = new StringContent(JsonSerializer.Serialize(new
                        {
                            currency = "USD",
                            amount = cart.Data.TotalPrice,
                            email = customer.User.Email,
                            referenceNumber = generateRef

                        }), Encoding.UTF8, "application/json");
                        catchresponse = await client.PostAsync(url, content);
                        var reString = await catchresponse.Content.ReadAsStringAsync();
                        var responseObj = JsonSerializer.Deserialize<PaymentMethodsDto>(reString);
                    }
                    if (makePayment.paymentMethod == PaymentMethod.MasterCard)
                    {
                        var card = await _cardRepo.Get(x => x.Id == makePayment.CardId && x.UserId == id && x.IsDeleted == false);
                        if(card != null)
                        {
                            var url = "https://api.paystack.co/transaction/initialize";
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["PayPal:SecretKey"]);
                            // Set up your API credentials

                            // Configure the API credentials
                            /*

                            // Create a new checkout session
                            var checkoutSession = CheckoutApi.CreateSession(merchantId, new SessionRequest
                            {
                                ApiOperation = "CREATE_CHECKOUT_SESSION",
                                Order = new Order
                                {
                                    Amount = 1000,
                                    Currency = "USD",
                                    Reference = "YourOrderReference"
                                },
                                Interaction = new Interaction
                                {
                                    ReturnUrl = "https://your-website.com/checkout/complete"
                                }
                            });

                            // Access the session ID
                            var sessionId = checkoutSession.Session.Id;

                            
                            */
                            var signingKey = AuthenticationUtils.LoadSigningKey($"{_configuration["Mastercard:PCKS#12_Path"]}", $"{_configuration["Mastercard:Key_Alias"]}", $"{_configuration["Mastercard:Key_Password"]}");
                            var consumerKey = $"{_configuration["MasterCard:ClientId"]}";
                            var uri = "https://sandbox.api.mastercard.com/service";
                            var method = "POST";
                            var payload = "Hello world!";
                            var encoding = Encoding.UTF8;
                            var authHeader = OAuth.GetAuthorizationHeader(uri, method, payload, encoding, consumerKey, signingKey);
                            var baseUri = new Uri("https://api.mastercard.com/");
                            var httpClient = new HttpClient(new RequestSignerHandler(consumerKey, signingKey)) { BaseAddress = baseUri };
                            var postTask = httpClient.PostAsync(new Uri("/service", UriKind.Relative), new StringContent("{\"foo\":\"bår\"}"));

                            var content = new StringContent(JsonSerializer.Serialize(new
                            {
                                currency = "USD",
                                pin = card.CardPin,
                                validFrom = card.ValidTHRU,
                                cvv = card.CVV,
                                amount = cart.Data.TotalPrice,
                                email = customer.User.Email,
                                referenceNumber = generateRef
                            }), Encoding.UTF8, "application/json");
                            catchresponse = await client.PostAsync(url, content);
                            var reString = await catchresponse.Content.ReadAsStringAsync();
                            var responseObj = JsonSerializer.Deserialize<PaymentMethodsDto>(reString);
                        }
                        
                    }
                    if (catchresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var updateOrderPayment = new UpdateOrderPaymentCheck()
                        {
                            CustomerId = customer.Id,
                            Check = true,
                            ReferenceNo = generateRef
                        };
                        var pay = new Payment()
                        {
                            AmountPaid = cart.Data.TotalPrice,
                            ShippingFee = (await _defaultPriceRepo.GetShippingFees()).Price,
                            StoreTaxes = (await _defaultPriceRepo.GetStoreTaxes()).Price,
                            CustomerId = customer.Id,
                            ReferenceNumber = generateRef,
                            DateOfPayment = DateTime.UtcNow,
                            IsDeleted = false,
                        };
                        await _repository.Create(pay);
                        var updateOrder = await _orderService.UpdatePayment(updateOrderPayment);
                        if (updateOrder == true)
                        {
                            var payment = await _repository.Get(x => x.ReferenceNumber == generateRef && x.IsDeleted == false);
                            var order = await _orderRepo.GetByExpression(x => x.ReferenceNumber == generateRef);
                            var email = new CreateEmailDto()
                            {
                                Subject = "Order(s) Completed Successfully",
                                ReceiverName = $"{customer.UserDetails.LastName} {customer.UserDetails.FirstName}",
                                ReceiverEmail = customer.User.Email,
                                Message = $"Hi Thanks for shopping with us. /n" +
                                $"Check your order history to keep track of your Orders. /n" +
                                $"{GetOrderNos(order)} /n" + "Vee Tailoring"
                            };
                            await _email.SendEmail(email);
                            var adminEmail = new CreateEmailDto()
                            {
                                Subject = "Order(s) Payment Completed Successfully",
                                ReceiverName = $"Inioluwa Johansson",
                                ReceiverEmail = "inioluwa.makinde10@gmail.com",
                                Message = $"{customer.UserDetails.LastName} {customer.UserDetails.FirstName} shopped with Us. /n" +
                                $"You can use the following order numbers to keep track of the Orders /n" +
                                $"{(GetOrderNos(order))} /n" + "Vee Tailoring"
                            };
                            await _email.SendEmail(adminEmail);
                            return new BaseResponse()
                            {
                                Message = "Orders Payment Successful!",
                                Status = updateOrder
                            };
                        }
                    }
                    return new BaseResponse()
                    {
                        Message = "Unable To Make Orders Payment Due To Payment Gateway Error!",
                        Status = false
                    };
                }
                return new BaseResponse()
                {
                    Message = "Incorrect Password!",
                    Status = false
                };
            }
        }
        return new BaseResponse()
        {
            Message = "Incorrect Password!",
            Status = false
        };
    }
    public async Task<BaseResponse> VerifyPayment(string referenceNumber)
    {
        var payment = await _repository.Get(x => x.ReferenceNumber == referenceNumber && x.IsDeleted == false);
        if (payment != null)
        {
            return new BaseResponse
            {
                Message = "Order Payment Verified Successfully",
                Status = true
            };
        }
        return new BaseResponse
        {
            Message = "Failed To Verify Order Payment",
            Status = false
        };
    }
    public async Task<BaseResponse> VerifyPaymentByCustomer(int id, string referenceNumber)
    {
        var payment = await _repository.Get(x => x.ReferenceNumber == referenceNumber && x.CustomerId == id && x.IsDeleted == false);
        if (payment != null)
        {
            return new BaseResponse
            {
                Message = "Order Payment Verified Successfully",
                Status = true
            };
        }
        return new BaseResponse
        {
            Message = "Failed To Verify Order Payment",
            Status = false
        };
    }
    public async Task<PaymentResponse> GetPayment(int id)
    {
        var payment = await _repository.Get(x => x.Id == id && x.IsDeleted == false);
        if (payment != null)
        {
            var customer = await _customerRepo.GetById(payment.CustomerId);
            var order = await _orderRepo.ListAllOrdersByCustomerId(payment.CustomerId);
            return new PaymentResponse
            {
                Data = GetDetails(payment, customer, order),
                Message = "Order Payment Retrieved Successfully",
                Status = true
            };
        }
        return new PaymentResponse
        {
            Message = "Failed To Retrieve Order Payment",
            Status = false
        };
    }
    public async Task<PaymentsResponseModel> GetAllPaymentsByCustomer(int id)
    {
        var payments = await _repository.GetByExpression(x => x.Customer.User.Id == id && x.IsDeleted == false);
        if (payments != null)
        {
            List<GetPaymentDto> PaymentList = new List<GetPaymentDto>();
            foreach (var payment in payments)
            {
                var customer = await _customerRepo.GetById(payment.CustomerId);
                var order = await _orderRepo.ListAllOrdersByCustomerId(payment.CustomerId);
                PaymentList.Add(GetDetails(payment, customer, order));
            }
            return new PaymentsResponseModel()
            {
                Data = PaymentList,
                Message = "Orders Payments Found",
                Status = true
            };
        }
        return new PaymentsResponseModel()
        {
            Data = null,
            Message = "Unable To Retieve Payments Successfully",
            Status = true
        };
    }
    public async Task<PaymentsResponseModel> GetAllPaymentsByCustomerDateRange(int id, DateTime startDate, DateTime endDate)
    {
        var payments = await _repository.GetByExpression(x => x.Customer.User.Id == id && x.DateOfPayment >= startDate && x.DateOfPayment <= endDate && x.IsDeleted == false);
        if (payments != null)
        {
            List<GetPaymentDto> PaymentList = new List<GetPaymentDto>();
            foreach (var payment in payments)
            {
                var customer = await _customerRepo.GetById(payment.CustomerId);
                var order = await _orderRepo.ListAllOrdersByCustomerId(payment.CustomerId);
                PaymentList.Add(GetDetails(payment, customer, order));
            }
            return new PaymentsResponseModel()
            {
                Data = PaymentList,
                Message = "Orders Payments Found",
                Status = true
            };
        }
        return new PaymentsResponseModel()
        {
            Data = null,
            Message = "Unable To Retieve Payments Successfully",
            Status = true
        };
    }
    public async Task<PaymentsResponseModel> GetAllPayments()
    {
        var payments = await _repository.GetByExpression(x => x.IsDeleted == false);
        if (payments != null)
        {
            List<GetPaymentDto> PaymentList = new List<GetPaymentDto>();
            foreach (var payment in payments)
            {
                var customer = await _customerRepo.GetById(payment.CustomerId);
                var order = await _orderRepo.ListAllOrdersByCustomerId(payment.CustomerId);
                PaymentList.Add(GetDetails(payment,customer, order));
            }
            return new PaymentsResponseModel()
            {
                Data = PaymentList,
                Message = "Orders Payments Found",
                Status = true
            };
        }
        return new PaymentsResponseModel()
        {
            Data = null,
            Message = "Unable To Retieve Payments Successfully",
            Status = false
        };
    }
    public async Task<PaymentsResponseModel> GetAllPaymentsDateRange(DateTime startDate, DateTime endDate)
    {
        var payments = (await _repository.GetByExpression(x => x.DateOfPayment >= startDate && x.DateOfPayment <= endDate && x.IsDeleted == false)).OrderByDescending(x => x.DateOfPayment);
        if (payments != null)
        {
            List<GetPaymentDto> PaymentList = new List<GetPaymentDto>();
            foreach (var payment in payments)
            {
                var customer = await _customerRepo.GetById(payment.CustomerId);
                var order = await _orderRepo.ListAllOrdersByCustomerId(payment.CustomerId);
                PaymentList.Add(GetDetails(payment, customer, order));
            }
            return new PaymentsResponseModel()
            {
                Data = PaymentList,
                Message = "Orders Payments Found",
                Status = true
            };
        }
        return new PaymentsResponseModel()
        {
            Data = null,
            Message = "Unable To Retieve Payments Successfully",
            Status = false
        };
    }
    public async Task<InvoiceResponse> GenerateInvoice(int id)
    {
        var invoice = await _repository.GenerateInvoice(id);
        var getinvoice = await _repository.Get(c => c.Id == id);
        if (invoice != null)
        {
            string path = "", fileName = $"{getinvoice.ReferenceNumber}.html";
            FileStream openPdf = new FileStream("../Templates/pdfTemplate.html", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(openPdf);
            string fileContents = streamReader.ReadToEnd().ToString()
            .Replace("$REFNUMBER", $"{getinvoice.ReferenceNumber}")
            .Replace("$NAME", $"{getinvoice.Customer.UserDetails.FirstName} {getinvoice.Customer.UserDetails.LastName}")
            .Replace("$AMOUNT", $"{getinvoice.AmountPaid}")
            .Replace("SHIPPINGFEE", $"{getinvoice.ShippingFee}")
            .Replace("STORETAXES", $"{getinvoice.StoreTaxes}")
            .Replace("$EMAIL", $"{getinvoice.Customer.User.Email}")
            .Replace("$NUMBERLINE", $"{getinvoice.Customer.UserDetails.Address.NumberLine}, {getinvoice.Customer.UserDetails.Address.Street},")
            .Replace("$CITY", $"{getinvoice.Customer.UserDetails.Address.City},")
            .Replace("$REGION", $"{getinvoice.Customer.UserDetails.Address.Region},")
            .Replace("$STATE", $"{getinvoice.Customer.UserDetails.Address.State},")
            .Replace("$COUNTRY", $"{getinvoice.Customer.UserDetails.Address.Country}.")
            .Replace("$ITEMS", $"{InvoiceItems(invoice)}")
            ;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Invoices\\");
            if (Directory.Exists($"{folderPath}{fileName}"))
            {
                Directory.CreateDirectory(folderPath);
                path = Path.Combine(folderPath, fileName);
            }
            if(getinvoice.ReferenceNumber != null)
            {
                if (File.GetCreationTime(path) < File.GetCreationTime(path).AddMinutes(1.3)) File.Delete(path);

                if (File.Exists(path) == true || File.Exists(path) == false) await File.WriteAllTextAsync(path, fileContents);
            }
            var InvoiceOutput = new GetInvoiceDto()
            {
                ReferenceNo = getinvoice.ReferenceNumber,
                AmountPaid = getinvoice.AmountPaid,
                ShippingFee = getinvoice.ShippingFee,
                StoreTaxes = getinvoice.StoreTaxes,
                DateOfPayment = getinvoice.DateOfPayment,
                Email = getinvoice.Customer.User.Email,
                FirstName = $"{getinvoice.Customer.UserDetails.FirstName} {getinvoice.Customer.UserDetails.LastName}",
                FilePath = path,
                GetAddressDto = new GetAddressDto()
                {
                    NumberLine = getinvoice.Customer.UserDetails.Address.NumberLine,
                    Street = getinvoice.Customer.UserDetails.Address.Street,
                    City = getinvoice.Customer.UserDetails.Address.City,
                    Region = getinvoice.Customer.UserDetails.Address.Region,
                    State = getinvoice.Customer.UserDetails.Address.State,
                    Country = getinvoice.Customer.UserDetails.Address.Country,
                    PostalCode = getinvoice.Customer.UserDetails.Address.PostalCode
                },
                GetOrderDto = invoice.Select(x => new GetOrderDto()
                {
                    Id = x.Id,
                    OrderId = x.Order.OrderId,
                    Pieces = x.Order.Pieces,
                    Price = x.Order.Price
                }).ToList(),
            };
            return new InvoiceResponse()
            {
                Data = InvoiceOutput,
                Message = "Invoice Generated Successfully",
                Status = true
            };
        }
        return new InvoiceResponse()
        {
            Data = null,
            Message = "Unable To Generate Invoice",
            Status = false
        };
    }
    public string InvoiceItems(IList<Payment> payments)
    {
        var get = "";
        foreach(var payment in payments)
        {
            get += $"<div><strong><span>{payment.Order.OrderId}</span> <span>{payment.Order.Price} <h6>X</h6 {payment.Order.Pieces}</span></strong></div>";
        }
        return get;
    }
    public string GetOrderNos(IList<Order> orders)
    {
        string orderString = "";
        foreach (var order in orders)
        {
            orderString += $"{order.OrderId.Take(5)} /n";
        }
        return orderString;
    }
    public GetPaymentDto GetDetails(Payment payment, Customer customer, IList<Order> Order)
    {
        return new GetPaymentDto
        {
            Id = payment.Id,
            AmountPaid = payment.AmountPaid,
            ShippingFee = payment.ShippingFee,
            StoreTaxes = payment.StoreTaxes,
            ReferenceNo = payment.ReferenceNumber,
            DateOfPayment = payment.DateOfPayment,
            customerDto = new GetCustomerDto()
            {
                Id = customer.Id,
                Email = customer.User.Email,
                GetUserDetailsDto = new GetUserDetailsDto()
                {
                    FirstName = customer.UserDetails.FirstName,
                    LastName = customer.UserDetails.LastName,
                }
            },
            GetOrderDto = Order.Select(x => new GetOrderDto()
            {
                Id = x.Id,
                OrderId = x.OrderId,
                Pieces = x.Pieces,
                Price = x.Price
            }).ToList(),
        };
    }
}
