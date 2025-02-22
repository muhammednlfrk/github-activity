using System.Text.Json.Serialization;

namespace GitHubActivity.Core;

public abstract class Payload
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }
}
