using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class MaterialController : ControllerBase
{
    IMaterialService _materialService;
    public MaterialController(IMaterialService materialService)
    {
        _materialService = materialService;
    }
    // POST : AddMaterial
    [HttpPost("CreateMaterial")]
    public async Task<IActionResult> CreateMaterial([FromForm] CreateMaterialDto createMaterialDto)
    {
        var material = await _materialService.Create(createMaterialDto);
        if (material.Status == true)
        {
            return Ok(material);
        }
        return BadRequest(material);
    }

    // PUT : UpdateMaterial
    [HttpPut("UpdateMaterial")]
    public async Task<IActionResult> UpdateMaterial(int id, [FromForm] UpdateMaterialDto updateMaterialDto)
    {
        var material = await _materialService.Update(id, updateMaterialDto);
        if (material.Status == true)
        {
            return Ok(material);
        }
        return BadRequest(material);
    }

    // GET : GetMaterialById
    [HttpGet("GetMaterialById")]
    public async Task<IActionResult> GetById(int id)
    {
        var material = await _materialService.GetById(id);
        if (material.Status == true)
        {
            return Ok(material);
        }
        return BadRequest(material);
    }

    // GET : GetMaterialByMaterialCode
    [HttpGet("GetByMaterialName")]
    public async Task<IActionResult> GetByMaterialName(string materialName)
    {
        var material = await _materialService.GetByMaterialName(materialName);
        if (material.Status == true)
        {
            return Ok(material);
        }
        return BadRequest(material);
    }

    // GET : GetAllMaterials
    [HttpGet("GetAllMaterials")]
    public async Task<IActionResult> GetAllMaterials()
    {
        var material = await _materialService.GetAllMaterial();
        if (material.Status == true)
        {
            return Ok(material);
        }
        return BadRequest(material);
    }

    // GET : MaterialsDashboard
    [HttpGet("MaterialsDashBoard")]
    public async Task<IActionResult> MaterialsDashBoard()
    {
        var material = await _materialService.MaterialsDashboard();
        if (material.Status == true)
        {
            return Ok(material);
        }
        return BadRequest(material);
    }

    // GET : GetAllMaterials
    [HttpPut("DeActivateMaterial")]
    public async Task<IActionResult> DeActivateMaterial(int id)
    {
        var material = await _materialService.DeActivateMaterial(id);
        if (material.Status == true)
        {
            return Ok(material);
        }
        return BadRequest(material);
    }
}
