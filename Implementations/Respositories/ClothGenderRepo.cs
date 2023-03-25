using Microsoft.EntityFrameworkCore;
using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Interfaces.Respositories;

namespace V_Tailoring.Implementations.Respositories
{
    public class ClothGenderRepo : BaseRepository<ClothGender>, IClothGenderRepo
    {
        public ClothGenderRepo(TailoringContext _context)
        {
            context = _context;
        }
        public async Task<ClothGender> GetById(int Id)
        {
            return await context.ClothGender.SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
        }
        public async Task<IList<ClothGender>> List()
        {
            return await context.ClothGender.Where(c => c.IsDeleted == false).ToListAsync();
        }
    }
}