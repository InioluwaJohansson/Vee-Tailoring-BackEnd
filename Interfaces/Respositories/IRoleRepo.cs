using Vee_Tailoring.Entities.Identity;

namespace Vee_Tailoring.Interfaces.Respositories;

public interface IRoleRepo : IRepo<Role>
{
    Task<IList<Role>> GetRoleByUserId(int id);
    Task<IList<Role>> GetAllRoles();
}
