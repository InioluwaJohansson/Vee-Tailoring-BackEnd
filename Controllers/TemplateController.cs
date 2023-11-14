using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("Vee_Tailoring/[controller]")]
[ApiController]
public class TemplateController : ControllerBase
{
    ITemplateService _templateService;
    public TemplateController(ITemplateService templateService)
    {
        _templateService = templateService;
    }
    // POST : AddTemplate
    [HttpPost("CreateTemplate")]
    public async Task<IActionResult> CreateTemplate([FromForm] CreateTemplateDto createTemplateDto)
    {
        var template = await _templateService.Create(createTemplateDto);
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }

    // PUT : UpdateTemplate
    [HttpPut("UpdateTemplate")]
    public async Task<IActionResult> UpdateTemplate(int id, [FromForm] UpdateTemplateDto updateTemplateDto)
    {
        var template = await _templateService.Update(id, updateTemplateDto);
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }

    // GET : GetTemplateById
    [HttpGet("GetTemplateById")]
    public async Task<IActionResult> GetById(int id)
    {
        var template = await _templateService.GetById(id);
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }

    // GET : GetTemplateByTemplateName
    [HttpGet("GetByTemplateName")]
    public async Task<IActionResult> GetByTemplateName(string templateName)
    {
        var template = await _templateService.GetByTemplateName(templateName);
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }

    // GET : GetTemplateByCategory
    [HttpGet("GetTemplatesByClothCategory")]
    public async Task<IActionResult> GetTemplatesByClothCategory(int templateId)
    {
        var template = await _templateService.GetTemplatesByClothCategory(templateId);
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }
    // GET : GetTemplateByCategory
    [HttpGet("GetTemplatesByClothCategoryClothGender")]
    public async Task<IActionResult> GetTemplatesByClothCategoryClothgender(int clothCategory, int clothGender)
    {
        var template = await _templateService.GetTemplatesByClothCategoryClothGender(clothCategory, clothGender);
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }
    // GET : GetAllTemplates
    [HttpGet("GetAllTemplates")]
    public async Task<IActionResult> GetAllTemplates()
    {
        var template = await _templateService.GetAllTemplates();
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }

    // GET : TemplateDashboard
    [HttpGet("TemplateDashBoard")]
    public async Task<IActionResult> TemplateDashBoard()
    {
        var template = await _templateService.TemplatesDashboard();
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }

    // GET : DeActivateTemplate
    [HttpPut("DeActivateTemplate")]
    public async Task<IActionResult> DeActivateTemplate(int id)
    {
        var template = await _templateService.DeActivateTemplate(id);
        if (template.Status == true)
        {
            return Ok(template);
        }
        return BadRequest(template);
    }
}
