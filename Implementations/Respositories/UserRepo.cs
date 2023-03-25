using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Entities.Identity;
using V_Tailoring.Interfaces.Respositories;

namespace V_Tailoring.Implementations.Respositories
{
    public class UserRepo : BaseRepository<User>, IUserRepo
    {
        public UserRepo(TailoringContext _context)
        {
            context = _context;
        }
    }
}
