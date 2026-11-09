using System.Text.Json.Serialization;

namespace RickAndMortyApp.Models;

public class PageInfo
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    [JsonPropertyName("next")]
    public String? Next { get; set; }

    [JsonPropertyName("prev")]
    public String? Prev { get; set; }
}