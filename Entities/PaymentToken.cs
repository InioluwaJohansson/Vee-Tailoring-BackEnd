using Vee_Tailoring.Contracts;

namespace Vee_Tailoring.Entities
{
    public class PaymentToken : AuditableEntity
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public DateTime TokenStartTime { get; set; }
        public DateTime TokenEndTime { get; set; }
    }
}
