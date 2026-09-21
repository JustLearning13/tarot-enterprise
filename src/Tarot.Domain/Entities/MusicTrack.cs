using Tarot.Domain.Enums;

namespace Tarot.Domain.Entities;

public class MusicTrack
{
    public int Id { get; set; }
    public string FileRef { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public MusicSourceTier SourceTier { get; set; }
    public string? LicenseNote { get; set; }
}
