using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class ArmTypeRepo : BaseRepository<ArmType>, IArmTypeRepo
{
    public ArmTypeRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<ArmType> GetById(int Id)
    {
        return await context.ArmTypes.SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<ArmType>> List()
    {
        return await context.ArmTypes.Where(c => c.IsDeleted == false).ToListAsync();
    }
}
