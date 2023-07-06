using System.Net;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Payments;
public interface IPaymentsHandler
{
    Task<HttpStatusCode> PaystackPayment(PayStackPackage package);
    Task<HttpStatusCode> VisaPayment(Card card, decimal amount);
}
