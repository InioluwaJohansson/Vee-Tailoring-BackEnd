using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Models.DTOs;

public class CreatePaymentDto
{
}
public class GetPaymentDto
{
    public int Id { get; set; }
    public string ReferenceNo { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime DateOfPayment { get; set; }
    public GetCustomerDto customerDto { get; set; }
    public GetOrderDto orderDto { get; set; }
}
public class UpdateOrderPaymentCheck
{
    public string ReferenceNo { get; set; }
    public bool Check { get; set; }
    public int CustomerId { get; set; }
}
public class InvoiceResponse : BaseResponse
{
    public string FilePath { get; set; }
}
public class PaymentResponse : BaseResponse
{
    public GetPaymentDto Data { get; set; }
}
public class PaymentsResponseModel : BaseResponse
{
    public ICollection<GetPaymentDto> Data { get; set; } = new HashSet<GetPaymentDto>();
}
