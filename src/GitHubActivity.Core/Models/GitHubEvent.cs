using System.Text.Json.Serialization;
using GitHubActivity.Core.Infrastructure;
using GitHubActivity.Core.Models.Payload;

namespace GitHubActivity.Core.Models;

public class GitHubEvent
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("actor")]
    public required Actor Actor { get; set; }

    [JsonPropertyName("repo")]
    public required Repository Repo { get; set; }

    [JsonPropertyName("payload")]
    public required IPayload Payload { get; set; }

    [JsonPropertyName("public")]
    public required bool Public { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    public static class EventType
    {
        public const string CommitCommentEvent = "CommitCommentEvent";
        public const string CreateEvent = "CreateEvent";
        public const string DeleteEvent = "DeleteEvent";
        public const string ForkEvent = "ForkEvent";
        public const string GollumEvent = "GollumEvent";
        public const string IssueCommentEvent = "IssueCommentEvent";
        public const string IssuesEvent = "IssuesEvent";
        public const string MemberEvent = "MemberEvent";
        public const string PublicEvent = "PublicEvent";
        public const string PullRequestEvent = "PullRequestEvent";
        public const string PullRequestReviewEvent = "PullRequestReviewEvent";
        public const string PullRequestReviewCommentEvent = "PullRequestReviewCommentEvent";
        public const string PullRequestReviewThreadEvent = "PullRequestReviewThreadEvent";
        public const string PushEvent = "PushEvent";
        public const string ReleaseEvent = "ReleaseEvent";
        public const string SponsorshipEvent = "SponsorshipEvent";
        public const string WatchEvent = "WatchEvent";
    }
}
