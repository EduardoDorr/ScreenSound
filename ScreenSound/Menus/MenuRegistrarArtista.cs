using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Repositories;

namespace ScreenSound.Menus;

public class MenuRegistrarArtista : Menu
{
    public override void Execute(IGenericRepository<Artist> artistRepository)
    {
        base.Execute(artistRepository);

        ExibirTituloDaOpcao("Registro dos Artistas");

        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;

        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;

        var artista = new Artist(nomeDoArtista, bioDoArtista);

        artistRepository.Add(artista);

        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
