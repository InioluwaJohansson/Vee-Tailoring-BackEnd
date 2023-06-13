using Microsoft.EntityFrameworkCore;
using Vee_Tailoring.Context;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Entities.Identity;
using Vee_Tailoring.Interfaces.Respositories;

namespace Vee_Tailoring.Implementations.Respositories;

public class RoleRepo : BaseRepository<Role>, IRoleRepo
{
    public RoleRepo(TailoringContext _context)
    {
        context = _context;
    }
    public async Task<IList<Role>> GetRoleByUserId(int Id)
    {
        return await context.UserRoles.Include(c => c.User).Include(c => c.Role).Where(c => c.UserId == Id).Select(r => new Role()
        {
            Name = r.Role.Name,
            Description = r.Role.Description,
        }).ToListAsync();
    }
    public async Task<IList<Role>> GetAllRoles()
    {
        return await context.Roles.ToListAsync();
    }
}
