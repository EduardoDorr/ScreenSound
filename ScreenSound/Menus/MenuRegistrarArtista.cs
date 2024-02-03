using ScreenSound.Modelos;
using ScreenSound.Persistencias;

namespace ScreenSound.Menus;

public class MenuRegistrarArtista : Menu
{
    public override void Execute(IGenericRepository<Artista> artistRepository)
    {
        base.Execute(artistRepository);

        ExibirTituloDaOpcao("Registro dos Artistas");

        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;

        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;

        var artista = new Artista(nomeDoArtista, bioDoArtista);

        artistRepository.Add(artista);

        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
