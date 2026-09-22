namespace Tarot.Domain.Enums;

/// <summary>Pipeline progress, in stage order (Requirements section 2).</summary>
public enum ReadingSessionStatus
{
    QuestionSet = 0,
    CardDrawn = 1,
    ReadingGenerated = 2,
    NarrationAssembled = 3,
    Translated = 4,
    AudioGenerated = 5,
    Transcribed = 6,
    VideoRendered = 7
}
