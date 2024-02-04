using ScreenSound.Domain.Entities;

namespace ScreenSound.API.Requests;

public sealed record GenreRequest(string Name, string? Description);

public static class GenreRequestExtension
{
    public static Genre FromModel(this GenreRequest genreRequest)
    {
        var genre = new Genre(genreRequest.Name, genreRequest.Description);

        return genre;
    }

    public static IEnumerable<Genre> FromModel(this IEnumerable<GenreRequest> genresRequest)
    {
        var genres = genresRequest is not null
            ? genresRequest.Select(g => g.FromModel()).ToList()
            : [];

        return genres;
    }
}