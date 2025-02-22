using System.Text.Json.Serialization;

namespace GitHubActivity.Core;

public class GitHubEvent
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("actor")]
    public required Actor Actor { get; set; }

    [JsonPropertyName("repo")]
    public required Repository Repo { get; set; }

    [JsonPropertyName("payload")]
    public required Dictionary<string, object> Payload { get; set; }

    [JsonPropertyName("public")]
    public required bool Public { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }
}
