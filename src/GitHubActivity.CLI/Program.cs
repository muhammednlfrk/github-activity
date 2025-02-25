using GitHubActivity.Core.Infrastructure;
using GitHubActivity.Core.Models;
using GitHubActivity.Core.Models.Payload;

namespace GitHubActivity.CLI;

class Program
{
    public static async Task<int> Main(string[] args)
    {
        // If help parameter sended, print help message
        if (args.Length < 1 && (args[0] == "--help" || args[0] == "-h"))
        {
            printHelp();
            return 0;
        }

        // Get username from the first parameter
        string username = args[0];

        // Fetch events.
        try
        {
            Console.WriteLine($"Fetching events for {username}...");
            List<GitHubEvent> events = await GitHubEventAPI.GetGitHubUserEventsAsync(username);
            Console.WriteLine($"{(events.Count == 0 ? "No" : events.Count)} event(s) found");
            // Print events.
            foreach (GitHubEvent e in events)
                printEvent(e, username);
            return 0;
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("An error occurred when trying to connect server.");
            Console.WriteLine("Please check your internet connection and try again later");
            return 1;
        }
        catch
        {
            Console.WriteLine($"An error occurred");
            return 1;
        }
    }

    private static void printHelp()
    {
        Console.WriteLine("Usage: ghact <username>");
    }

    private static void printEvent(GitHubEvent e, string username)
    {
        switch (e.Type)
        {
            case GitHubEvent.EventType.CommitCommentEvent:
                Console.WriteLine($"{username} commented on a commit at {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.CreateEvent:
                CreateEventPayload payload = (CreateEventPayload)e.Payload;
                Console.WriteLine($"{username} created {payload.RefType} {payload.Ref} at {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.DeleteEvent:
                DeleteEventPayload deletePayload = (DeleteEventPayload)e.Payload;
                Console.WriteLine($"{username} deleted {deletePayload.RefType} {deletePayload.Ref} at {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.ForkEvent:
                Console.WriteLine($"{username} forked {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.GollumEvent:
                Console.WriteLine($"{username} updated the wiki in {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.IssueCommentEvent:
                IssueCommentEventPayload issueCommentPayload = (IssueCommentEventPayload)e.Payload;
                Console.WriteLine($"{username} commented on issue #{issueCommentPayload.Issue.Number} in {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.IssuesEvent:
                IssuesEventPayload issuesPayload = (IssuesEventPayload)e.Payload;
                Console.WriteLine($"{username} {issuesPayload.Action} issue #{issuesPayload.Issue.Number} in {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.MemberEvent:
                Console.WriteLine($"{username} added {e.Actor.Login} as a collaborator to {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.PublicEvent:
                Console.WriteLine($"{username} open sourced {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.PullRequestEvent:
                PullRequestEventPayload prPayload = (PullRequestEventPayload)e.Payload;
                Console.WriteLine($"{username} {prPayload.Action} pull request #{prPayload.PullRequest.Number} in {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.PullRequestReviewEvent:
                PullRequestReviewEventPayload prReviewPayload = (PullRequestReviewEventPayload)e.Payload;
                Console.WriteLine($"{username} {prReviewPayload.Action} a review on pull request #{prReviewPayload.PullRequest.Number} in {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.PullRequestReviewCommentEvent:
                PullRequestReviewCommentEventPayload prReviewCommentPayload = (PullRequestReviewCommentEventPayload)e.Payload;
                Console.WriteLine($"{username} commented on a review on pull request #{prReviewCommentPayload.PullRequest.Number} in {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.PullRequestReviewThreadEvent:
                PullRequestReviewThreadEventPayload prReviewThreadPayload = (PullRequestReviewThreadEventPayload)e.Payload;
                Console.WriteLine($"{username} commented on a review thread on pull request #{prReviewThreadPayload.PullRequest.Number} in {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.PushEvent:
                PushEventPayload pushPayload = (PushEventPayload)e.Payload;
                Console.WriteLine($"{username} pushed {pushPayload.Commits.Count} commits to {pushPayload.Ref} at {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.ReleaseEvent:
                ReleaseEventPayload releasePayload = (ReleaseEventPayload)e.Payload;
                Console.WriteLine($"{username} released {releasePayload.Release.TagName} at {e.Repo.Name}");
                break;

            case GitHubEvent.EventType.SponsorshipEvent:
                Console.WriteLine("TODO: SponsorshipEvent");
                break;

            case GitHubEvent.EventType.WatchEvent:
                Console.WriteLine($"{username} starred {e.Repo.Name}");
                break;

            default:
                Console.WriteLine($"Unknown event type: {e.Type}");
                break;
        }
    }
}
