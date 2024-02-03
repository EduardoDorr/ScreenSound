using Microsoft.EntityFrameworkCore;

using ScreenSound.Modelos;

namespace ScreenSound.Persistencias;

public class ScreenSoundContext : DbContext
{
    private const string _connectionString = "Data Source=EDUARDO-PC;Initial Catalog=ScreenSound;User ID=sa;Password=Sequor123?;Trust Server Certificate=True;";

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(_connectionString)
            .UseLazyLoadingProxies();
    }
}