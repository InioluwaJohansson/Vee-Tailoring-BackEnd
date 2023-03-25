using V_Tailoring.Entities;
namespace V_Tailoring.Interfaces.Respositories
{
    public interface IStaffRepo : IRepo<Staff>
    {
        Task<Staff> GetById(int Id);
        Task<Staff> GetByUserId(int Id);
        Task<IList<Staff>> GetbyEmail(string email);
        Task<IList<Staff>> List();
    }
}
