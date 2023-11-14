using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;

namespace Vee_Tailoring.Controllers;

[Route("Vee_Tailoring/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    IEmailService _emailService;
    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }
    // POST : AddEmail
    [HttpPost("CreateEmail")]
    public async Task<IActionResult> CreateEmail([FromForm] CreateEmailDto createEmailDto)
    {
        var email = await _emailService.Create(createEmailDto);
        if (email.Status == true)
        {
            return Ok(email);
        }
        return BadRequest(email);
    }

    // GET : GetEmailById
    [HttpGet("GetEmailById")]
    public async Task<IActionResult> GetEmailById(int id)
    {
        var email = await _emailService.GetById(id);
        if (email.Status == true)
        {
            return Ok(email);
        }
        return BadRequest(email);
    }

    // GET : GetAllEmails
    [HttpGet("GetAllEmails")]
    public async Task<IActionResult> GetAllEmails()
    {
        var email = await _emailService.GetAllEmails();
        if (email.Status == true)
        {
            return Ok(email);
        }
        return BadRequest(email);
    }

    // GET : GetAllEmailByType
    [HttpGet("GetAllEmailByType")]
    public async Task<IActionResult> GetByEmailType(EmailType emailType)
    {
        var email = await _emailService.GetByEmailType(emailType);
        if (email.Status == true)
        {
            return Ok(email);
        }
        return BadRequest(email);
    }

    // GET : GetAllEmailByStaffId
    [HttpGet("GetAllEmailByStaffId")]
    public async Task<IActionResult> GetByStaffId(int id)
    {
        var email = await _emailService.GetByStaffId(id);
        if (email.Status == true)
        {
            return Ok(email);
        }
        return BadRequest(email);
    }

    // GET : GetAllEmailByEmailTypeStaffId
    [HttpGet("GetAllEmailByEmailTypeStaffId")]
    public async Task<IActionResult> GetByEmailTypeStaffId(int id, EmailType emailType)
    {
        var email = await _emailService.GetByStaffIdEmailType(id, emailType);
        if (email.Status == true)
        {
            return Ok(email);
        }
        return BadRequest(email);
    }
}
