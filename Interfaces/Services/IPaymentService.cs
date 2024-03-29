﻿using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Interfaces.Services;

public interface IPaymentService
{
    Task<BaseResponse> GenerateToken(int id);
    Task<BaseResponse> MakePayment(int id, MakePaymentDto makePayment);
    Task<BaseResponse> VerifyPayment(string referenceNumber);
    Task<BaseResponse> VerifyPaymentByCustomer(int id, string referenceNumber);
    Task<PaymentResponse> GetPayment(int id);
    Task<PaymentsResponseModel> GetAllPaymentsByCustomer(int id);
    Task<PaymentsResponseModel> GetAllPayments();
    Task<PaymentsResponseModel> GetAllPaymentsDateRange(DateTime startDate, DateTime endDate);
    Task<InvoiceResponse> GenerateInvoice(int id);
}
