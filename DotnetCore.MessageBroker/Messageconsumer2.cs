using MassTransit;

namespace DotnetCore.MessageBroker;

public sealed class MessageConsumer2: IConsumer<MessageEvent>
{
    public Task Consume(ConsumeContext<MessageEvent> context)
    {
        Console.WriteLine("Consumer2 received at: {0}", context.Message.PublishDate);
        return Task.CompletedTask;
    }
}
