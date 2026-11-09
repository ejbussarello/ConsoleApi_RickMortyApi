using System.Text.Json.Serialization;

namespace RickAndMortyApp.Models;

public class ApiResponse<T>
{
    [JsonPropertyName("info")]
    public PageInfo Info { get; set; } = new();

    [JsonPropertyName("results")]
    public List<T> Results { get; set; } = new();
}