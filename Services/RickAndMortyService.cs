using System.Net;
using System.Net.Http.Json;
using RickAndMortyApp.Models;
using RickAndMortyApp.Services.Interfaces;

namespace RickAndMortyApp.Services;

public class RickAndMortyService : IRickAndMortyService
{
    private readonly HttpClient _httpClient;

    public RickAndMortyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
        _httpClient.Timeout = TimeSpan.FromSeconds(10);
    }

    public Task<ApiResponse<Character>?> GetCharactersAsync(int page = 1, string? name = null)
        => GetPageAsync<Character>("character", page, name);

    public Task<ApiResponse<Location>?> GetLocationsAsync(int page = 1, string? name = null)
        => GetPageAsync<Location>("location", page, name);

    public Task<ApiResponse<Episode>?> GetEpisodesAsync(int page = 1, string? name = null)
        => GetPageAsync<Episode>("episode", page, name);

    private async Task<ApiResponse<T>?> GetPageAsync<T>(string endpoint, int page, string? name = null)
    {
        var url = $"{endpoint}?page={page}";

        if (!string.IsNullOrWhiteSpace(name))
            url += $"&name={Uri.EscapeDataString(name.Trim())}";

        var response = await _httpClient.GetAsync(url);

        // 404 = a API não encontrou nada. Não é um erro, é "sem resultados". Então retornamos null para indicar isso.
        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        // Qualquer outro código de erro (5xx, 4xx que não seja 404) será tratado como exceção.
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ApiResponse<T>>();
    }
}