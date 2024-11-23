﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MicrosoftChannels.Interfaces;
using MicrosoftChannels.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftChannels.Services
{
    internal sealed class IntegrationEventProcessorJob(
    InMemoryMessageQueue queue,
    IServiceScopeFactory serviceScopeFactory,
    ILogger<IntegrationEventProcessorJob> logger)
    : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
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