using ScreenSound.Modelos;
using ScreenSound.Persistencias;

namespace ScreenSound.Menus;

public class MenuSair : Menu
{
    public override void Execute(IGenericRepository<Artista> artistRepository)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
