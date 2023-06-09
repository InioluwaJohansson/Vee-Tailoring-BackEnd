using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;
public class CardRepo : BaseRepository<Card>, ICardRepo
{
    public CardRepo(TailoringContext _context)
    {
        context = _context;
    }
}
