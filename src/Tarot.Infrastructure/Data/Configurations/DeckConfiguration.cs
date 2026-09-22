using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarot.Domain.Entities;

namespace Tarot.Infrastructure.Data.Configurations;

public class DeckConfiguration : IEntityTypeConfiguration<Deck>
{
    public void Configure(EntityTypeBuilder<Deck> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Property(d => d.StyleDescription).IsRequired().HasMaxLength(1000);

        builder.HasData(new Deck
        {
            Id = 1,
            Name = "Ukrainian collage",
            StyleDescription = "Fashion-editorial photo collage deck with color-blocked patterns and Ukrainian vyshyvanka embroidery motifs"
        });
    }
}
