using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("Vee_Tailoring/[controller]")]
[ApiController]
public class PatternController : ControllerBase
{
    private readonly IPatternService _patternService;
    public PatternController(IPatternService patternService)
    {
        _patternService = patternService;
    }
    // POST : AddPattern
    [HttpPost("CreatePattern")]
    public async Task<IActionResult> CreatePattern([FromForm] CreatePatternDto createPatternDto)
    {
        var pattern = await _patternService.Create(createPatternDto);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // PUT : UpdatePattern
    [HttpPut("UpdatePattern")]
    public async Task<IActionResult> UpdatePattern(int id, [FromForm] UpdatePatternDto updatePatternDto)
    {
        var pattern = await _patternService.Update(id, updatePatternDto);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : GetPatternById
    [HttpGet("GetPatternById")]
    public async Task<IActionResult> GetById(int id)
    {
        var pattern = await _patternService.GetById(id);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : GetPatternByPatternCode
    [HttpGet("GetPatternByPatternName")]
    public async Task<IActionResult> GetByPatternName(string patternName)
    {
        var pattern = await _patternService.GetByPatternName(patternName);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : GetPatternByClothCategory
    [HttpGet("GetPatternsByClothCategory")]
    public async Task<IActionResult> GetPatternsByClothCategory(int clothCategory)
    {
        var pattern = await _patternService.GetByClothCategory(clothCategory);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : GetPatternsByClothCategoryClothGender
    [HttpGet("GetPatternsByClothCategoryClothGender")]
    public async Task<IActionResult> GetPatternsByClothCategoryClothGender(int clothCategory, int clothGender)
    {
        var pattern = await _patternService.GetByClothCategoryClothGender(clothCategory, clothGender);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : GetPatternsByClothCategoryClothGender
    [HttpGet("GetPatternsByPrice")]
    public async Task<IActionResult> GetPatternsByPrice(decimal price)
    {
        var pattern = await _patternService.GetPatternByPrice(price);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : GetAllPatterns
    [HttpGet("GetAllPatterns")]
    public async Task<IActionResult> GetAllPatterns()
    {
        var pattern = await _patternService.GetAllPattern();
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : PatternsDashboard
    [HttpGet("PatternsDashBoard")]
    public async Task<IActionResult> PatternsDashBoard()
    {
        var pattern = await _patternService.PatternsDashboard();
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }

    // GET : GetAllPatterns
    [HttpPut("DeActivatePattern")]
    public async Task<IActionResult> DeActivatePattern(int id)
    {
        var pattern = await _patternService.DeActivatePattern(id);
        if (pattern.Status == true)
        {
            return Ok(pattern);
        }
        return BadRequest(pattern);
    }
}
