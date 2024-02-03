using ScreenSound.Modelos;
using ScreenSound.Persistencias;

namespace ScreenSound.Menus;

public class MenuMostrarMusicas : Menu
{
    public override void Execute(IGenericRepository<Artista> artistRepository)
    {
        base.Execute(artistRepository);

        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");

        string nomeDoArtista = Console.ReadLine()!;

        var artist = artistRepository.GetBy(a => a.Nome == nomeDoArtista);

        if (artist is not null)
        {
            Console.WriteLine("\nDiscografia:");
            artist.ExibirDiscografia();
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
