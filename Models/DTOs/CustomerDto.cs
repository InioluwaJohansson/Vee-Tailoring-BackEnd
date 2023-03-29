using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Models.DTOs;

public class CreateCustomerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
public class GetCustomerDto
{
    public int Id { get; set; }
    public GetUserDetailsDto GetUserDetailsDto { get; set; }
    public string CustomerNo { get; set; }
    public string Email { get; set; }
    public GetMeasurementDto GetMeasurementDto { get; set; }
}
public class UpdateCustomerDto
{
    public UpdateUserDetailsDto UpdateUserDetailsDto { get; set; }
    public UpdateMeasurementDto UpdateMeasurementDto { get; set; }
    public string Email { get; set; }
}
public class CustomerResponseModel :  BaseResponse
{
    public GetCustomerDto Data { get; set; }
}
public class CustomersResponseModel : BaseResponse
{
    public ICollection<GetCustomerDto> Data { get; set; } = new HashSet<GetCustomerDto>();
}
