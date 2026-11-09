using RickAndMortyApp.Models;

namespace RickAndMortyApp.Services.Interfaces;

public interface IRickAndMortyService
{
    Task<ApiResponse<Character>?> GetCharactersAsync(int page = 1, string? name = null);
    Task<ApiResponse<Location>?> GetLocationsAsync(int page = 1, string? name = null);
    Task<ApiResponse<Episode>?> GetEpisodesAsync(int page = 1, string? name = null);
}