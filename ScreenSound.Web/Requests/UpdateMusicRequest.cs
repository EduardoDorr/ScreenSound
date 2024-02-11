namespace ScreenSound.Web.Requests;

public sealed record UpdateMusicRequest(string Name, int PublishYear, int ArtistId, ICollection<GenreRequest> Genres);