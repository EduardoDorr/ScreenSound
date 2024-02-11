namespace ScreenSound.Web.Requests;

public sealed record CreateMusicRequest(string Name, int PublishYear, int ArtistId, ICollection<GenreRequest> Genres);