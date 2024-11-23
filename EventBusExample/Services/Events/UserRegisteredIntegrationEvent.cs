using EventBusExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusExample.Services.Events
{
    public record UserRegisteredIntegrationEvent : IntegrationEvent
    {
        public string Message { get; set; }

        public UserRegisteredIntegrationEvent (Guid id, string message) : base (id)
        {
            Id = id;
            Message = message;
        }
    }
}
