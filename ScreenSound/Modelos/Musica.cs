namespace ScreenSound.Modelos;

public class Musica : BaseEntity
{
    public string Nome { get; set; }
    public int AnoLancamento { get; set; }

    public virtual Artista? Artista { get; set; }

    public Musica(string nome)
    {
        Nome = nome;
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome} Ano de Lançamento: {AnoLancamento}");
    }

    public override string ToString()
    {
        return @$"Id: {Id}
                  Nome: {Nome}
                  Ano de Lançamento: {AnoLancamento}";
    }
}