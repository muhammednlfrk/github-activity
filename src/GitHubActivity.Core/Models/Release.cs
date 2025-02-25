using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models;

public class Release
{
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    [JsonPropertyName("tag_name")]
    public required string TagName { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
