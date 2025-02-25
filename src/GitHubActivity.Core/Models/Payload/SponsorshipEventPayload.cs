using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class SponsorshipEventPayload : IPayload
{
    [JsonPropertyName("action")]
    public required string Action { get; set; }
}
