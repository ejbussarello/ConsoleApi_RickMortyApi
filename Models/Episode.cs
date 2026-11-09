using System.Text.Json.Serialization;

namespace RickAndMortyApp.Models;

public class Episode
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("air_date")]
    public string AirDate { get; set; } = string.Empty;

    [JsonPropertyName("episode")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("characters")]
    public List<string> Characters { get; set; } = new();
}