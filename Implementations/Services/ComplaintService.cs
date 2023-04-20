using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class ComplaintService : IComplaintService
{
    IComplaintRepo _repository;
    public ComplaintService(IComplaintRepo repository)
    {
        _repository = repository;
    }
    public async Task<BaseResponse> Create(CreateComplaintDto createComplaintDto)
    {
        var complaint = new Complaint()
        {
            Email = createComplaintDto.Email,
            Description = createComplaintDto.Description,
            IsDeleted = false,
        };
        await _repository.Create(complaint);
        return new BaseResponse()
        {
            Message = "Complaint Lodged successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id)
    {
        var Complaint = await _repository.GetById(id);
        if (Complaint != null)
        {
            Complaint.IsSolved = true;
            await _repository.Update(Complaint);
            return new BaseResponse()
            {
                Message = "Complaint Solved Successfully",
                Status = true,
            };

        }
        return new BaseResponse()
        {
            Message = "Unable To Solve Complaint Successfully",
            Status = true,
        };
    }
    public async Task<ComplaintResponseModel> GetById(int id)
    {
        var Complaint = await _repository.GetById(id);
        if (Complaint != null)
        {
            return new ComplaintResponseModel()
            {
                Data = GetDetails(Complaint),
                Message = "Complaint Retrieved Successfully",
                Status = true,
            };

        }
        return new ComplaintResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Complaint Successfully",
            Status = true,
        };
    }
    public async Task<ComplaintsResponseModel> GetAllSolvedComplaints()
    {
        var Complaints = await _repository.GetSolvedComplaints();
        if (Complaints != null)
        {
            return new ComplaintsResponseModel()
            {
                Data = Complaints.Select(Complaint => GetDetails(Complaint)).ToList(),
                Message = "Complaints List Retrieved Successfully",
                Status = true
            };

        }
        return new ComplaintsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Complaints List Successfully",
            Status = false
        };
    }
    public async Task<ComplaintsResponseModel> GetAllUnSolvedComplaints()
    {
        var Complaints = await _repository.GetUnSolvedComplaints();
        if (Complaints != null)
        {
            return new ComplaintsResponseModel()
            {
                Data = Complaints.Select(Complaint => GetDetails(Complaint)).ToList(),
                Message = "Complaints List Retrieved Successfully",
                Status = true
            };

        }
        return new ComplaintsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Complaints List Successfully",
            Status = false
        };
    }
    public async Task<ComplaintsResponseModel> GetAllComplaints()
    {
        var Complaints = await _repository.List();
        if (Complaints != null)
        {
            return new ComplaintsResponseModel()
            {
                Data = Complaints.Select(Complaint => GetDetails(Complaint)).ToList(),
                Message = "Complaints List Retrieved Successfully",
                Status = true
            };

        }
        return new ComplaintsResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Complaints List Successfully",
            Status = false
        };
    }
    public GetComplaintDto GetDetails(Complaint Complaint)
    {
        return new GetComplaintDto
        {
            Id = Complaint.Id,
            Email = Complaint.Email,
            Description = Complaint.Description,
        };
    }
    public async Task<DashBoardResponse> ComplaintsDashboard()
    {
        int total = (await _repository.GetAll()).Count;
        int active = (await _repository.GetByExpression(x => x.IsDeleted == false)).Count;
        int inActive = (await _repository.GetByExpression(x => x.IsDeleted == true)).Count;
        if (total != 0)
        {
            return new DashBoardResponse
            {
                Total = total,
                Active = active,
                InActive = inActive,
                Status = true,
            };
        }
        return new DashBoardResponse
        {
            Message = "No Registered Complaints!",
            Status = false,
        };
    }
}
