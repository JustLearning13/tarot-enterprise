using Tarot.Domain.Enums;

namespace Tarot.Domain.Entities;

/// <summary>Central record: one row per generated video.</summary>
public class ReadingSession
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Question { get; set; } = string.Empty;
    public string? ViewerIntro { get; set; }

    public int? CardId { get; set; }
    public Card? Card { get; set; }

    public string? ReadingText { get; set; }
    public string Language { get; set; } = "en";
    public string? NarrationText { get; set; }

    public CritiqueVerdict? CritiqueVerdict { get; set; }
    public string? CritiqueNotes { get; set; }

    public string? AudioRef { get; set; }
    public string? VideoRef { get; set; }

    public int? MusicTrackId { get; set; }
    public MusicTrack? MusicTrack { get; set; }

    public ReadingSessionStatus Status { get; set; } = ReadingSessionStatus.QuestionSet;
}
