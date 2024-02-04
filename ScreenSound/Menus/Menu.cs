using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Repositories;

namespace ScreenSound.Menus;

public class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');

        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    public virtual void Execute(IGenericRepository<Artist> artistRepository)
    {
        Console.Clear();
    }
}