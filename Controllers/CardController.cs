using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Controllers;

[Route("Vee_Tailoring/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    ICardService _CardService;
    public CardController(ICardService CardService)
    {
        _CardService = CardService;
    }
    // POST : AddCard
    [HttpPost("CreateCard")]
    public async Task<IActionResult> CreateCard([FromForm] CreateCardDto createCardDto)
    {
        var Card = await _CardService.Create(createCardDto);
        if (Card.Status == true)
        {
            return Ok(Card);
        }
        return BadRequest(Card);
    }

    // GET : GetCardById
    [HttpGet("GetCardById")]
    public async Task<IActionResult> GetCardByUserId(int id)
    {
        var Card = await _CardService.GetByUserId(id);
        if (Card.Status == true)
        {
            return Ok(Card);
        }
        return BadRequest(Card);
    }
    // GET : DeactivateCard
    [HttpPut("DeActivateCard")]
    public async Task<IActionResult> DeActivateCard(int id, int UserId)
    {
        var Card = await _CardService.DeActivateCard(id, UserId);
        if (Card.Status == true)
        {
            return Ok(Card);
        }
        return BadRequest(Card);
    }
}
