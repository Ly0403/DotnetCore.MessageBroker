using MassTransit;

namespace DotnetCore.MessageBroker;

public sealed class MessageConsumer :
    IConsumer<MessageEvent>
{
    public Task Consume(ConsumeContext<MessageEvent> context)
    {
        Console.WriteLine("Consumer received at: {0}", context.Message.PublishDate);
        return Task.CompletedTask;
    }
}
