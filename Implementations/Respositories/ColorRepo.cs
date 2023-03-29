using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class ColorRepo : BaseRepository<Color>, IColorRepo
{
    public ColorRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Color> GetById(int Id)
    {
        return await context.Colors.SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == false);
    }
    public async Task<IList<Color>> GetbyColorName(string colorName)
    {
        return await context.Colors.Where(c => c.ColorName.StartsWith(colorName) && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Color>> GetbyColorCode(string colorCode)
    {
        return await context.Colors.Where(c => c.ColorCode.StartsWith($"#{colorCode}") && c.IsDeleted == false).ToListAsync();
    }
    public async Task<IList<Color>> List()
    {
        return await context.Colors.Where(c => c.IsDeleted == false).ToListAsync();
    }
}
