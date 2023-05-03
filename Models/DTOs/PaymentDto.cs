﻿using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Models.DTOs;

public class MakePaymentDto
{ 
    public PaymentMethod paymentMethod { get; set; }
    public string CardPin { get; set; }
    public string ValidFrom { get; set; } 
    public string UntilEnd { get; set; }
    public string CVV { get; set; }
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
public class GetInvoiceDto
{
    public string ReferenceNo { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime DateOfPayment { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public GetAddressDto GetAddressDto { get; set; }
    public ICollection<GetOrderDto> GetOrderDto { get; set; } = new HashSet<GetOrderDto>();
    public string FilePath { get; set; }
}
public class InvoiceResponse : BaseResponse
{
    public GetInvoiceDto Data { get; set; }
}
public class PaymentResponse : BaseResponse
{
    public GetPaymentDto Data { get; set; }
}
public class PaymentsResponseModel : BaseResponse
{
    public ICollection<GetPaymentDto> Data { get; set; } = new HashSet<GetPaymentDto>();
}
