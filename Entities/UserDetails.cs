using V_Tailoring.Contracts;
using V_Tailoring.Models.Enums;
namespace V_Tailoring.Entities
{
    public class UserDetails : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string ImageUrl { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public Address Address { get; set; }
    }
}
