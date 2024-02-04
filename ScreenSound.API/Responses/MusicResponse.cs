using System.Collections.Immutable;

using ScreenSound.Domain.Entities;

namespace ScreenSound.API.Responses;

public sealed record MusicResponse(string Name, int PublishYear, string ArtistName, IReadOnlyList<GenreResponse> Genres);

public static class MusicResponseExtension
{
    public static MusicResponse ToModel(this Music music)
    {
        var genresResponse = music.Genres.ToModel().ToImmutableList();

        var musicResponse = new MusicResponse(music.Name, music.PublishYear, music.Artist.Name, genresResponse);

        return musicResponse;
    }

    public static IEnumerable<MusicResponse> ToModel(this IEnumerable<Music> musics)
    {
        var musicsResponse = musics is not null
            ? musics.Select(m => m.ToModel()).ToList()
            : [];

        return musicsResponse;
    }
}