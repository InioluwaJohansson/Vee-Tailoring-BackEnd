using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class DefaultPriceController : ControllerBase
{
    IDefaultPriceService _defaultPriceService;
    public DefaultPriceController(IDefaultPriceService defaultPriceService)
    {
        _defaultPriceService = defaultPriceService;
    }
    // POST : AddDefaultPrice
    [HttpPost("AddDefaultPrice")]
    public async Task<IActionResult> CreateDefaultPrice([FromForm] CreateDefaultPriceDto createDefaultPriceDto)
    {
        var defaultPrice = await _defaultPriceService.Create(createDefaultPriceDto);
        if (defaultPrice.Status == true)
        {
            return Ok(defaultPrice);
        }
        return BadRequest(defaultPrice);
    }

    // PUT : UpdateDefaultPrice
    [HttpPut("UpdateDefaultPrice")]
    public async Task<IActionResult> UpdateDefaultPrice(int id, [FromForm] UpdateDefaultPriceDto updateDefaultPriceDto)
    {
        var defaultPrice = await _defaultPriceService.Update(id, updateDefaultPriceDto);
        if (defaultPrice.Status == true)
        {
            return Ok(defaultPrice);
        }
        return BadRequest(defaultPrice);
    }

    // GET : GetDefaultPriceById
    [HttpGet("GetDefaultPriceById")]
    public async Task<IActionResult> GetById(int id)
    {
        var defaultPrice = await _defaultPriceService.GetById(id);
        if (defaultPrice.Status == true)
        {
            return Ok(defaultPrice);
        }
        return BadRequest(defaultPrice);
    }

    // GET : GetAllDefaultPrices
    [HttpGet("GetAllDefaultPrices")]
    public async Task<IActionResult> GetAllDefaultPrices()
    {
        var defaultPrice = await _defaultPriceService.GetAllDefaultPrices();
        if (defaultPrice.Status == true)
        {
            return Ok(defaultPrice);
        }
        return BadRequest(defaultPrice);
    }
}
