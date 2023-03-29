using Vee_Tailoring.Contracts;
using Vee_Tailoring.Entities.Identity;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Entities;

public class Staff: AuditableEntity
{
    public UserDetails UserDetails { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public string StaffNo { get; set; }
}
