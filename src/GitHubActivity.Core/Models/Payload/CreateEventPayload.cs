using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class CreateEventPayload : IPayload
{
    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("ref_type")]
    public string? RefType { get; set; }

    [JsonPropertyName("master_branch")]
    public string? MasterBranch { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("pusher_type")]
    public string? PusherType { get; set; }
}