namespace ScreenSound.Web.Responses;

public sealed record ArtistResponse(int Id, string Name, string Bio, string? ProfilePhoto)
{
    public override string ToString()
    {
        return Name;
    }
}