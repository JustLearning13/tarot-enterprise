using Tarot.Domain.Entities;

namespace Tarot.Domain.Repositories;

public interface IDeckRepository
{
    Task<Deck?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Deck>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Deck deck, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
