using Microsoft.AspNetCore.Mvc;

using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Repositories;

namespace ScreenSound.API.Endpoints;

public static class GenresEndpointExtension
{
    public static WebApplication AddGenreEndpoints(this WebApplication app)
    {
        app.GetGenres();
        app.GetGenreByName();
        app.PostGenre();
        app.UpdateGenre();
        app.DeleteGenre();

        return app;
    }

    private static void GetGenres(this WebApplication app) =>
        app.MapGet("/genres", (
            [FromServices] IGenericRepository<Genre> repository) =>
        {
            var genres = repository.GetAll();

            var genresResponse = genres.ToModel();

            return Results.Ok(genresResponse);
        });

    private static void GetGenreByName(this WebApplication app) =>
        app.MapGet("/genres/{name}", (
            [FromServices] IGenericRepository<Genre> repository,
            string name) =>
        {
            var genre = repository.GetBy(a => string.Equals(a.Name, name, StringComparison.OrdinalIgnoreCase));

            if (genre is null)
                return Results.NotFound();

            var genreResponse = genre.ToModel();

            return Results.Ok(genreResponse);
        });

    private static void PostGenre(this WebApplication app) =>
        app.MapPost("/genres", (
            [FromServices] IGenericRepository<Genre> repository,
            [FromBody] GenreRequest genreRequest) =>
        {
            var genre = new Genre(genreRequest.Name, genreRequest.Description);

            repository.Add(genre);

            return Results.CreatedAtRoute(nameof(GetGenreByName), new { name = genre.Name }, genreRequest);
        });

    private static void UpdateGenre(this WebApplication app) =>
        app.MapPut("/genres/{id}", (
            [FromServices] IGenericRepository<Genre> repository,
            int id,
            [FromBody] Genre genre) =>
        {
            genre.Id = id;

            repository.Update(genre);

            return Results.NoContent();
        });

    private static void DeleteGenre(this WebApplication app) =>
        app.MapDelete("/genres/{id}", (
            [FromServices] IGenericRepository<Genre> repository,
            int id) =>
        {
            repository.Delete(id);

            return Results.NoContent();
        });
}