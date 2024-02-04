using Microsoft.AspNetCore.Mvc;

using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Repositories;

namespace ScreenSound.API.Endpoints;

public static class MusicsEndpointExtension
{
    public static WebApplication AddMusicsEndpoints(this WebApplication app)
    {
        app.GetMusics();
        app.GetMusicByName();
        app.PostMusic();
        app.UpdateMusic();
        app.DeleteMusic();

        return app;
    }

    private static void GetMusics(this WebApplication app) =>
        app.MapGet("/musics", (
            [FromServices] IGenericRepository<Music> repository) =>
        {
            var musics = repository.GetAll();

            var musicsResponse = musics.ToModel();

            return Results.Ok(musicsResponse);
        });

    private static void GetMusicByName(this WebApplication app) =>
        app.MapGet("/musics/{name}", (
            [FromServices] IGenericRepository<Music> repository,
            string name) =>
        {
            var music = repository.GetBy(a => string.Equals(a.Name, name, StringComparison.OrdinalIgnoreCase));

            if (music is null)
                return Results.NotFound();

            var musicResponse = music.ToModel();

            return Results.Ok(musicResponse);
        });

    private static void PostMusic(this WebApplication app) =>
        app.MapPost("/musics", (
            [FromServices] IGenericRepository<Music> musicRepository,
            [FromServices] IGenericRepository<Artist> artistRepository,
            [FromServices] IGenericRepository<Genre> genreRepository,
            [FromBody] MusicRequest musicRequest) =>
        {
            var artist = artistRepository.GetById(musicRequest.ArtistId);

            if (artist is null)
                return Results.NotFound("Artist not found");

            var allGenres = genreRepository.GetAll();

            var genres = CompareGenresFromDatabase(allGenres, musicRequest.Genres);

            var music = new Music(musicRequest.Name, musicRequest.PublishYear)
            {
                Artist = artist,
                Genres = genres
            };

            musicRepository.Add(music);

            return Results.Ok(musicRequest);
        });   

    private static void UpdateMusic(this WebApplication app) =>
        app.MapPut("/musics/{id}", (
            [FromServices] IGenericRepository<Music> repository,
            int id,
            [FromBody] Music music) =>
        {
            music.Id = id;

            repository.Update(music);

            return Results.NoContent();
        });

    private static void DeleteMusic(this WebApplication app) =>
        app.MapDelete("/musics/{id}", (
            [FromServices] IGenericRepository<Music> repository,
            int id) =>
        {
            repository.Delete(id);

            return Results.NoContent();
        });

    private static ICollection<Genre> CompareGenresFromDatabase(IEnumerable<Genre> genresFromDatabase, IEnumerable<GenreRequest> genresFromRequest)
    {
        var genres = new List<Genre>();

        foreach (var genre in genresFromRequest)
        {
            if (genresFromDatabase.Any(g => g.Name.ToUpperInvariant().Equals(genre.Name.ToUpperInvariant())))
                genres.Add(
                    genresFromDatabase.FirstOrDefault(
                        g =>
                        g.Name.ToUpperInvariant().Equals(genre.Name.ToUpperInvariant())));
            else
                genres.Add(genre.FromModel());
        }

        return genres;
    }
}