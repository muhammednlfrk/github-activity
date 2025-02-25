using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class ReleaseEventPayload : IPayload
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("release")]
    public required Release Release { get; set; }
}
