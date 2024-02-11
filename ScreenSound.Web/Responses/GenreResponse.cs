namespace ScreenSound.Web.Responses;

public sealed record GenreResponse(int Id, string Name, string Description)
{
    public override string ToString()
    {
        return Name;
    }
}