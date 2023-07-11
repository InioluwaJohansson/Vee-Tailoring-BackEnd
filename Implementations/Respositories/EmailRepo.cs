using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Respositories;
public class EmailRepo : BaseRepository<Email>, IEmailRepo
{
    public EmailRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Email> GetById(int Id)
    {
        return await context.Email.Include(c => c.Staff).SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<Email>> GetByEmailType(EmailType emailType)
    {
        return await context.Email.Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Where(c => c.EmailType == emailType && c.IsDeleted == false).OrderByDescending(c => c.CreatedOn).ToListAsync();
    }
    public async Task<IList<Email>> GetByStaffId(int staffId)
    {
        return await context.Email.Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Where(c => c.StaffId == staffId && c.IsDeleted == false).OrderByDescending(c => c.CreatedOn).ToListAsync();
    }
    public async Task<IList<Email>> GetByStaffIdEmailType(int staffId, EmailType emailType)
    {
        return await context.Email.Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Where(c => c.StaffId == staffId && c.EmailType == emailType && c.IsDeleted == false).OrderByDescending(c => c.CreatedOn).ToListAsync();
    }
    public async Task<IList<Email>> List()
    {
        return await context.Email.Include(c => c.Staff).Include(c => c.Staff.User).Include(c => c.Staff.UserDetails).Where(c => c.IsDeleted == false).OrderByDescending(c => c.CreatedOn).ToListAsync();
    }
}
