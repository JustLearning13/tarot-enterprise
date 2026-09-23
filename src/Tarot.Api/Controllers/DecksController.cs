using Microsoft.AspNetCore.Mvc;
using Tarot.Application.Dtos;
using Tarot.Application.Services;

namespace Tarot.Api.Controllers;

[ApiController]
[Route("api/decks")]
public class DecksController : ControllerBase
{
    private readonly DeckService _deckService;

    public DecksController(DeckService deckService) => _deckService = deckService;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DeckDto>>> GetAllDecks(CancellationToken ct)
    {
        var decks = await _deckService.GetAllDecksAsync(ct);
        return Ok(decks);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DeckDto>> GetDeckById(int id, CancellationToken ct)
    {
        var deck = await _deckService.GetDeckByIdAsync(id, ct);
        return deck is null ? NotFound() : Ok(deck);
    }
}
