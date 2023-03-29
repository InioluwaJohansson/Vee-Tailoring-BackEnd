using Vee_Tailoring.Entities.Identity;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class RoleService : IRoleService
{
    IRoleRepo _repository;
    IUserRepo _userRepository;
    public RoleService(IRoleRepo roleRepository, IUserRepo userRepository)
    {
        _repository = roleRepository;
        _userRepository = userRepository;
    }
    public async Task<BaseResponse> Create(CreateRoleDto createRoleDto)
    {
        var role = await _repository.Get(c => c.Name == createRoleDto.Name);
        if (role != null)
        {
            return new BaseResponse()
            {
                Message = "Role Already Exist",
                Status = false,
            };
        }
        var newRole = new Role()
        {
            Name = createRoleDto.Name,
            Description = createRoleDto.Description,
            IsDeleted = false,
        };
        await _repository.Create(newRole);
        return new BaseResponse ()
        {
            Message = "Role Created Successfully",
            Status = true,
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateRoleDto model)
    {
        var user = await _userRepository.Get(u => u.Id == id);
        if (user == null)
        {
            return new BaseResponse
            {
                Message = "User Not Found",
                Status = false,
            };
        }
        var updateUserRole = user.UserRoles.Where(x => x.UserId == user.Id).ToList();
        var getRole = await _repository.Get(x => x.Name == model.Name);
        foreach (var item in updateUserRole)
        {
            item.RoleId = getRole.Id;
        }
        user.UserRoles = updateUserRole;
        await _userRepository.Update(user);
        return new BaseResponse
        {
            Message = "User Role Updated Successfully",
            Status = true,
        };
    }
    public async Task<RoleResponseModel> GetById(int id)
    {
        var role = await _repository.Get(c => c.Id == id);
        if (role != null)
        {
            return new RoleResponseModel
            {
                Data = GetDetails(role),
                Message = "Role Retrieved Successfully",
                Status = true,
            };
        }
        return new RoleResponseModel
        {
            Message = "Role not found",
            Status = false,
        };
    }
    public async Task<RolesResponseModel> GetByUserId(int id)
    {
        var role = await _repository.GetRoleByUserId(id);
        if (role != null)
        {
            return new RolesResponseModel
            {
                Data = role.Select(x => GetDetails(x)).ToList(),
                Message = "Role Retrieved Successfully",
                Status = true,
            };
        }
        return new RolesResponseModel
        {
            Message = "Role not found",
            Status = false,
        };
    }
    public async Task<RolesResponseModel> GetAllRoles()
    {
        var role = await _repository.GetAllRoles();
        if (role != null)
        {
            return new RolesResponseModel()
            {
                Data = role.Select(x => GetDetails(x)).ToList(),
                Message = "Roles List Retrieved Successfully",
                Status = true
            };
        }
        return new RolesResponseModel ()
        {
            Data = null,
            Message = "Unable To Retrieve Roles List Successfully",
            Status = false,
        };
    }
    public GetRoleDto GetDetails(Role role)
    {
        return new GetRoleDto()
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
        };
    }
}
