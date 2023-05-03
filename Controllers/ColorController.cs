using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class ColorController : ControllerBase
{
    IColorService _colorService;
    public ColorController(IColorService colorService)
    {
        _colorService = colorService;
    }
    // POST : AddColor
    [HttpPost("CreateColor")]
    public async Task<IActionResult> CreateColor([FromForm] CreateColorDto createColorDto)
    {
        var color = await _colorService.Create(createColorDto);
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

    // PUT : UpdateColor
    [HttpPut("UpdateColor")]
    public async Task<IActionResult> UpdateColor(int id, [FromForm] UpdateColorDto updateColorDto)
    {
        var color = await _colorService.Update(id, updateColorDto);
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

    // GET : GetColorById
    [HttpGet("GetColorById")]
    public async Task<IActionResult> GetById(int id)
    {
        var color = await _colorService.GetById(id);
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

    // GET : GetColorByColorCode
    [HttpGet("GetColorByColorName")]
    public async Task<IActionResult> GetByColorName(string colorName)
    {
        var color = await _colorService.GetByColorName(colorName);
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

    // GET : GetColorByColorCode
    [HttpGet("GetColorByColorCode")]
    public async Task<IActionResult> GetByColorCode(string colorCode)
    {
        var color = await _colorService.GetByColorCode(colorCode);
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

    // GET : GetAllColors
    [HttpGet("GetAllColors")]
    public async Task<IActionResult> GetAllColors()
    {
        var color = await _colorService.GetAllColor();
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

    // GET : ColorsDashboard
    [HttpGet("ColorsDashBoard")]
    public async Task<IActionResult> ColorsDashBoard()
    {
        var color = await _colorService.ColorDashboard();
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

    // GET : GetAllColors
    [HttpPut("DeactivateColor")]
    public async Task<IActionResult> DeActivateColor(int id)
    {
        var color = await _colorService.DeActivateColor(id);
        if (color.Status == true)
        {
            return Ok(color);
        }
        return BadRequest(color);
    }

}
