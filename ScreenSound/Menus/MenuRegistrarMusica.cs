using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Repositories;

namespace ScreenSound.Menus;

public class MenuRegistrarMusica : Menu
{
    public override void Execute(IGenericRepository<Artist> artistRepository)
    {
        base.Execute(artistRepository);

        ExibirTituloDaOpcao("Registro de músicas");

        Console.Write("Digite o artista cuja música deseja registrar: ");
        var nomeDoArtista = Console.ReadLine()!;

        var artist = artistRepository.GetBy(a => a.Name == nomeDoArtista);

        if (artist is not null)
        {
            Console.Write("Agora digite o título da música: ");
            var tituloDaMusica = Console.ReadLine()!;

            Console.Write("Agora digite o título da música: ");
            var anoLancamento = Console.ReadLine()!;

            artist.AddMusic(new Music(tituloDaMusica, Convert.ToInt32(anoLancamento)));

            artistRepository.Update(artist);

            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            Thread.Sleep(4000);
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
