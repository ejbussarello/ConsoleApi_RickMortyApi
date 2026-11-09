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
    }

    public Task<ApiResponse<Character>?> 
    GetCharactersAsync(int page = 1)
        => GetPageAsync<Character>("character", page);

    public Task<ApiResponse<Location>?> GetLocationsAsync(int page = 1)
        => GetPageAsync<Location>("location", page);

    public Task<ApiResponse<Episode>?> GetEpisodesAsync(int page = 1)
        => GetPageAsync<Episode>("episode", page);

    private async Task<ApiResponse<T>?> GetPageAsync<T>(string endpoint, int page)
    {
        var response = await _httpClient.GetAsync($"{endpoint}?page={page}");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<ApiResponse<T>>();
    }
}