using System.Text.Json.Serialization;

namespace RickAndMortyApp.Models;

public class Character
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("species")]
    public string Species { get; set; } = string.Empty;

    [JsonPropertyName("gender")]
    public string Gender { get; set; } = string.Empty;

    [JsonPropertyName("origin")]
    public LocationReference Origin { get; set; } = new();

    [JsonPropertyName("location")]
    public LocationReference Location { get; set; } = new();

    [JsonPropertyName("episode")]
    public List<string> Episodes { get; set; } = new();
}