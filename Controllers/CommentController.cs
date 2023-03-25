using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V_Tailoring.Interface.Services;
using V_Tailoring.Models.DTOs;

namespace V_Tailoring.Controllers
{
    [Route("V_Tailoring/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // POST : AddComment
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment([FromForm] CreateCommentDto createCommentDto)
        {
            var comment = await _commentService.Create(createCommentDto);
            if (comment.Status == true)
            {
                return Ok(comment);
            }
            return BadRequest(comment);
        }

        // GET : GetCommentById
        [HttpGet("GetCommentById")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetById(id);
            if (comment.Status == true)
            {
                return Ok(comment);
            }
            return BadRequest(comment);
        }
        // GET : UpdateLikes
        [HttpPut("UpdateLikes")]
        public async Task<IActionResult> UpdateLikes(int id)
        {
            var comment = await _commentService.UpdateLikes(id);
            if (comment.Status == true)
            {
                return Ok(comment);
            }
            return BadRequest(comment);
        }
        // GET : DeActivateComment
        [HttpPut("DeActivateComment")]
        public async Task<IActionResult> DeActivateComment(int id)
        {
            var comment = await _commentService.DeActivateComment(id);
            if (comment.Status == true)
            {
                return Ok(comment);
            }
            return BadRequest(comment);
        }
    }
}
