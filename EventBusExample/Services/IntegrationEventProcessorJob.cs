using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EventBusExample.Interfaces;
using EventBusExample.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusExample.Services
{
    public class IntegrationEventProcessorJob(
        InMemoryMessageQueue queue,
        IServiceScopeFactory serviceScopeFactory,
        ILogger<IntegrationEventProcessorJob> logger)
        : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Here in execute");
            Debug.WriteLine("DEBUG Here in execute");

            await foreach (IIntegrationEvent integrationEvent in
                queue.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    using IServiceScope scope = serviceScopeFactory.CreateScope();

                    IPublisher publisher = scope.ServiceProvider
                        .GetRequiredService<IPublisher>();

                    await publisher.Publish(integrationEvent, stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(
                        ex,
                        "Something went wrong! {IntegrationEventId}",
                        integrationEvent.Id);
                }
            }
        }
    }
}
