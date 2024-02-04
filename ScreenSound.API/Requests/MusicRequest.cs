namespace ScreenSound.API.Requests;

public sealed record MusicRequest(string Name, int PublishYear, int ArtistId, ICollection<GenreRequest> Genres);