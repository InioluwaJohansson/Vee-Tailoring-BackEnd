using Vee_Tailoring.Contracts;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Entities.Identity;

public class User : AuditableEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Customer Customer { get; set; }
    public Staff Staff { get; set; }
    public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
