using System.Net.Http.Json;

using ScreenSound.Web.Responses;

namespace ScreenSound.Web.Services;

public class GenresService
{
    private readonly HttpClient _httpClient;

    public GenresService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<GenreResponse>?> GetGenresAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<GenreResponse>?>("genres");
    }

    public async Task<GenreResponse?> GetGenreByNameAsync(string name)
    {
        return await _httpClient.GetFromJsonAsync<GenreResponse?>($"genres/{name}");
    }
}