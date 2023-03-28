using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using V_Tailoring.Entities;
using V_Tailoring.Interface.Services;
using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Models.DTOs;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums.V_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Services
{
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
        public async Task<BaseResponse> MakePayment(int id, PaymentMethod paymentMethod)
        {
            var customer = await _customerRepo.GetByUserId(id);
            var cart = await _orderService.GetCartOrdersByCustomerId(id);
            if (cart != null & customer != null)
            {
                var generateRef = Guid.NewGuid().ToString().Substring(0, 10);
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage catchresponse = new HttpResponseMessage();
                if(paymentMethod == PaymentMethod.Paystack)
                {
                    var url = "https://api.paystack.co/transaction/initialize";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["EmailSettings:SendInBlueKey"]);
                    var content = new StringContent(JsonSerializer.Serialize(new
                    {
                        amount = cart.Data.TotalPrice,
                        email = customer.User.Email,
                        referenceNumber = generateRef

                    }), Encoding.UTF8, "application/json");
                    catchresponse = await client.PostAsync(url, content);
                    var resString = await catchresponse.Content.ReadAsStringAsync();
                    var responseObj = JsonSerializer.Deserialize<PaymentMethodsDto>(resString);
                }
                if(paymentMethod == PaymentMethod.PayPal)
                {

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
            }
            return new BaseResponse()
            {
                Message = "Unable To Make Orders Payment!",
                Status = false
            };
        }
        public async Task<BaseResponse> VerifyPayment(string referenceNumber)
        {
            var payment = await _repository.GetByExpression(x => x.ReferenceNumber == referenceNumber && x.IsDeleted == false);
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
            var payment = await _repository.GetByExpression(x => x.ReferenceNumber == referenceNumber && x.CustomerId == id && x.IsDeleted == false);
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
            var payment = await _repository.GetByExpression(x => x.Id == id && x.IsDeleted == false);
            if (payment != null)
            {
                return new PaymentResponse
                {
                    Message = "Order Payment Verified Successfully",
                    Status = true
                };
            }
            return new PaymentResponse
            {
                Message = "Failed To Verify Order Payment",
                Status = false
            };
        }
        public async Task<PaymentsResponseModel> GetAllPaymentsByCustomer(int id)
        {
            var payments = await _repository.GetByExpression(x => x.Customer.UserId == id && x.IsDeleted == false);
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
}
