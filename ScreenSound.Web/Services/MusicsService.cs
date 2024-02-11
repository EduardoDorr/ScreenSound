using System.Net.Http.Json;

using ScreenSound.Web.Requests;
using ScreenSound.Web.Responses;

namespace ScreenSound.Web.Services;

public class MusicsService
{
    private readonly HttpClient _httpClient;

    public MusicsService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<MusicResponse>?> GetMusicsAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<MusicResponse>?>("musics");
    }

    public async Task<MusicResponse?> GetMusicByNameAsync(string name)
    {
        return await _httpClient.GetFromJsonAsync<MusicResponse?>($"musics/{name}");
    }

    public async Task AddMusicAsync(CreateMusicRequest request)
    {
        await _httpClient.PostAsJsonAsync("musics", request);
    }

    public async Task UpdateMusicAsync(int id, UpdateMusicRequest request)
    {
        await _httpClient.PutAsJsonAsync($"musics/{id}", request);
    }

    public async Task DeleteMusicAsync(int id)
    {
        await _httpClient.DeleteAsync($"musics/{id}");
    }
}