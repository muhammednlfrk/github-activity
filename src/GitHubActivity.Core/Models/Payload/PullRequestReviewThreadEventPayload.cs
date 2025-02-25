using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class PullRequestReviewThreadEventPayload : IPayload
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("pull_request")]
    public required PullRequest PullRequest { get; set; }
}
