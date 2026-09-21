using Microsoft.EntityFrameworkCore;
using Tarot.Domain.Entities;
using Tarot.Domain.Repositories;

namespace Tarot.Infrastructure.Data.Repositories;

public class DeckRepository : IDeckRepository
{
    private readonly TarotDbContext _db;

    public DeckRepository(TarotDbContext db) => _db = db;

    public Task<Deck?> GetByIdAsync(int id, CancellationToken ct = default)
        => _db.Decks.FirstOrDefaultAsync(d => d.Id == id, ct);

    public async Task<IReadOnlyList<Deck>> GetAllAsync(CancellationToken ct = default)
        => await _db.Decks.AsNoTracking().ToListAsync(ct);

    public async Task AddAsync(Deck deck, CancellationToken ct = default)
        => await _db.Decks.AddAsync(deck, ct);

    public Task SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);
}
