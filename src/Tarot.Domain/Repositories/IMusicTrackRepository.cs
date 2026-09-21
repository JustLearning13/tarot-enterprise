using Tarot.Domain.Entities;

namespace Tarot.Domain.Repositories;

public interface IMusicTrackRepository
{
    Task<MusicTrack?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<MusicTrack>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(MusicTrack track, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
