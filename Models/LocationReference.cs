using System.Text.Json.Serialization;

namespace RickAndMortyApp.Models;

public class LocationReference
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}