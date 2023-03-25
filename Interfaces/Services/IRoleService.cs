using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Interface.Services
{
    public interface IRoleService
    {
        Task<BaseResponse> Create(CreateRoleDto createRoleDto);
        Task<BaseResponse> Update(int id, UpdateRoleDto updateRoleDto);
        Task<RoleResponseModel> GetById(int id);
        Task<RolesResponseModel> GetByUserId(int id);
        Task<RolesResponseModel> GetAllRoles();
    }
}
