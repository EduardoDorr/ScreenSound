namespace ScreenSound.Web.Responses;

public sealed record MusicResponse(int Id, string Name, int PublishYear, string ArtistName, IReadOnlyList<GenreResponse> Genres);