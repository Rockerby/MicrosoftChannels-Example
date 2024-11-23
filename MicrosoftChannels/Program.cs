using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicrosoftChannels.Interfaces;
using MicrosoftChannels.Services;
using MicrosoftChannels.Services.Messaging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<InMemoryMessageQueue>();
builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddHostedService<IntegrationEventProcessorJob>();

using IHost host = builder.Build();

//ExemplifyServiceLifetime(host.Services, "Lifetime 1");
//ExemplifyServiceLifetime(host.Services, "Lifetime 2");

await host.RunAsync();





void CreateUser()
{

}