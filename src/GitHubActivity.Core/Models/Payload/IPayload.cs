namespace GitHubActivity.Core.Models.Payload;

public interface IPayload { }

public class DummyPayload : IPayload {
    public static DummyPayload Instance { get; } = new DummyPayload();
}
