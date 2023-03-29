using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Models.Enums;
using System.Threading.Tasks;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class StyleRepo : BaseRepository<Style>, IStyleRepo
{
    public StyleRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Style> GetById(int Id)
    {
        return await context.Styles.Include(c => c.ClothCategories).Include(c => c.ClothGender).SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<Style>> GetByStyleName(string styleName)
    {
        return await context.Styles.Include(c => c.ClothCategories).Include(c => c.ClothGender).Where(c => c.StyleName.StartsWith(styleName) && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Style>> GetByClothCategory(int categoryId)
    {
        return await context.Styles.Include(c => c.ClothCategories).Include(c => c.ClothGender).Where(c => c.ClothCategoryId == categoryId && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Style>> GetByClothCategoryGender(int category, int clothGenderId)
    {
        return await context.Styles.Include(c => c.ClothCategories).Include(c=> c.ClothGender).Where(c => c.ClothCategoryId == category && c.ClothGenderId == clothGenderId && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Style>> GetByStylePrice(decimal price)
    {
        return await context.Styles.Include(c => c.ClothCategories).Include(c => c.ClothGender).OrderByDescending(c => c.StylePrice <= price && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Style>> List()
    {
        return await context.Styles.Include(c => c.ClothCategories).Include(c => c.ClothGender).Where(c => c.IsDeleted == false).ToListAsync();
    }
}
