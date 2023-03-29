using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class ComplaintController : ControllerBase
{
    IComplaintService _complaintService;
    public ComplaintController(IComplaintService complaintService)
    {
        _complaintService = complaintService;
    }
    // POST : AddComplaint
    [HttpPost("CreateComplaint")]
    public async Task<IActionResult> CreateComplaint([FromForm] CreateComplaintDto createComplaintDto)
    {
        var complaint = await _complaintService.Create(createComplaintDto);
        if (complaint.Status == true)
        {
            return Ok(complaint);
        }
        return BadRequest(complaint);
    }
    
    // GET : UpdateComplaint
    [HttpPut("UpdateComplaint")]
    public async Task<IActionResult> UpdateComplaint(int id)
    {
        var complaint = await _complaintService.Update(id);
        if (complaint.Status == true)
        {
            return Ok(complaint);
        }
        return BadRequest(complaint);
    }

    // GET : GetComplaintById
    [HttpGet("GetComplaintById")]
    public async Task<IActionResult> GetById(int id)
    {
        var complaint = await _complaintService.GetById(id);
        if (complaint.Status == true)
        {
            return Ok(complaint);
        }
        return BadRequest(complaint);
    }

    // GET : GetAllSolvedComplaints
    [HttpGet("GetAllSolvedComplaints")]
    public async Task<IActionResult> GetAllSolvedComplaints()
    {
        var complaint = await _complaintService.GetAllSolvedComplaints();
        if (complaint.Status == true)
        {
            return Ok(complaint);
        }
        return BadRequest(complaint);
    }

    // GET : GetAllSolvedComplaints
    [HttpGet("GetAllUnSolvedComplaints")]
    public async Task<IActionResult> GetAllUnSolvedComplaints()
    {
        var complaint = await _complaintService.GetAllUnSolvedComplaints();
        if (complaint.Status == true)
        {
            return Ok(complaint);
        }
        return BadRequest(complaint);
    }

    // GET : ComplaintssDashboard
    [HttpGet("ComplaintsDashBoard")]
    public async Task<IActionResult> ComplaintsDashBoard()
    {
        var complaint = await _complaintService.ComplaintsDashboard();
        if (complaint.Status == true)
        {
            return Ok(complaint);
        }
        return BadRequest(complaint);
    }

    // GET : GetAllComplaints
    [HttpGet("GetAllComplaints")]
    public async Task<IActionResult> GetAllComplaints()
    {
        var complaint = await _complaintService.GetAllComplaints();
        if (complaint.Status == true)
        {
            return Ok(complaint);
        }
        return BadRequest(complaint);
    }
}
