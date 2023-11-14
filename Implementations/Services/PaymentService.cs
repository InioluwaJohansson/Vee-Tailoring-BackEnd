using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;
using Vee_Tailoring.Emails;
using Vee_Tailoring.Payments;
using System.Net;

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
    IPaymentsHandler _paymentsHandler;
    public PaymentService(IPaymentRepo repository, IOrderService orderService, ICustomerRepo customerRepo, IOrderRepo orderRepo, ITokenService tokenService, IDefaultPriceRepo defaultPriceRepo, IEmailSend email, ICardRepo cardRepo, IPaymentsHandler paymentsHandler)
    {
        _repository = repository;
        _orderService = orderService;
        _customerRepo = customerRepo;
        _orderRepo = orderRepo;
        _email = email;
        _tokenService = tokenService;
        _defaultPriceRepo = defaultPriceRepo;
        _cardRepo = cardRepo;
        _paymentsHandler = paymentsHandler;
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
                if (cart != null)
                {
                    var generateRef = Guid.NewGuid().ToString().Substring(0, 15);
                    HttpStatusCode response = new HttpStatusCode();
                    if (makePayment.paymentMethod == PaymentMethod.Paystack)
                    {
                        var package = new PayStackPackage()
                        {
                            currency = "USD",
                            amount = cart.Data.TotalPrice,
                            email = customer.User.Email,
                            referenceNumber = generateRef

                        };
                        response = await _paymentsHandler.PaystackPayment(package);
                    }
                    if (makePayment.paymentMethod == PaymentMethod.Visa)
                    {
                        var card = await _cardRepo.Get(x => x.Id == makePayment.CardId && x.UserId == id && x.IsDeleted == false);
                        if(card != null)
                        {
                            response = await _paymentsHandler.VisaPayment(card, cart.Data.TotalPrice);
                        }
                        
                    }
                    if (response == System.Net.HttpStatusCode.OK)
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
                            PaymentRoute = makePayment.paymentMethod.ToString(),
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
                                Message = $"Hi, {customer.UserDetails.LastName} {customer.UserDetails.FirstName} Thanks for shopping with us. /n" +
                                $"Check your order history to keep track of your Orders. /n" +
                                $"{GetOrderNos(order)} /n" + "Vee Tailoring"
                            };
                            await _email.SendMail(email);
                            var adminEmail = new CreateEmailDto()
                            {
                                Subject = "Order(s) Payment Completed Successfully",
                                ReceiverName = $"Inioluwa Johansson",
                                ReceiverEmail = "inioluwa.makinde10@gmail.com",
                                Message = $"{customer.UserDetails.LastName} {customer.UserDetails.FirstName} shopped with Us. /n" +
                                $"You can use the following order numbers to keep track of the Orders /n" +
                                $"{(GetOrderNos(order))} /n" + "Vee Tailoring"
                            };
                            await _email.SendMail(adminEmail);
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
                    Message = "Sorry. Your Cart Is Empty!",
                    Status = false
                };
            }
            return new BaseResponse()
            {
                Message = "Token Expired. Kindly Generate A New Payment Token!",
                Status = false
            };
        }
        return new BaseResponse()
        {
            Message = "Session Expired",
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
        var getinvoice = await _repository.GenerateInvoice(id);
        var invoiceOrders = await _orderRepo.GetByExpression(c => c.ReferenceNumber == getinvoice.ReferenceNumber);
        if (getinvoice != null)
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
            .Replace("$ITEMS", $"{InvoiceItems(invoiceOrders)}")
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
                PaymentRoute = getinvoice.PaymentRoute,
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
                GetOrderDto = invoiceOrders.Select(x => new GetOrderDto()
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    Pieces = x.Pieces,
                    Price = x.Price
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
    public string InvoiceItems(IList<Order> orders)
    {
        var get = "";
        foreach(var order in orders)
        {
            get += $"<div><strong><span>{order.OrderId}</span> <span>{order.Price} <h6>X</h6 {order.Pieces}</span></strong></div>";
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
            PaymentRoute = payment.PaymentRoute,
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
