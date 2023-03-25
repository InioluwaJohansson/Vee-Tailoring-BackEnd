using V_Tailoring.Models.DTOs;
namespace V_Tailoring.Interface.Services
{
    public interface IStaffService
    {
        Task<BaseResponse> Create(CreateStaffDto createStaffDto);
        Task<BaseResponse> Update(int id, UpdateStaffDto updateStaffDto);
        Task<StaffResponseModel> GetById(int id);
        Task<StaffResponseModel> GetByUserId(int id);
        Task<StaffsResponseModel> GetByStaffEmail(string Email);
        Task<StaffsResponseModel> GetAllStaffs();
        Task<DashBoardResponse> StaffsDashboard();
        Task<StaffUserDashboard> UserDashboard(int id);
        Task<BaseResponse> DeActivateStaff(int id);
    }
}
