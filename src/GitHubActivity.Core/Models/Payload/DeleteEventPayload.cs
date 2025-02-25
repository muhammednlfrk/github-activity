using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class DeleteEventPayload : IPayload
{
    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("ref_type")]
    public string? RefType { get; set; }
}
