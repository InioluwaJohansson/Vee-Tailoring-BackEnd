using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using V_Tailoring.Implementations.Services;
using V_Tailoring.Interface.Services;
using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Controllers
{
    [Route("V_Tailoring/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        ICollectionService _CollectionService;
        public CollectionController(ICollectionService CollectionService)
        {
            _CollectionService = CollectionService;
        }
        // POST : AddCollection
        [HttpPost("CreateCollection")]
        public async Task<IActionResult> CreateCollection([FromForm] CreateCollectionDto createCollectionDto)
        {
            var Collection = await _CollectionService.Create(createCollectionDto);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }

        // PUT : UpdateCollection
        [HttpPut("UpdateCollection")]
        public async Task<IActionResult> UpdateCollection(int id, [FromForm] UpdateCollectionDto updateCollectionDto)
        {
            var Collection = await _CollectionService.Update(id, updateCollectionDto);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }

        // GET : GetCollectionById
        [HttpGet("GetCollectionById")]
        public async Task<IActionResult> GetById(int id)
        {
            var Collection = await _CollectionService.GetById(id);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }
        // PUT : BuyCollection
        [HttpPut("BuyCollection")]
        public async Task<IActionResult> BuyCollection(int id, int customerId)
        {
            var Collection = await _CollectionService.BuyCollection(id, customerId);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }

        // GET : GetCollectionByCollectionName
        [HttpGet("GetByCollectionName")]
        public async Task<IActionResult> GetByCollectionName(string CollectionName)
        {
            var Collection = await _CollectionService.GetByCollectionName(CollectionName);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }

        // GET : GetCollectionByCategory
        [HttpGet("GetCollectionsByClothCategory")]
        public async Task<IActionResult> GetCollectionsByClothCategory(int ClothCategory)
        {
            var Collection = await _CollectionService.GetCollectionsByClothCategory(ClothCategory);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }
        // GET : GetCollectionByCategory
        [HttpGet("GetCollectionsByClothCategoryClothGender")]
        public async Task<IActionResult> GetCollectionsByClothCategoryClothgender(int clothCategory, int clothGender)
        {
            var Collection = await _CollectionService.GetCollectionsByClothCategoryClothGender(clothCategory, clothGender);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }
        // GET : GetAllCollections
        [HttpGet("GetAllCollections")]
        public async Task<IActionResult> GetAllCollections()
        {
            var Collection = await _CollectionService.GetAllCollections();
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }

        // GET : CollectionDashboard
        [HttpGet("CollectionDashBoard")]
        public async Task<IActionResult> CollectionDashBoard()
        {
            var Collection = await _CollectionService.CollectionsDashboard();
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }

        // GET : DeActivateCollection
        [HttpPut("DeActivateCollection")]
        public async Task<IActionResult> DeActivateCollection(int id)
        {
            var Collection = await _CollectionService.DeActivateCollection(id);
            if (Collection.Status == true)
            {
                return Ok(Collection);
            }
            return BadRequest(Collection);
        }
    }
}
