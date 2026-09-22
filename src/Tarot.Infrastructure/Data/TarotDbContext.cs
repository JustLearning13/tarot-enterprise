using Microsoft.EntityFrameworkCore;
using Tarot.Domain.Entities;

namespace Tarot.Infrastructure.Data;

public class TarotDbContext : DbContext
{
    public TarotDbContext(DbContextOptions<TarotDbContext> options) : base(options) { }

    public DbSet<Deck> Decks => Set<Deck>();
    public DbSet<Card> Cards => Set<Card>();
    public DbSet<ReadingSession> ReadingSessions => Set<ReadingSession>();
    public DbSet<MusicTrack> MusicTracks => Set<MusicTrack>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(TarotDbContext).Assembly);
}
