using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class CollectionRepo : BaseRepository<Collection>, ICollectionRepo
{
    public CollectionRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Collection> GetById(int id)
    {
        return await context.Collections.Include(c => c.Template.ArmType).Include(c => c.Template.Color).Include(c => c.Template.Material).Include(c => c.Template.Pattern).Include(c => c.Template.Style).SingleOrDefaultAsync(c => c.Id == id);
    }
    public async Task<IList<Collection>> GetAllCollectionsByClothCategory(int clothCategory)
    {
        return await context.Collections.Include(c => c.Template.ArmType).Include(c => c.Template.Color).Include(c => c.Template.Material).Include(c => c.Template.Pattern).Include(c => c.Template.Style).Where(c => c.ClothCategoryId == clothCategory).ToListAsync();
    }
    public async Task<IList<Collection>> GetAllCollectionsByClothCategoryClothGender(int clothCategory, int clothGender)
    {
        return await context.Collections.Include(c => c.Template.ArmType).Include(c => c.Template.Color).Include(c => c.Template.Material).Include(c => c.Template.Pattern).Include(c => c.Template.Style).Where(c => c.ClothCategoryId == clothCategory && c.ClothGenderId == clothGender && c.ClothGenderId == 3).ToListAsync();
    }
    public async Task<IList<Collection>> GetAllCollections()
    {
        return await context.Collections.Include(c => c.Template.ArmType).Include(c => c.Template.Color).Include(c => c.Template.Material).Include(c => c.Template.Pattern).Include(c => c.Template.Style).ToListAsync();
    }
    public async Task<IList<Collection>> GetByCollectionName(string CollectionName)
    {
        return await context.Collections.Include(c => c.Template.ArmType).Include(c => c.Template.Color).Include(c => c.Template.Material).Include(c => c.Template.Pattern).Include(c => c.Template.Style).Where(c => c.CollectionName.StartsWith(CollectionName)).ToListAsync();
    }
}
