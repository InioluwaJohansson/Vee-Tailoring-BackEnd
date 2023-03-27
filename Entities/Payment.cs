using V_Tailoring.Contracts;
using V_Tailoring.Entities;
using V_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Entities
{
    public class Payment : AuditableEntity
    {
        public string ReferenceNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; }
    }
}
