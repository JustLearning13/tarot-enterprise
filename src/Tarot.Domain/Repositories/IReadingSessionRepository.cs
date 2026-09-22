using Tarot.Domain.Entities;

namespace Tarot.Domain.Repositories;

public interface IReadingSessionRepository
{
    Task<ReadingSession?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<ReadingSession>> GetRecentAsync(int count, CancellationToken ct = default);

    /// <summary>Recent questions, newest first. Feeds the question generator's anti-repetition prompt.</summary>
    Task<IReadOnlyList<string>> GetRecentQuestionsAsync(int count, CancellationToken ct = default);

    Task AddAsync(ReadingSession session, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
