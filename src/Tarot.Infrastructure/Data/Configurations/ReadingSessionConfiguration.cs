using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarot.Domain.Entities;

namespace Tarot.Infrastructure.Data.Configurations;

public class ReadingSessionConfiguration : IEntityTypeConfiguration<ReadingSession>
{
    public void Configure(EntityTypeBuilder<ReadingSession> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Question).IsRequired().HasMaxLength(500);
        builder.Property(s => s.ViewerIntro).HasMaxLength(500);
        builder.Property(s => s.ReadingText).HasMaxLength(4000);
        builder.Property(s => s.Language).IsRequired().HasMaxLength(10);
        builder.Property(s => s.NarrationText).HasMaxLength(8000);
        builder.Property(s => s.CritiqueVerdict).HasConversion<string>().HasMaxLength(20);
        builder.Property(s => s.CritiqueNotes).HasMaxLength(4000);
        builder.Property(s => s.AudioRef).HasMaxLength(500);
        builder.Property(s => s.VideoRef).HasMaxLength(500);
        builder.Property(s => s.Status).HasConversion<string>().HasMaxLength(30);

        builder.HasOne(s => s.Card)
            .WithMany()
            .HasForeignKey(s => s.CardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.MusicTrack)
            .WithMany()
            .HasForeignKey(s => s.MusicTrackId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(s => s.CreatedAt);
    }
}
