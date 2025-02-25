using System.Text.Json;
using System.Text.Json.Serialization;
using GitHubActivity.Core.Models;
using GitHubActivity.Core.Models.Payload;

namespace GitHubActivity.Core.Infrastructure;

public class GitHubEventJsonConverter : JsonConverter<GitHubEvent>
{
    public override GitHubEvent? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        if (!document.RootElement.TryGetProperty("type", out JsonElement typeElement))
            throw new JsonException("Missing 'type' property in payload");
        string eventType = typeElement.GetString() ?? throw new JsonException("Invalid 'type' property in payload");
        JsonElement payloadElement = document.RootElement.GetProperty("payload");
        IPayload payload = getPayload(payloadElement, eventType, options) ?? DummyPayload.Instance;
        GitHubEvent gitHubEvent = new()
        {
            Id = document.RootElement.GetProperty("id").GetString() ?? string.Empty,
            Type = eventType,
            Actor = JsonSerializer.Deserialize<Actor>(document.RootElement.GetProperty("actor").GetRawText(), options) ?? throw new JsonException("Invalid 'actor' property in payload"),
            Repo = JsonSerializer.Deserialize<Repository>(document.RootElement.GetProperty("repo").GetRawText(), options) ?? throw new JsonException("Invalid 'repo' property in payload"),
            Public = document.RootElement.GetProperty("public").GetBoolean(),
            CreatedAt = document.RootElement.GetProperty("created_at").GetDateTime(),
            Payload = payload
        };
        return gitHubEvent;
    }

    public override void Write(
        Utf8JsonWriter writer,
        GitHubEvent value,
        JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }

    private static IPayload? getPayload(
        JsonElement payloadElement,
        string eventType,
        JsonSerializerOptions options) => eventType switch
        {
            GitHubEvent.EventType.CreateEvent =>
                JsonSerializer.Deserialize<CreateEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.DeleteEvent =>
                JsonSerializer.Deserialize<DeleteEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.IssueCommentEvent =>
                JsonSerializer.Deserialize<IssueCommentEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.IssuesEvent =>
                JsonSerializer.Deserialize<IssuesEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.PullRequestEvent =>
                JsonSerializer.Deserialize<PullRequestEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.PullRequestReviewEvent =>
                JsonSerializer.Deserialize<PullRequestReviewEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.PullRequestReviewCommentEvent =>
                JsonSerializer.Deserialize<PullRequestReviewCommentEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.PullRequestReviewThreadEvent =>
                JsonSerializer.Deserialize<PullRequestReviewThreadEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.PushEvent =>
                JsonSerializer.Deserialize<PushEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.ReleaseEvent =>
                JsonSerializer.Deserialize<ReleaseEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.SponsorshipEvent =>
                JsonSerializer.Deserialize<SponsorshipEventPayload>(payloadElement.GetRawText(), options),

            GitHubEvent.EventType.CommitCommentEvent or
            GitHubEvent.EventType.ForkEvent or
            GitHubEvent.EventType.GollumEvent or
            GitHubEvent.EventType.MemberEvent or
            GitHubEvent.EventType.PublicEvent or
            GitHubEvent.EventType.WatchEvent =>
                JsonSerializer.Deserialize<DummyPayload>(payloadElement.GetRawText(), options),

            _ => throw new JsonException($"Unknown event type: {eventType}")
        };
}