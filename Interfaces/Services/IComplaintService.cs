using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services;

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
