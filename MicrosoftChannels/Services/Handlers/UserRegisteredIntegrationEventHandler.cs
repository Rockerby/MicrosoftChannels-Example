using MediatR;
using MicrosoftChannels.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftChannels.Services.Handlers
{
    internal sealed class UserRegisteredIntegrationEventHandler
    : INotificationHandler<UserRegisteredIntegrationEvent>
    {
        public async Task Handle(
            UserRegisteredIntegrationEvent _event,
        CancellationToken cancellationToken)
        {
            // Asynchronously handle the event.
        }
    }
}
