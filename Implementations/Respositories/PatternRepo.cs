using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Respositories;

public class PatternRepo : BaseRepository<Pattern>, IPatternRepo
{
    public PatternRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Pattern> GetById(int Id)
    {
        return await context.Patterns.Include(c => c.ClothCategories).SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<Pattern>> GetByName(string PatternName)
    {
        return await context.Patterns.Include(c => c.ClothCategories).Where(c => c.PatternName.StartsWith(PatternName) && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Pattern>> GetPatternByClothCategory(int clothCategory)
    {
        return await context.Patterns.Include(c => c.ClothCategories).Include(c => c.ClothGender).Where(c => c.ClothCategories.Id == clothCategory && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Pattern>> GetPatternByClothCategoryGender(int clothCategory, int clothGenderId)
    {
        return await context.Patterns.Include(c => c.ClothCategories).Include(c => c.ClothGender).Where(c => c.ClothCategories.Id == clothCategory && c.ClothGenderId == clothGenderId && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Pattern>> GetPatternByPrice(decimal price)
    {
        return await context.Patterns.Include(c => c.ClothCategories).Include(c => c.ClothGender).OrderByDescending(c => c.PatternPrice <= price && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Pattern>> List()
    {
        return await context.Patterns.Include(c => c.ClothCategories).Include(c => c.ClothGender).Where(c => c.IsDeleted == false).ToListAsync();
    }
}
