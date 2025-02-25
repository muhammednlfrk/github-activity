using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models;

public class Actor
{
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    [JsonPropertyName("login")]
    public required string Login { get; set; }

    [JsonPropertyName("avatar_url")]
    public required Uri AvatarUrl { get; set; }
}
