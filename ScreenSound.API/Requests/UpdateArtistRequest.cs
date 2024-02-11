namespace ScreenSound.API.Requests;

public sealed record UpdateArtistRequest(int Id, string Name, string Bio, string? ProfilePhoto);