using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models;

public class PullRequest
{
    [JsonPropertyName("url")]
    public required Uri Url { get; set; }

    [JsonPropertyName("id")]
    public required long Id { get; set; }

    [JsonPropertyName("number")]
    public required long Number { get; set; }
}
