using V_Tailoring.Contracts;
using V_Tailoring.Entities.Identity;
using V_Tailoring.Models.Enums;

namespace V_Tailoring.Entities
{
    public class Staff: AuditableEntity
    {
        public UserDetails UserDetails { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string StaffNo { get; set; }
    }
}
