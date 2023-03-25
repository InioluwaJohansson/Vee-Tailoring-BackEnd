using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V_Tailoring.Implementations.Services;
using V_Tailoring.Interface.Services;
using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Controllers
{
    [Route("V_Tailoring/[controller]")]
    [ApiController]
    public class ArmTypeController : ControllerBase
    {
        IArmTypeService _armTypeService;
        public ArmTypeController(IArmTypeService armTypeService)
        {
            _armTypeService = armTypeService;
        }
        // POST : AddArmType
        [HttpPost("CreateArmType")]
        public async Task<IActionResult> CreateArmType([FromForm] CreateArmTypeDto createArmTypeDto)
        {
            var armType = await _armTypeService.Create(createArmTypeDto);
            if (armType.Status == true)
            {
                return Ok(armType);
            }
            return BadRequest(armType);
        }

        // PUT : UpdateArmType
        [HttpPut("UpdateArmType")]
        public async Task<IActionResult> UpdateArmType(int id, [FromForm] UpdateArmTypeDto updateArmTypeDto)
        {
            var armType = await _armTypeService.Update(id, updateArmTypeDto);
            if (armType.Status == true)
            {
                return Ok(armType);
            }
            return BadRequest(armType);
        }

        // GET : GetArmTypeById
        [HttpGet("GetArmTypeById")]
        public async Task<IActionResult> GetArmTypeById(int id)
        {
            var armType = await _armTypeService.GetById(id);
            if (armType.Status == true)
            {
                return Ok(armType);
            }
            return BadRequest(armType);
        }

        // GET : GetAllArmTypes
        [HttpGet("GetAllArmType")]
        public async Task<IActionResult> GetAllArmTypes()
        {
            var armType = await _armTypeService.GetAllArmType();
            if (armType.Status == true)
            {
                return Ok(armType);
            }
            return BadRequest(armType);
        }

        // GET : ArmTypesDashboard
        [HttpGet("ArmTypesDashBoard")]
        public async Task<IActionResult> ArmTypesDashBoard()
        {
            var armType = await _armTypeService.ArmTypeDashboard();
            if (armType.Status == true)
            {
                return Ok(armType);
            }
            return BadRequest(armType);
        }

        // GET : DeactivateArmTypes
        [HttpPut("DeActivateArmType")]
        public async Task<IActionResult> DeActivateArmType(int id)
        {
            var armType = await _armTypeService.DeActivateArmType(id);
            if (armType.Status == true)
            {
                return Ok(armType);
            }
            return BadRequest(armType);
        }
    }
}
