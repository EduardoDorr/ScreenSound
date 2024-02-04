namespace ScreenSound.Domain.Entities;

public class Music : BaseEntity
{
    public string Name { get; set; }
    public int PublishYear { get; set; }

    public virtual Artist? Artist { get; set; }
    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    protected Music() { }

    public Music(string name, int publishYear)
    {
        Name = name;
        PublishYear = publishYear;
    }

    public void DisplayDatasheet()
    {
        Console.WriteLine($"Nome: {Name} Ano de Lançamento: {PublishYear}");
    }

    public override string ToString()
    {
        return @$"Id: {Id}
                  Nome: {Name}
                  Ano de Lançamento: {PublishYear}";
    }
}