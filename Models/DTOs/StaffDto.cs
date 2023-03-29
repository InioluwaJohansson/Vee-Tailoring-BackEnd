using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Models.DTOs;

public class CreateStaffDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
public class GetStaffDto
{
    public int Id { get; set; }
    public GetUserDetailsDto GetUserDetailsDto { get; set; }
    public string StaffNo { get; set; }
    public string Email { get; set; }
}
public class UpdateStaffDto
{
    public UpdateUserDetailsDto UpdateUserDetailsDto { get; set; }
    public string Email { get; set; }
}
public class StaffResponseModel : BaseResponse
{
    public GetStaffDto Data { get; set; }
}
public class StaffsResponseModel : BaseResponse
{
    public ICollection<GetStaffDto> Data { get; set; } = new HashSet<GetStaffDto>();
}
