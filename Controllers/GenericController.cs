using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("Vee_Tailoring/[controller]")]
[ApiController]
public class GenericController : ControllerBase
{
    ITokenService _tokenService;
    public GenericController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }
    [HttpPost("RefreshTokens")]
    public async Task<IActionResult> RefreshTokens()
    {
        var token = await _tokenService.RefreshToken();
        return Ok(token);
    }
}
