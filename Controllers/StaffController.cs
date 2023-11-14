using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("Vee_Tailoring/[controller]")]
[ApiController]
public class StaffController : Controller
{
    IStaffService _staffService;
    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }
    // POST : AddStaff
    
    [HttpPost("CreateStaff")]
    public async Task<IActionResult> CreateStaff([FromForm] CreateStaffDto createStaffDto)
    {
        var staff = await _staffService.Create(createStaffDto);
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }

    // PUT : UpdateStaff
    [HttpPut("UpdateStaff")]
    public async Task<IActionResult> UpdateStaff(int id, [FromForm] UpdateStaffDto updateStaffDto)
    {
        var staff = await _staffService.Update(id, updateStaffDto);
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }

    // GET : GetStaffById
    [HttpGet("GetStaffById")]
    public async Task<IActionResult> GetById(int id)
    {
        var staff = await _staffService.GetById(id);
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }

    // GET : GetStaffById
    [HttpGet("GetStaffByUserId")]
    public async Task<IActionResult> GetByUserId(int id)
    {
        var staff = await _staffService.GetByUserId(id);
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }

    // GET : GetStaffByStaffEmail
    [HttpGet("GetStaffByStaffEmail")]
    public async Task<IActionResult> GetByStaffEmail(string email)
    {
        var staff = await _staffService.GetByStaffEmail(email);
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }

    // GET : GetAllStaffs
    [HttpGet("GetAllStaffs")]
    public async Task<IActionResult> GetAllStaffs()
    {
        var staff = await _staffService.GetAllStaffs();
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }

    // GET : StaffDashboard
    [HttpGet("StaffDashBoard")]
    public async Task<IActionResult> StaffDashBoard()
    {
        var staff = await _staffService.StaffsDashboard();
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }

    // GET : StaffUserDashboard
    [HttpGet("StaffUserDashBoard")]
    public async Task<IActionResult> StaffUserDashBoard(int UserId)
    {
        var staff = await _staffService.UserDashboard(UserId);
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }
    // GET : DeleteStaff
    [HttpPut("DeActivateStaff")]
    public async Task<IActionResult> DeActivateStaff(int id)
    {
        var staff = await _staffService.DeActivateStaff(id);
        if (staff.Status == true)
        {
            return Ok(staff);
        }
        return BadRequest(staff);
    }
}
