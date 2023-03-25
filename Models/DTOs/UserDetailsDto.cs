using V_Tailoring.Models.Enums;

namespace V_Tailoring.Models.DTOs
{
    public class CreateUserDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string PhoneNumber { get; set; } = null;
        public CreateAddressDto CreateAddressDto { get; set; }
    }
    public class GetUserDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public GetAddressDto GetAddressDto { get; set; }
    }
    public class UpdateUserDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public UpdateAddressDto UpdateAddressDto { get; set; }
    }
}
