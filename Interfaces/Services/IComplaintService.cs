using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Interface.Services
{
    public interface IComplaintService
    {
        Task<BaseResponse> Create(CreateComplaintDto createComplaintDto);
        Task<BaseResponse> Update(int id);
        Task<ComplaintResponseModel> GetById(int id);
        Task<ComplaintsResponseModel> GetAllSolvedComplaints();
        Task<ComplaintsResponseModel> GetAllUnSolvedComplaints();
        Task<DashBoardResponse> ComplaintsDashboard();
        Task<ComplaintsResponseModel> GetAllComplaints();
    }
}
