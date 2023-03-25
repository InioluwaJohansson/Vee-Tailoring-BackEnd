using Microsoft.EntityFrameworkCore;
using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;
using V_Tailoring.Models.Enums;

namespace V_Tailoring.Implementations.Respositories
{
    public class MaterialRepo : BaseRepository<Material>, IMaterialRepo
    {
        public MaterialRepo(TailoringContext _context)
        {
            context = _context;
        }
        public async Task<Material> GetById(int Id)
        {
            return await context.Materials.SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
        }
        public async Task<IList<Material>> GetByMaterialName(string MaterialName)
        {
            return await context.Materials.Where(c => c.MaterialName.StartsWith(MaterialName) && c.IsDeleted == false).ToListAsync();
        }
        public async Task<IList<Material>> ListByMaterialPrice(decimal MaterialPrice)
        {
            return await context.Materials.OrderByDescending(c => c.MaterialPrice <= MaterialPrice && c.IsDeleted == false).ToListAsync();
        }
        public async Task<IList<Material>> List()
        {
            return await context.Materials.Where(c => c.IsDeleted == false).ToListAsync();
        }
    }
}
