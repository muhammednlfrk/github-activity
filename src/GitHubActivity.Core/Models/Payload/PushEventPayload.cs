using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models.Payload;

public class PushEventPayload : IPayload
{
    [JsonPropertyName("push_id")]
    public required long PushId { get; set; }

    [JsonPropertyName("size")]
    public required int Size { get; set; }

    [JsonPropertyName("distinct_size")]
    public required int DistinctSize { get; set; }

    [JsonPropertyName("ref")]
    public required string Ref { get; set; }

    [JsonPropertyName("head")]
    public required string Head { get; set; }

    [JsonPropertyName("before")]
    public required string Before { get; set; }

    [JsonPropertyName("commits")]
    public required List<Commit> Commits { get; set; }
}
