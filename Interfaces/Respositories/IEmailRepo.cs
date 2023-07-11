using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Interfaces.Respositories;
public interface IEmailRepo : IRepo<Email>
{
    Task<Email> GetById(int Id);
    Task<IList<Email>> GetByEmailType(EmailType emailType);
    Task<IList<Email>> GetByStaffId(int staffId);
    Task<IList<Email>> GetByStaffIdEmailType(int staffId, EmailType emailType);
    Task<IList<Email>> List();
}
