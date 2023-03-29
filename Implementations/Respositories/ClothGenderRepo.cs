using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

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