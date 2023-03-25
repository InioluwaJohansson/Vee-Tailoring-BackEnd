using Microsoft.EntityFrameworkCore;
using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;

namespace V_Tailoring.Implementations.Respositories
{
    public class ComplaintRepo : BaseRepository<Complaint>, IComplaintRepo
    {
        public ComplaintRepo(TailoringContext _context)
        {
            context = _context;
        }
        public async Task<Complaint> GetById(int Id)
        {
            return await context.Complaints.SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
        }
        public async Task<IList<Complaint>> GetSolvedComplaints()
        {
            return await context.Complaints.Where(c => c.IsSolved == true && c.IsDeleted == false).ToListAsync();
        }
        public async Task<IList<Complaint>> GetUnSolvedComplaints()
        {
            return await context.Complaints.Where(c => c.IsSolved == false && c.IsDeleted == false).ToListAsync();
        }
        public async Task<IList<Complaint>> List()
        {
            return await context.Complaints.Where(c => c.IsDeleted == false).ToListAsync();
        }
    }
}
