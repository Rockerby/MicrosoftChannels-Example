using MediatR;
using EventBusExample.Services.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusExample.Services.Handlers
{
    public class UserRegisteredIntegrationEventHandler
    : INotificationHandler<UserRegisteredIntegrationEvent>
    {
        public async Task Handle(
            UserRegisteredIntegrationEvent _event,
        CancellationToken cancellationToken)
        {
            // Sleep here so we can see that it is a background operation
            Thread.Sleep(5000);
            
            // Asynchronously handle the event.
            Console.WriteLine("CONSOLE -- _event managed {0} / {1}", _event.Id.ToString(), _event.Message);
            Debug.WriteLine("DEBUG -- _event managed {0} / {1}", _event.Id.ToString(), _event.Message);
        }
    }
}
