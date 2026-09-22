using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarot.Domain.Entities;

namespace Tarot.Infrastructure.Data.Configurations;

public class MusicTrackConfiguration : IEntityTypeConfiguration<MusicTrack>
{
    public void Configure(EntityTypeBuilder<MusicTrack> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.FileRef).IsRequired().HasMaxLength(500);
        builder.Property(t => t.DisplayName).IsRequired().HasMaxLength(200);
        builder.Property(t => t.SourceTier).HasConversion<string>().HasMaxLength(20);
        builder.Property(t => t.LicenseNote).HasMaxLength(1000);
    }
}
