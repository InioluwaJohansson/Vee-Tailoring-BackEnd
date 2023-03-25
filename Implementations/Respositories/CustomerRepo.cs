using Microsoft.EntityFrameworkCore;
using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;

namespace V_Tailoring.Implementations.Respositories
{
    public class CustomerRepo : BaseRepository<Customer>, ICustomerRepo
    {
        public CustomerRepo(TailoringContext _context)
        {
            context = _context;
        }
        public async Task<Customer> GetById(int Id)
        {
            return await context.Customers.Include(c => c.Measurements).Include(c => c.User).Include(c => c.UserDetails.Address).SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
        }
        public async Task<Customer> GetByUserId(int Id)
        {
            return await context.Customers.Include(c => c.Measurements).Include(c => c.User).Include(c => c.UserDetails.Address).SingleOrDefaultAsync(c => c.User.Id == Id && c.IsDeleted == false);
        }
        public async Task<IList<Customer>> GetbyEmail(string email)
        {
            return await context.Customers.Include(c => c.Measurements).Include(c => c.User).Include(c => c.UserDetails.Address).Where(c => c.User.Email.StartsWith(email) && c.IsDeleted == false).ToListAsync();
        }
        public async Task<IList<Customer>> List()
        {
            return await context.Customers.Include(c => c.UserDetails.Address).Include(c => c.User).Include(c=> c.Measurements).Where(c => c.IsDeleted == false).ToListAsync();
        }
    }
}
