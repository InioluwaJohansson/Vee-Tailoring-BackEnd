using Vee_Tailoring.Entities;
using Vee_Tailoring.Implementations.Respositories;

namespace Vee_Tailoring.Interfaces.Respositories;

public interface IComplaintRepo : IRepo<Complaint>
{
    Task<Complaint> GetById(int Id);
    Task<IList<Complaint>> GetUnSolvedComplaints();
    Task<IList<Complaint>> GetSolvedComplaints();
    Task<IList<Complaint>> List();
}
