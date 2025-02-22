using System.Text.Json;
using GitHubActivity.Core;

namespace GitHubActivity.CLI;

class Program
{
    private static readonly string GitHubApiUrl = "https://api.github.com/users/{0}/events";

    public static async Task Main(string[] args)
    {
        string username = args.Length > 0 ? args[0] : "ahmetb";

        Console.WriteLine($"Fetching events for {username}...");

        List<GitHubEvent> events = await GetGitHubUserEventsAsync(username);

        Console.WriteLine($"Events for {username}:");

        foreach (var e in events)
        {
            switch (e.Type)
            {
                case "PushEvent":
                    Console.WriteLine($"{e.Actor.Login} pushed {e.Payload["size"]} commit(s) to {e.Repo.Name}");
                    break;
                case "CommitCommentEvent":
                    Console.WriteLine($"{e.Actor.Login} commented on commit in {e.Repo.Name}");
                    break;
                case "PullRequestEvent":
                    Console.WriteLine($"{e.Actor.Login} created a pull request in {e.Repo.Name}");
                    break;
                case "IssuesEvent":
                    Console.WriteLine($"{e.Actor.Login} opened an issue in {e.Repo.Name}");
                    break;
                case "IssueCommentEvent":
                    Console.WriteLine($"{e.Actor.Login} commented on issue in {e.Repo.Name}");
                    break;
                case "CreateEvent":
                    Console.WriteLine($"{e.Actor.Login} created {e.Payload["ref_type"]} {e.Payload["ref"]} in {e.Repo.Name}");
                    break;
                case "DeleteEvent":
                    Console.WriteLine($"{e.Actor.Login} deleted {e.Payload["ref_type"]} {e.Payload["ref"]} in {e.Repo.Name}");
                    break;
                case "ForkEvent":
                    Console.WriteLine($"{e.Actor.Login} forked {e.Repo.Name}");
                    break;
                case "ReleaseEvent":
                    JsonElement releseElement = (JsonElement)e.Payload["release"];
                    string? tagName = releseElement.GetProperty("tag_name").GetString();
                    Console.WriteLine($"{e.Actor.Login} released {e.Payload["release"]}{tagName} in {e.Repo.Name}");
                    break;
                case "GollumEvent":
                    Console.WriteLine($"{e.Actor.Login} created or updated a wiki in {e.Repo.Name}");
                    break;
                case "MemberEvent":
                    JsonElement memberElement = (JsonElement)e.Payload["member"];
                    string? memberLogin = memberElement.GetProperty("login").GetString();
                    Console.WriteLine($"{e.Actor.Login} added {memberLogin} as a collaborator to {e.Repo.Name}");
                    break;
                case "SponsorshipEvent":
                    JsonElement sponsorshipElement = (JsonElement)e.Payload["sponsorship"];
                    JsonElement sponseeElement = sponsorshipElement.GetProperty("sponsee");
                    string? sponseeLogin = sponseeElement.GetProperty("login").GetString();
                    Console.WriteLine($"{e.Actor.Login} sponsored {sponseeLogin} in {e.Repo.Name}");
                    break;
                case "PublicEvent":
                    Console.WriteLine($"{e.Actor.Login} open sourced {e.Repo.Name}");
                    break;
                case "PullRequestReviewEvent":
                    Console.WriteLine($"{e.Actor.Login} reviewed a pull request in {e.Repo.Name}");
                    break;
                case "PullRequestReviewCommentEvent":
                    Console.WriteLine($"{e.Actor.Login} commented on a pull request in {e.Repo.Name}");
                    break;
                case "PullRequestReviewThreadEvent":
                    Console.WriteLine($"{e.Actor.Login} commented on a thread in a pull request in {e.Repo.Name}");
                    break;
                case "WatchEvent":
                    Console.WriteLine($"{e.Actor.Login} starred {e.Repo.Name}");
                    break;
                default:
                    Console.WriteLine($"Unknown event type: {e.Type}");
                    break;
            }
        }
    }

    public static async Task<List<GitHubEvent>> GetGitHubUserEventsAsync(string username)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Add("User-Agent", "GitHubActivity.CLI");

        string url = string.Format(GitHubApiUrl, username);
        var response = await client.GetStringAsync(url);
        var events = JsonSerializer.Deserialize<List<GitHubEvent>>(response) ?? [];

        return events;
    }
}
