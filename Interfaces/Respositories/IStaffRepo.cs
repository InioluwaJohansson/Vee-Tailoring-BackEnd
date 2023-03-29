using Vee_Tailoring.Entities;
namespace Vee_Tailoring.Interfaces.Respositories;

public interface IStaffRepo : IRepo<Staff>
{
    Task<Staff> GetById(int Id);
    Task<Staff> GetByUserId(int Id);
    Task<IList<Staff>> GetbyEmail(string email);
    Task<IList<Staff>> List();
}
