using System.Text.Json.Serialization;

namespace GitHubActivity.Core;

public class Page
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("sha")]
    public string? Sha { get; set; }
}
