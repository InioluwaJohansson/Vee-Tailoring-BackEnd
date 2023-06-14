using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class StaffRepo : BaseRepository<Staff>, IStaffRepo
{
    public StaffRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Staff> GetById(int Id)
    {
        return await context.Staffs.Include(c => c.User).Include(c => c.UserDetails).Include(c => c.UserDetails.Address).SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<Staff> GetByUserId(int Id)
    {
        return await context.Staffs.Include(c => c.User).Include(c => c.UserDetails).Include(c => c.UserDetails.Address).SingleOrDefaultAsync(c => c.User.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<Staff>> GetbyEmail(string email)
    {
        return await context.Staffs.Include(c => c.User).Include(c => c.UserDetails).Include(c => c.UserDetails.Address).Where(c => c.User.Email.StartsWith(email) && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Staff>> List()
    {
        return await context.Staffs.Include(c => c.User).Include(c => c.UserDetails).Include(c => c.UserDetails.Address).Where(c => c.IsDeleted == false).ToListAsync();
    }
}
