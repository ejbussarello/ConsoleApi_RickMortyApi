using System.Text.Json.Serialization;

namespace RickAndMortyApp.Models;

public class Location
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("dimension")]
    public string Dimension { get; set; } = string.Empty;

    [JsonPropertyName("residents")]
    public List<string> Residents { get; set; } = new();
}