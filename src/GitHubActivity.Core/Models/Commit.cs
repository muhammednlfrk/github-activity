using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models;

public class Commit
{
    [JsonPropertyName("sha")]
    public string? Sha { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("distinct")]
    public bool Distinct { get; set; }

    [JsonPropertyName("author")]
    public CommitAuthor? Author { get; set; }

    public class CommitAuthor
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
