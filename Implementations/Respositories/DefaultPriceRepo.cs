using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Implementations.Respositories;

public class DefaultPriceRepo : BaseRepository<DefaultPrice>, IDefaultPriceRepo
{
    public DefaultPriceRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<DefaultPrice> GetById(int id)
    {
        return await context.DefaultPrices.SingleOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);
    }
    public async Task<DefaultPrice> GetDefaultPrice()
    {
        return await context.DefaultPrices.SingleOrDefaultAsync(c => c.Id == 1 && c.IsDeleted == false);
    }
    public async Task<DefaultPrice> GetShippingFees()
    {
        return await context.DefaultPrices.SingleOrDefaultAsync(c => c.Id == 2 && c.IsDeleted == false);
    }
}
