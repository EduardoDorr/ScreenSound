namespace ScreenSound.Domain.Entities;

public class Genre : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();

    protected Genre() { }

    public Genre(string? name, string? description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"Nome: {Name} - Descrição: {Description}";
    }
}