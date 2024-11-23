using EventBusExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusExample.Services.Messaging
{
    public class EventBus(InMemoryMessageQueue queue) : IEventBus
    {
        public async Task PublishAsync<T>(
            T integrationEvent,
            CancellationToken cancellationToken = default)
            where T : class, IIntegrationEvent
        {
            await queue.Writer.WriteAsync(integrationEvent, cancellationToken);
        }
    }
}
