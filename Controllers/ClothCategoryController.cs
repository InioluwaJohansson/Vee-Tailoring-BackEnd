using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V_Tailoring.Implementations.Services;
using V_Tailoring.Interface.Services;
using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Controllers
{
    [Route("V_Tailoring/[controller]")]
    [ApiController]
    public class ClothCategoryController : ControllerBase
    {
        IClothCategoryService _clothCategoryService;
        public ClothCategoryController(IClothCategoryService clothCategoryService)
        {
            _clothCategoryService = clothCategoryService;
        }
        // POST : AddClothCategory
        [HttpPost("CreateClothCategory")]
        public async Task<IActionResult> CreateClothCategory([FromForm] CreateClothCategoryDto createClothCategoryDto)
        {
            var clothCategory = await _clothCategoryService.Create(createClothCategoryDto);
            if (clothCategory.Status == true)
            {
                return Ok(clothCategory);
            }
            return BadRequest(clothCategory);
        }

        // PUT : UpdateClothCategory
        [HttpPut("UpdateClothCategory")]
        public async Task<IActionResult> UpdateClothCategory(int id, [FromForm] UpdateClothCategoryDto updateClothCategoryDto)
        {
            var clothCategory = await _clothCategoryService.Update(id, updateClothCategoryDto);
            if (clothCategory.Status == true)
            {
                return Ok(clothCategory);
            }
            return BadRequest(clothCategory);
        }

        // GET : GetClothCategoryById
        [HttpGet("GetClothCategoryById")]
        public async Task<IActionResult> GetById(int id)
        {
            var clothCategory = await _clothCategoryService.GetById(id);
            if (clothCategory.Status == true)
            {
                return Ok(clothCategory);
            }
            return BadRequest(clothCategory);
        }

        // GET : GetAllClothCategorys
        [HttpGet("GetAllClothCategories")]
        public async Task<IActionResult> GetAllClothCategorys()
        {
            var clothCategory = await _clothCategoryService.GetAllClothCategory();
            if (clothCategory.Status == true)
            {
                return Ok(clothCategory);
            }
            return BadRequest(clothCategory);
        }

        // GET : ClothCategoryDashboard
        [HttpGet("ColthCategoryDashBoard")]
        public async Task<IActionResult> ClothCategoryDashBoard()
        {
            var clothCategory = await _clothCategoryService.ClothCategoryDashboard();
            if (clothCategory.Status == true)
            {
                return Ok(clothCategory);
            }
            return BadRequest(clothCategory);
        }

        // GET : GetAllClothCategorys
        [HttpPut("GetDeActivateClothCategory")]
        public async Task<IActionResult> DeActivateClothCategory(int id)
        {
            var clothCategory = await _clothCategoryService.DeActivateClothCategory(id);
            if (clothCategory.Status == true)
            {
                return Ok(clothCategory);
            }
            return BadRequest(clothCategory);
        }
    }
}
