using Vee_Tailoring.Context;
using Vee_Tailoring.Implementations.Respositories;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Microsoft.EntityFrameworkCore;

namespace Vee_Tailoring.Implementations.Respositories;

public class PaymentRepo : BaseRepository<Payment>, IPaymentRepo
{
    public PaymentRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<Payment> GenerateInvoice(int id)
    {
        return await context.Payment.Include(c => c.Customer).Include(c => c.Customer.User).Include(c => c.Customer.UserDetails).Include(c => c.Customer.UserDetails.Address).Include(c => c.Order).FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);
    }
}
