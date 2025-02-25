using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models;

public class Issue
{
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    [JsonPropertyName("number")]
    public required long Number { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("state")]
    public required string State { get; set; }
}
