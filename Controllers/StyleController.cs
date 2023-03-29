using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class StyleController : ControllerBase
{
    IStyleService _styleService;
    public StyleController(IStyleService styleService)
    {
        _styleService = styleService;
    }
    // POST : AddStyle
    [HttpPost("CreateStyle")]
    public async Task<IActionResult> CreateStyle([FromForm] CreateStyleDto createStyleDto)
    {
        var style = await _styleService.Create(createStyleDto);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // PUT : UpdateStyle
    [HttpPut("UpdateStyle")]
    public async Task<IActionResult> UpdateStyle(int id, [FromForm] UpdateStyleDto updateStyleDto)
    {
        var style = await _styleService.Update(id, updateStyleDto);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : GetStyleById
    [HttpGet("GetStyleById")]
    public async Task<IActionResult> GetById(int id)
    {
        var style = await _styleService.GetById(id);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : GetStyleByStyleCode
    [HttpGet("GetStyleByStyleName")]
    public async Task<IActionResult> GetByStyleName(string styleName)
    {
        var style = await _styleService.GetByStyleName(styleName);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : GetStyleByClothCategory
    [HttpGet("GetStylesByClothCategory")]
    public async Task<IActionResult> GetStylesByClothCategory(int clothCategory)
    {
        var style = await _styleService.GetStylesByClothCategory(clothCategory);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : GetStylesByClothCategoryClothGender
    [HttpGet("GetStylesByClothCategoryClothGender")]
    public async Task<IActionResult> GetStylesByClothCategoryClothGender(int clothCategory, int clothGender)
    {
        var style = await _styleService.GetStylesByClothCategoryClothGender(clothCategory, clothGender);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : GetStylesByClothCategoryClothGender
    [HttpGet("GetStylesByPrice")]
    public async Task<IActionResult> GetStylesByPrice(decimal price)
    {
        var style = await _styleService.GetStylesByPrice(price);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : GetAllStyles
    [HttpGet("GetAllStyles")]
    public async Task<IActionResult> GetAllStyles()
    {
        var style = await _styleService.GetAllStyles();
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : StylesDashboard
    [HttpGet("StylesDashBoard")]
    public async Task<IActionResult> StylesDashBoard()
    {
        var style = await _styleService.StylesDashboard();
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }

    // GET : GetAllStyles
    [HttpPut("DeActivateStyle")]
    public async Task<IActionResult> DeActivateStyle(int id)
    {
        var style = await _styleService.DeActivateStyle(id);
        if (style.Status == true)
        {
            return Ok(style);
        }
        return BadRequest(style);
    }
}
