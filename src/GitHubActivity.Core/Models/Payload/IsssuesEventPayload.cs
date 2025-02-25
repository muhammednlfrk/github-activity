using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class IssuesEventPayload : IPayload
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("issue")]
    public required Issue Issue { get; set; }
}