using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class CategoryRepo : BaseRepository<Category>, ICategoryRepo
{
    public CategoryRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Category> GetById(int Id)
    {
        return await context.Categories.SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<Category>> List()
    {
        return await context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
    }
}
