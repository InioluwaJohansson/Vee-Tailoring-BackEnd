using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vee_Tailoring.Authentication;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    IUserService _userService;
    IJWTAuthentication _auth;
    public UserController(IUserService userService, IJWTAuthentication auth)
    {
        _userService = userService;
        _auth = auth;
    }
    // POST : Login
    [HttpPost("Login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userService.Login(email, password);
        if (user.Status == true)
        {
            var token = _auth.GenerateToken(user.Data);
            var response = new UserLoginResponse()
            {
                Data = user.Data,
                Token = token,
                Status = user.Status,
                Message = user.Message
            };
            return Ok(response);
        }
        return BadRequest(user);
    }

    // GET : SendPasswordResetEmail
    [HttpGet("SendPasswordResetEmail")]
    public async Task<IActionResult> SendPasswordResetEmail(string email)
    {
        var user = await _userService.SendPasswordResetEmail(email);
        if (user.Status == true)
        {
            return Ok(user);
        }
        return BadRequest(user);
    }

    // GET : ChangePassword
    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromForm] UpdateUserPasswordDto updateUserPasswordDto)
    {
        var user = await _userService.ChangePassword(updateUserPasswordDto);
        if (user.Status == true)
        {
            return Ok(user);
        }
        return BadRequest(user);
    }
    // GET : GenerateReCAPCHA
    [HttpGet("GenerateReCAPCHA")]
    public async Task<IActionResult> GenerateReCAPCHA()
    {
        var user = await _userService.GenerateReCAPCHA();
        if (user.Status == true)
        {
            return Ok(user);
        }
        return BadRequest(user);
    }
}
