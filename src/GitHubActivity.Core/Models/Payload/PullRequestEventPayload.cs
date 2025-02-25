using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class PullRequestEventPayload : IPayload
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("number")]
    public required int Number { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("pull_request")]
    public required PullRequest PullRequest { get; set; }
}
