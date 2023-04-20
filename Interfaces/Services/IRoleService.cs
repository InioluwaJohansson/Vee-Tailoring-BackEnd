using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Interfaces.Services;

public interface IRoleService
{
    Task<BaseResponse> Create(CreateRoleDto createRoleDto);
    Task<BaseResponse> Update(int id, UpdateRoleDto updateRoleDto);
    Task<RoleResponseModel> GetById(int id);
    Task<RolesResponseModel> GetByUserId(int id);
    Task<RolesResponseModel> GetAllRoles();
}
