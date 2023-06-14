using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class TemplateRepo : BaseRepository<Template>, ITemplateRepo
{
    public TemplateRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Template> GetById(int id)
    {
        return await context.Templates.Include(c => c.ArmType).Include(c => c.Color).Include(c => c.Material).Include(c => c.Pattern).Include(c => c.Style).SingleOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);
    }
    public async Task<IList<Template>> GetAllTemplatesByClothCategory(int clothCategory)
    {
        return await context.Templates.Include(c => c.ArmType).Include(c => c.Color).Include(c => c.Material).Include(c => c.Pattern).Include(c => c.Style).Where(c => c.ClothCategoryId == clothCategory && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Template>> GetAllTemplatesByClothCategoryClothGender(int clothCategory, int clothGender)
    {
        return await context.Templates.Include(c => c.ArmType).Include(c => c.Color).Include(c => c.Material).Include(c => c.Pattern).Include(c => c.Style).Where(c => c.ClothCategoryId == clothCategory && c.ClothGenderId == clothGender && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Template>> GetAllTemplatesByCollectionId(int id)
    {
        return await context.Templates.Include(c => c.ArmType).Include(c => c.Color).Include(c => c.Material).Include(c => c.Pattern).Include(c => c.Style).Where(c => c.CollectionId == id && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Template>> GetAllTemplates()
    {
        return await context.Templates.Include(c => c.ArmType).Include(c => c.Color).Include(c => c.Material).Include(c => c.Pattern).Include(c => c.Style).Where(c => c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Template>> GetByTemplateName(string TemplateName)
    {
        return await context.Templates.Include(c => c.ArmType).Include(c => c.Color).Include(c => c.Material).Include(c => c.Pattern).Include(c => c.Style).Where(c => c.TemplateName.StartsWith(TemplateName) && c.IsDeleted == false).ToListAsync();
    }
}
