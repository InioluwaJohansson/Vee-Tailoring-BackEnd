using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("Vee_Tailoring/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    // POST : AddRole
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole([FromForm] CreateRoleDto createRoleDto)
    {
        var role = await _roleService.Create(createRoleDto);
        if (role.Status == true)
        {
            return Ok(role);
        }
        return BadRequest(role);
    }

    // PUT : UpdateRole
    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole(int id, [FromForm] UpdateRoleDto updateRoleDto)
    {
        var role = await _roleService.Update(id, updateRoleDto);
        if (role.Status == true)
        {
            return Ok(role);
        }
        return BadRequest(role);
    }

    // GET : GetRoleById
    [HttpGet("GetRoleById")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _roleService.GetById(id);
        if (role.Status == true)
        {
            return Ok(role);
        }
        return BadRequest(role);
    }

    // GET : GetAllRoles
    [HttpGet("GetAllRoles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var role = await _roleService.GetAllRoles();
        if (role.Status == true)
        {
            return Ok(role);
        }
        return BadRequest(role);
    }
}
