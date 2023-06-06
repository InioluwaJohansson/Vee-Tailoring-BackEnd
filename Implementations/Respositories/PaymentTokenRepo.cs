using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;
using Microsoft.EntityFrameworkCore;

namespace Vee_Tailoring.Implementations.Respositories;

public class PaymentTokenRepo : BaseRepository<PaymentToken>, IPaymentTokenRepo
{
    public PaymentTokenRepo(TailoringContext _context)
    {
        context = _context;
    }
}
