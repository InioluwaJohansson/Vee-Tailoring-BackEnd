using V_Tailoring.Entities;
using V_Tailoring.Implementations.Respositories;

namespace V_Tailoring.Interfaces.Respositories
{
    public interface IComplaintRepo : IRepo<Complaint>
    {
        Task<Complaint> GetById(int Id);
        Task<IList<Complaint>> GetUnSolvedComplaints();
        Task<IList<Complaint>> GetSolvedComplaints();
        Task<IList<Complaint>> List();
    }
}
