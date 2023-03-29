using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interface.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    // POST : AddCategory
    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDto createCategoryDto)
    {
        var category = await _categoryService.Create(createCategoryDto);
        if (category.Status == true)
        {
            return Ok(category);
        }
        return BadRequest(category);
    }

    // PUT : UpdateCategory
    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(int id, [FromForm] UpdateCategoryDto updateCategoryDto)
    {
        var category = await _categoryService.Update(id, updateCategoryDto);
        if (category.Status == true)
        {
            return Ok(category);
        }
        return BadRequest(category);
    }

    // GET : GetCategoryById
    [HttpGet("GetCategoryById")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryService.GetById(id);
        if (category.Status == true)
        {
            return Ok(category);
        }
        return BadRequest(category);
    }

    // GET : GetAllCategorys
    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAllCategorys()
    {
        var category = await _categoryService.GetAllCategory();
        if (category.Status == true)
        {
            return Ok(category);
        }
        return BadRequest(category);
    }

    // GET : CategoriesDashboard
    [HttpGet("CategoryDashBoard")]
    public async Task<IActionResult> CategoryDashBoard()
    {
        var category = await _categoryService.CategoryDashboard();
        if (category.Status == true)
        {
            return Ok(category);
        }
        return BadRequest(category);
    }

    // PUT : DeActivateCategory
    [HttpPut("DeActivateCategory")]
    public async Task<IActionResult> DeActivateCategory(int id)
    {
        var category = await _categoryService.DeActivateCategory(id);
        if (category.Status == true)
        {
            return Ok(category);
        }
        return BadRequest(category);
    }
}
