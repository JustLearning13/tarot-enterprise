using Microsoft.EntityFrameworkCore;
using Tarot.Domain.Entities;
using Tarot.Domain.Repositories;

namespace Tarot.Infrastructure.Data.Repositories;

public class CardRepository : ICardRepository
{
    private readonly TarotDbContext _db;

    public CardRepository(TarotDbContext db) => _db = db;

    public Task<Card?> GetByIdAsync(int id, CancellationToken ct = default)
        => _db.Cards.FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task<IReadOnlyList<Card>> GetByDeckAsync(int deckId, CancellationToken ct = default)
        => await _db.Cards.AsNoTracking().Where(c => c.DeckId == deckId).OrderBy(c => c.Id).ToListAsync(ct);

    public Task<Card?> GetRandomAsync(int deckId, CancellationToken ct = default)
        => _db.Cards.AsNoTracking()
            .Where(c => c.DeckId == deckId)
            .OrderBy(_ => Guid.NewGuid())
            .FirstOrDefaultAsync(ct);

    public Task AddRangeAsync(IEnumerable<Card> cards, CancellationToken ct = default)
        => _db.Cards.AddRangeAsync(cards, ct);

    public Task SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);
}
