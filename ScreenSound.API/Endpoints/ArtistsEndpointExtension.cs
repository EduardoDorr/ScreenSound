using Microsoft.AspNetCore.Mvc;

using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Repositories;

namespace ScreenSound.API.Endpoints;

public static class ArtistsEndpointExtension
{
    public static WebApplication AddArtistsEndpoints(this WebApplication app)
    {
        app.GetArtists();
        app.GetArtistsByName();
        app.PostArtist();
        app.UpdateArtist();
        app.DeleteArtist();

        return app;
    }

    private static void GetArtists(this WebApplication app) =>
        app.MapGet("/artists", (
            [FromServices] IGenericRepository<Artist> repository) =>
        {
            var artists = repository.GetAll();

            var artistsResponse = artists.ToModel();

            return Results.Ok(artistsResponse);
        });

    private static void GetArtistsByName(this WebApplication app) =>
        app.MapGet("/artists/{name}", (
            [FromServices] IGenericRepository<Artist> repository,
            string name) =>
        {
            var artist = repository.GetBy(a => string.Equals(a.Name, name, StringComparison.OrdinalIgnoreCase));

            if (artist is null)
                return Results.NotFound();

            var artistResponse = artist.ToModel();

            return Results.Ok(artistResponse);
        });

    private static void PostArtist(this WebApplication app) =>
        app.MapPost("/artists", (
            [FromServices] IGenericRepository<Artist> repository,
            [FromBody] ArtistRequest artistRequest) =>
        {
            var artist = new Artist(artistRequest.Name, artistRequest.Bio);

            repository.Add(artist);

            return Results.CreatedAtRoute(nameof(GetArtistsByName), new { name = artist.Name }, artistRequest);
        });

    private static void UpdateArtist(this WebApplication app) =>
        app.MapPut("/artists/{id}", (
            [FromServices] IGenericRepository<Artist> repository,
            int id,
            [FromBody] Artist artist) =>
        {
            artist.Id = id;

            repository.Update(artist);

            return Results.NoContent();
        });

    private static void DeleteArtist(this WebApplication app) =>
        app.MapDelete("/artists/{id}", (
            [FromServices] IGenericRepository<Artist> repository,
            int id) =>
        {
            repository.Delete(id);

            return Results.NoContent();
        });
}