using Microsoft.EntityFrameworkCore;
using Tarot.Domain.Entities;
using Tarot.Domain.Repositories;

namespace Tarot.Infrastructure.Data.Repositories;

public class MusicTrackRepository : IMusicTrackRepository
{
    private readonly TarotDbContext _db;

    public MusicTrackRepository(TarotDbContext db) => _db = db;

    public Task<MusicTrack?> GetByIdAsync(int id, CancellationToken ct = default)
        => _db.MusicTracks.FirstOrDefaultAsync(t => t.Id == id, ct);

    public async Task<IReadOnlyList<MusicTrack>> GetAllAsync(CancellationToken ct = default)
        => await _db.MusicTracks.AsNoTracking().ToListAsync(ct);

    public async Task AddAsync(MusicTrack track, CancellationToken ct = default)
        => await _db.MusicTracks.AddAsync(track, ct);

    public Task SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);
}
