using Vee_Tailoring.Contracts;
using Vee_Tailoring.Models.Enums;
namespace Vee_Tailoring.Entities;

public class UserDetails : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string ImageUrl { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public Address Address { get; set; }
}
