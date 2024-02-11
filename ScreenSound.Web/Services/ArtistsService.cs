using System.Net.Http.Json;
using ScreenSound.Web.Requests;
using ScreenSound.Web.Responses;

namespace ScreenSound.Web.Services;

public class ArtistsService
{
    private readonly HttpClient _httpClient;

    public ArtistsService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<ArtistResponse>?> GetArtistsAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<ArtistResponse>?>("artists");
    }

    public async Task<ArtistResponse?> GetArtistByNameAsync(string name)
    {
        return await _httpClient.GetFromJsonAsync<ArtistResponse?>($"artists/{name}");
    }

    public async Task AddArtistAsync(CreateArtistRequest request)
    {
        await _httpClient.PostAsJsonAsync("artists", request);
    }

    public async Task UpdateArtistAsync(int id, UpdateArtistRequest request)
    {
        await _httpClient.PutAsJsonAsync($"artists/{id}", request);
    }

    public async Task DeleteArtistAsync(int id)
    {
        await _httpClient.DeleteAsync($"artists/{id}");
    }
}