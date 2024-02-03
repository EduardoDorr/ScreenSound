using ScreenSound.Modelos;
using ScreenSound.Persistencias;

namespace ScreenSound.Menus;

public class MenuMostrarArtistas : Menu
{
    public override void Execute(IGenericRepository<Artista> artistRepository)
    {
        base.Execute(artistRepository);

        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in artistRepository.GetAll())
            Console.WriteLine($"Artista: {artista}");

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}