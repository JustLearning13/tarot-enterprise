using Tarot.Domain.Entities;

namespace Tarot.Domain.Repositories;

public interface ICardRepository
{
    Task<Card?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Card>> GetByDeckAsync(int deckId, CancellationToken ct = default);
    Task<Card?> GetRandomAsync(int deckId, CancellationToken ct = default);
    Task AddRangeAsync(IEnumerable<Card> cards, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
