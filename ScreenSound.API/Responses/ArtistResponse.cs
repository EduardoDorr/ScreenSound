using System.Collections.Immutable;

using ScreenSound.Domain.Entities;

namespace ScreenSound.API.Responses;

public sealed record ArtistResponse(string Name, string Bio, string ProfilePhoto, IReadOnlyList<MusicResponse> Musics);

public static class ArtistResponseExtension
{
    public static ArtistResponse ToModel(this Artist artist)
    {
        var musicsResponse = artist.Musics.ToModel().ToImmutableList();

        var artistResponse = new ArtistResponse(artist.Name, artist.Bio, artist.ProfilePhoto, musicsResponse);

        return artistResponse;
    }

    public static IEnumerable<ArtistResponse> ToModel(this IEnumerable<Artist> artists)
    {
        var artistsResponse = artists is not null
            ? artists.Select(a => a.ToModel()).ToList()
            : [];

        return artistsResponse;
    }
}