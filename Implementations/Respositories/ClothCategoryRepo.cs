using Microsoft.EntityFrameworkCore;
using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;

namespace V_Tailoring.Implementations.Respositories
{
    public class ClothCategoryRepo : BaseRepository<ClothCategory>, IClothCategoryRepo
    {
        public ClothCategoryRepo(TailoringContext _context)
        {
            context = _context;
        }
        public async Task<ClothCategory> GetById(int Id)
        {
            return await context.ClothCategories.SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
        }
        public async Task<IList<ClothCategory>> List()
        {
            return await context.ClothCategories.Where(c => c.IsDeleted == false).ToListAsync();
        }
    }
}
