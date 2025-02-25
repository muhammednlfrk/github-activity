using System.Text.Json.Serialization;

namespace GitHubActivity.Core.Models;

public class Comment
{
    [JsonPropertyName("id")]
    public required long Id { get; set; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; set; }

    [JsonPropertyName("url")]
    public required Uri Url { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("body_text")]
    public string? BodyText { get; set; }

    [JsonPropertyName("body_html")]
    public string? BodyHtml { get; set; }

    [JsonPropertyName("html_url")]
    public required Uri HtmlUrl { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    [JsonPropertyName("issue_url")]
    public required Uri IssueUrl { get; set; }
}
