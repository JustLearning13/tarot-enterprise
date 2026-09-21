using Microsoft.EntityFrameworkCore;
using Tarot.Domain.Entities;
using Tarot.Domain.Repositories;

namespace Tarot.Infrastructure.Data.Repositories;

public class ReadingSessionRepository : IReadingSessionRepository
{
    private readonly TarotDbContext _db;

    public ReadingSessionRepository(TarotDbContext db) => _db = db;

    public Task<ReadingSession?> GetByIdAsync(int id, CancellationToken ct = default)
        => _db.ReadingSessions
            .Include(s => s.Card)
            .Include(s => s.MusicTrack)
            .FirstOrDefaultAsync(s => s.Id == id, ct);

    public async Task<IReadOnlyList<ReadingSession>> GetRecentAsync(int count, CancellationToken ct = default)
        => await _db.ReadingSessions.AsNoTracking()
            .OrderByDescending(s => s.CreatedAt)
            .Take(count)
            .ToListAsync(ct);

    public async Task<IReadOnlyList<string>> GetRecentQuestionsAsync(int count, CancellationToken ct = default)
        => await _db.ReadingSessions.AsNoTracking()
            .OrderByDescending(s => s.CreatedAt)
            .Take(count)
            .Select(s => s.Question)
            .ToListAsync(ct);

    public async Task AddAsync(ReadingSession session, CancellationToken ct = default)
        => await _db.ReadingSessions.AddAsync(session, ct);

    public Task SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);
}
