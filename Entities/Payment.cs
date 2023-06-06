using Vee_Tailoring.Contracts;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Entities;

public class Payment : AuditableEntity
{
    public string ReferenceNumber { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Order Order { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal ShippingFee { get; set; }
    public DateTime DateOfPayment { get; set; }
}
