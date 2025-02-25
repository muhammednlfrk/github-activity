using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class PullRequestReviewCommentEventPayload : IPayload
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("pull_request")]
    public required PullRequest PullRequest { get; set; }

    [JsonPropertyName("repository")]
    public required Repository Repository { get; set; }

    [JsonPropertyName("comment")]
    public required Comment Sender { get; set; }
}
