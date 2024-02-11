using ScreenSound.Domain.Entities;

namespace ScreenSound.API.Responses;

public sealed record GenreResponse(int Id, string Name, string Description);

public static class GenreResponseExtension
{
    public static GenreResponse ToModel(this Genre genre)
    {
        var genreResponse = new GenreResponse(genre.Id, genre.Name, genre.Description);

        return genreResponse;
    }

    public static IEnumerable<GenreResponse> ToModel(this IEnumerable<Genre> genres)
    {
        var genresResponse = genres is not null
            ? genres.Select(g => g.ToModel()).ToList()
            : [];

        return genresResponse;
    }
}