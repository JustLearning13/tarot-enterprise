namespace Tarot.Domain.Enums;

/// <summary>
/// Licensing tier active when the track was generated. Free-tier Suno output stays
/// non-commercial even after upgrading, so this is recorded per track.
/// </summary>
public enum MusicSourceTier
{
    SunoFree = 0,
    SunoPaid = 1,
    AudioLibrary = 2
}
