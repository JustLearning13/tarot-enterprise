using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarot.Domain.Entities;

namespace Tarot.Infrastructure.Data.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Arcana).HasConversion<string>().HasMaxLength(20);
        builder.Property(c => c.UprightMeaning).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.ReversedMeaning).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.SceneDescription).IsRequired().HasMaxLength(2000);
        builder.Property(c => c.ImageRef).IsRequired().HasMaxLength(500);

        builder.HasOne(c => c.Deck)
            .WithMany(d => d.Cards)
            .HasForeignKey(c => c.DeckId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(c => new { c.DeckId, c.Name }).IsUnique();
    }
}
