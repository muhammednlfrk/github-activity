using System.Text.Json;
using GitHubActivity.Core.Models;

namespace GitHubActivity.Core.Infrastructure;

public static class GitHubEventAPI
{
    private const string API_URL = "https://api.github.com/users/{0}/events";

    public static async Task<List<GitHubEvent>> GetGitHubUserEventsAsync(string username)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Add("User-Agent", "GitHubActivity.CLI");
        string url = string.Format(API_URL, username);
        string? response = await client.GetStringAsync(url);
        JsonSerializerOptions options = new();
        options.Converters.Add(new GitHubEventJsonConverter());
        List<GitHubEvent>? events = JsonSerializer.Deserialize<List<GitHubEvent>>(
            json: response,
            options: options) ?? [];
        return events;
    }
}