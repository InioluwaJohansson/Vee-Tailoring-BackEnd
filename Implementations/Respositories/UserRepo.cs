using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Entities.Identity;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class UserRepo : BaseRepository<User>, IUserRepo
{
    public UserRepo(TailoringContext _context)
    {
        context = _context;
    }
}
