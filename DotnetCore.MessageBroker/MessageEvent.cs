namespace DotnetCore.MessageBroker;

public sealed record MessageEvent
{
    public DateTime PublishDate { get; } = DateTime.Now;

}
