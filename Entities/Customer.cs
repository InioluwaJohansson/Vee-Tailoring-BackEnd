using Vee_Tailoring.Contracts;
using Vee_Tailoring.Entities.Identity;
namespace Vee_Tailoring.Entities;

public class Customer: AuditableEntity
{
    public User User { get; set; }
    public int UserId { get; set; }
    public UserDetails UserDetails { get; set; }
    public string CustomerNo { get; set; }
    public Measurement Measurements { get; set; }
}
