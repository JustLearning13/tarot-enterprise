using Tarot.Domain.Enums;

namespace Tarot.Domain.Entities;

public class Card
{
    public int Id { get; set; }
    public int DeckId { get; set; }
    public Deck Deck { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public Arcana Arcana { get; set; }
    public string UprightMeaning { get; set; } = string.Empty;
    public string ReversedMeaning { get; set; } = string.Empty;
    public string SceneDescription { get; set; } = string.Empty;
    public string ImageRef { get; set; } = string.Empty;
}
