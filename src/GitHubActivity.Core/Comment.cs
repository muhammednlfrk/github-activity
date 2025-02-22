using System.Text.Json.Serialization;

namespace GitHubActivity.Core;

public class Comment
{
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }
}
