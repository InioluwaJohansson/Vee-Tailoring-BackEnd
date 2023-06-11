using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("V_Tailoring/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    IPostService _postService;
    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    // POST : AddPost
    [HttpPost("CreatePost")]
    public async Task<IActionResult> CreatePost([FromForm] CreatePostDto createPostDto)
    {
        var post = await _postService.Create(createPostDto);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // PUT : UpdatePost
    [HttpPut("UpdatePost")]
    public async Task<IActionResult> UpdatePost(int id, [FromForm] UpdatePostDto updatePostDto)
    {
        var post = await _postService.Update(id, updatePostDto);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // GET : GetPostById
    [HttpPut("UpdateLikes")]
    public async Task<IActionResult> UpdateLikes(int id)
    {
        var post = await _postService.UpdateLikes(id);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // GET : ApproveDisApprovePost
    [HttpPut("ApproveDisApprovePost")]
    public async Task<IActionResult> ApproveDisApprovePost(int id, int UserId)
    {
        var post = await _postService.ApproveDisApprovePost(id, UserId);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // GET : GetPostById
    [HttpGet("GetPostById")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _postService.GetById(id);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // GET : GetPostByPostTitle
    [HttpGet("GetPostByPostTitle")]
    public async Task<IActionResult> GetByPostTitle(string postName)
    {
        var post = await _postService.GetByPostTitle(postName);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // GET : GetPostByCategory
    [HttpGet("GetPostByCategory")]
    public async Task<IActionResult> GetPostByCategory(int postCode)
    {
        var post = await _postService.GetByCategoryId(postCode);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // GET : GetAllPosts
    [HttpGet("GetAllPosts")]
    public async Task<IActionResult> GetAllPosts()
    {
        var post = await _postService.GetAllPosts();
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }
    // GET : PostsDashboard
    [HttpPost("PostsDashBoard")]
    public async Task<IActionResult> PostsDashBoard()
    {
        var post = await _postService.PostsDashboard();
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

    // GET : GetAllPosts
    [HttpPost("DeactivatePost")]
    public async Task<IActionResult> DeActivatePost(int id)
    {
        var post = await _postService.DeActivatePost(id);
        if (post.Status == true)
        {
            return Ok(post);
        }
        return BadRequest(post);
    }

}
