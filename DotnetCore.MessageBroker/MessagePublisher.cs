
using MassTransit;

namespace DotnetCore.MessageBroker;

public sealed class MessagePublisher(IBus bus) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            bus.Publish(new MessageEvent(), stoppingToken);
            Task.Delay(3000, stoppingToken).Wait(stoppingToken);
        }
        return Task.CompletedTask;
    }
}
