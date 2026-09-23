using Tarot.Application.Dtos;
using Tarot.Domain.Entities;
using Tarot.Domain.Repositories;

namespace Tarot.Application.Services;

public class DeckService
{
    private readonly IDeckRepository _deckRepository;

    public DeckService(IDeckRepository deckRepository) => _deckRepository = deckRepository;

    public async Task<IReadOnlyList<DeckDto>> GetAllDecksAsync(CancellationToken ct = default)
    {
        var decks = await _deckRepository.GetAllAsync(ct);
        return decks.Select(d => new DeckDto(d.Id, d.Name, d.StyleDescription)).ToList();
    }

    public async Task<DeckDto?> GetDeckByIdAsync(int id, CancellationToken ct = default)
    {
        var deck = await _deckRepository.GetByIdAsync(id, ct);
        return deck is null ? null : new DeckDto(deck.Id, deck.Name, deck.StyleDescription);
    }

    public async Task<DeckDto> CreateDeckAsync(CreateDeckRequest request, CancellationToken ct = default)
    {
        var deck = new Deck
        {
            Name = request.Name,
            StyleDescription = request.StyleDescription
        };

        await _deckRepository.AddAsync(deck, ct);
        await _deckRepository.SaveChangesAsync(ct);

        return new DeckDto(deck.Id, deck.Name, deck.StyleDescription);
    }
}
