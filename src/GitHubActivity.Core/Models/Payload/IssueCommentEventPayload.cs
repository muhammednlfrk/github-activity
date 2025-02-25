using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class IssueCommentEventPayload : IPayload
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("issue")]
    public required Issue Issue { get; set; }

    [JsonPropertyName("comment")]
    public required Comment Comment { get; set; }
}
