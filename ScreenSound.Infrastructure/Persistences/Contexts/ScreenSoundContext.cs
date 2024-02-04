using Microsoft.EntityFrameworkCore;

using ScreenSound.Domain.Entities;

namespace ScreenSound.Infrastructure.Persistences.Contexts;

public class ScreenSoundContext : DbContext
{
    private const string _connectionString = "Data Source=EDUARDO-PC;Initial Catalog=ScreenSound;User ID=sa;Password=Sequor123?;Trust Server Certificate=True;";

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(_connectionString)
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Music>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Musics);
    }
}