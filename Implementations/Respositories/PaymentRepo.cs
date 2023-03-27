using V_Tailoring.Context;
using V_Tailoring.Implementations.Respositories;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories
{
    public class PaymentRepo : BaseRepository<Payment>, IPaymentRepo
    {
        public PaymentRepo(TailoringContext _context)
        {
            context = _context;
        }
    }
}
