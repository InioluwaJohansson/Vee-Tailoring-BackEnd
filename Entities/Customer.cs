using V_Tailoring.Contracts;
using V_Tailoring.Entities.Identity;
namespace V_Tailoring.Entities
{
    public class Customer: AuditableEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public UserDetails UserDetails { get; set; }
        public string CustomerNo { get; set; }
        public Measurement Measurements { get; set; }
    }
}
