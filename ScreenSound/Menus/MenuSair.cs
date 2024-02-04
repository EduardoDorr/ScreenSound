using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Repositories;

namespace ScreenSound.Menus;

public class MenuSair : Menu
{
    public override void Execute(IGenericRepository<Artist> artistRepository)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
