using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interface.Services;

public interface ICustomerService
{
    Task<BaseResponse> Create(CreateCustomerDto createCustomerDto);
    Task<BaseResponse> Update(int id, UpdateCustomerDto updateCustomerDto);
    Task<CustomerResponseModel> GetById(int id);
    Task<CustomerResponseModel> GetByUserId(int id);
    Task<CustomersResponseModel> GetByCustomerEmail(string email);
    Task<CustomersResponseModel> GetAllCustomers();
    Task<CustomerUserDashboard> UserDashboard(int id);
    Task<DashBoardResponse> CustomerDashboard();
    Task<BaseResponse> DeActivateCustomer(int id);
}
