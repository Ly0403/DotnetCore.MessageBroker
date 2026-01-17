using DotnetCore.MessageBroker;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHostedService<MessagePublisher>();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<MessageConsumer>();
    busConfigurator.AddConsumer<MessageConsumer2>();
    // busConfigurator.UsingInMemory((context, config)=> config.ConfigureEndpoints(context));

    // rabbitmq config
    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("rabbitmq://10.100.100.104", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        config.ConfigureEndpoints(context);
    });
});

var app = builder.Build();
app.Run();
