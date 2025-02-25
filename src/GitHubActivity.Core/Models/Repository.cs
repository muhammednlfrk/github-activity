using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models;

public class Repository
{
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required Uri Url { get; set; }
}