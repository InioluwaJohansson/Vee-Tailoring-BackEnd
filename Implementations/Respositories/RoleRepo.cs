using Microsoft.EntityFrameworkCore;
using V_Tailoring.Context;
using V_Tailoring.Entities;
using V_Tailoring.Entities.Identity;
using V_Tailoring.Interfaces.Respositories;

namespace V_Tailoring.Implementations.Respositories
{
    public class RoleRepo : BaseRepository<Role>, IRoleRepo
    {
        public RoleRepo(TailoringContext _context)
        {
            context = _context;
        }
        public async Task<IList<Role>> GetRoleByUserId(int Id)
        {
            var role = await context.UserRoles.Include(c => c.User).Include(c => c.Role).Where(c => c.Id == Id).Select(r => new Role()
            {
                Name = r.Role.Name,
                Description = r.Role.Description,
            }).ToListAsync();
            return role;
        }
        public async Task<IList<Role>> GetAllRoles()
        {
            return await context.Roles.ToListAsync();
        }
    }
}
