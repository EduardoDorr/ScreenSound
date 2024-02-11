namespace ScreenSound.Domain.Entities;

public class Artist : BaseEntity
{
    public string Name { get; private set; }
    public string Bio { get; private set; }
    public string ProfilePhoto { get; private set; }

    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();

    protected Artist() { }

    public Artist(string name, string bio)
    {
        Name = name;
        Bio = bio;
        ProfilePhoto = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public void AddProfilePhoto(string fileName)
    {
        ProfilePhoto = $"/images/profilePhotos/{fileName}";
    }

    public void AddMusic(Music music)
    {
        Musics.Add(music);
    }

    public void DisplayDiscography()
    {
        Console.WriteLine($"Discografia do artista {Name}");

        foreach (var musica in Musics)
            Console.WriteLine($"Música: {musica.Name} - Ano de Lançamento: {musica.PublishYear}");
    }

    public override string ToString()
    {
        return $@"Id: {Id}
                  Nome: {Name}
                  Foto de Perfil: {ProfilePhoto}
                  Bio: {Bio}";
    }
}