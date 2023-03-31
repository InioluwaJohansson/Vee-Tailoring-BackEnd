using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.Enums.V_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services;

public class PaymentService : IPaymentService
{
    IPaymentRepo _repository;
    IOrderService _orderService;
    ICustomerRepo _customerRepo;
    IConfiguration _configuration;
    public PaymentService(IPaymentRepo repository, IOrderService orderService, ICustomerRepo customerRepo, IConfiguration configuration)
    {
        _repository = repository;
        _orderService = orderService;
        _customerRepo = customerRepo;
        _configuration = configuration;
    }
    public async Task<BaseResponse> MakePayment(int id, MakePaymentDto makePayment)
    {
        var customer = await _customerRepo.GetByUserId(id);
        var cart = await _orderService.GetCartOrdersByCustomerId(id);
        if (cart != null & customer != null)
        {
            var generateRef = Guid.NewGuid().ToString().Substring(0, 15);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage catchresponse = new HttpResponseMessage();
            if(makePayment.paymentMethod == PaymentMethod.Paystack)
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
            if(makePayment.paymentMethod == PaymentMethod.MasterCard)
            {
                var url = "https://api.paystack.co/transaction/initialize";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["PayPal:SecretKey"]);
                var content = new StringContent(JsonSerializer.Serialize(new
                {
                    currency = "USD",
                    pin = makePayment.CardPin,
                    validFrom = makePayment.ValidFrom,
                    untilEnd = makePayment.UntilEnd,
                    cvv = makePayment.CVV,
                    amount = cart.Data.TotalPrice,
                    email = customer.User.Email,
                    referenceNumber = generateRef
                }), Encoding.UTF8, "application/json");
                catchresponse = await client.PostAsync(url, content);
                var reString = await catchresponse.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<PaymentMethodsDto>(reString);
            }
            if(catchresponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var updateOrderPayment = new UpdateOrderPaymentCheck()
                {
                    CustomerId = customer.Id,
                    Check = true,
                    ReferenceNo = generateRef
                };
                var pay = new Payment()
                {
                    AmountPaid  = cart.Data.TotalPrice,
                    CustomerId = customer.Id,
                    ReferenceNumber = generateRef,
                    DateOfPayment = DateTime.UtcNow,
                };
                await _repository.Create(pay);
                var updateOrder = await _orderService.UpdatePayment(updateOrderPayment);
                if(updateOrder.Status == true)
                {
                    return new BaseResponse()
                    {
                        Message = "Orders Payment Successfull!",
                        Status = updateOrder.Status
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
            Message = "Unable To Make Orders Payment!",
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
            return new PaymentResponse
            {
                Data = GetDetails(payment),
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
            return new PaymentsResponseModel()
            {
                Data = payments.Select(payment => GetDetails(payment)).ToList(),
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
                PaymentList.Add(GetDetails(payment,customer));
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
    public async Task<InvoiceResponse> GenerateInvoice(int id)
    {
        var invoice = await _repository.GenerateInvoice(id);
        var getinvoice = await _repository.Get(c => c.Id == id);
        if (invoice != null)
        {
            //Sending Invoice as PDF
            string sendInvoice = $"Vee Tailoring /n" +
                "Invoice Reference No: " + $"{getinvoice.ReferenceNumber}/n" + 
                "Order Items /n" +
                $"{InvoiceItems(invoice)} /n" +
                "-------------------------------------------------------------------" +
                $"Total: /t /t{getinvoice.AmountPaid}" +
                $"Customer Name: {getinvoice.Customer.UserDetails.FirstName } + {getinvoice.Customer.UserDetails.LastName} /n" +
                $"Customer Email: {getinvoice.Customer.User.Email}" 
                + $"Shipping Address: {getinvoice.Customer.UserDetails.Address.NumberLine}, " 
                + $"{getinvoice.Customer.UserDetails.Address.Street}, " 
                + $"{getinvoice.Customer.UserDetails.Address.City}, "
                + $"{getinvoice.Customer.UserDetails.Address.Region}, "
                + $"{getinvoice.Customer.UserDetails.Address.State}, "
                + $"{getinvoice.Customer.UserDetails.Address.Country} /n /n"
                + "/t /t Vee Management";

            string path = "", fileName = $"{getinvoice.ReferenceNumber}.pdf";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\Invoices\\");
            if (!System.IO.Directory.Exists($"{folderPath}\\{fileName}"))
            {
                Directory.CreateDirectory(folderPath);
                path = Path.Combine(folderPath, fileName);
                if(File.GetCreationTime(path) < File.GetCreationTime(path).AddMinutes(1.3)) File.Delete(path);
                
                if (File.Exists(path) == true || File.Exists(path) == false) await File.WriteAllTextAsync(path, sendInvoice);
            }
            var InvoiceOutput = new GetInvoiceDto()
            {
                ReferenceNo = getinvoice.ReferenceNumber,
                AmountPaid = getinvoice.AmountPaid,
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
    public GetPaymentDto GetDetails(Payment payment)
    {
        return new GetPaymentDto
        {
            Id = payment.Id,
            AmountPaid = payment.AmountPaid,
            ReferenceNo = payment.ReferenceNumber,
            DateOfPayment = payment.DateOfPayment,
        };
    }
    public string InvoiceItems(IList<Payment> payments)
    {
        foreach(var payment in payments)
        {
            return $"{payment.Order.OrderId}/t {payment.Order.Price} X {payment.Order.Pieces} /n";
        }
        return "";
    }
    public GetPaymentDto GetDetails(Payment payment, Customer customer)
    {
        return new GetPaymentDto
        {
            Id = payment.Id,
            AmountPaid = payment.AmountPaid,
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
            }
        };
    }
}
