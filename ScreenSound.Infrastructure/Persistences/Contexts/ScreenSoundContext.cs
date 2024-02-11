using Microsoft.EntityFrameworkCore;

using ScreenSound.Domain.Entities;

namespace ScreenSound.Infrastructure.Persistences.Contexts;

public class ScreenSoundContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public ScreenSoundContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Music>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Musics);
    }
}