using MediatR;
using EventBusExample.Services.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Handlers
{
    public class AnotherUserRegisteredIntegrationEventHandler
    : INotificationHandler<UserRegisteredIntegrationEvent>
    {
        public async Task Handle(
            UserRegisteredIntegrationEvent _event,
        CancellationToken cancellationToken)
        {
            // Sleep here so we can see that it is a background operation
            Thread.Sleep(2000);

            // Asynchronously handle the event.
            Console.WriteLine("CONSOLE -- ANOTHER _event managed {0} / {1}", _event.Id.ToString(), _event.Message);
            Debug.WriteLine("DEBUG -- ANOTHER _event managed {0} / {1}", _event.Id.ToString(), _event.Message);
        }
    }
}
