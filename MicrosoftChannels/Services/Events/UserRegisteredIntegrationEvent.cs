using MicrosoftChannels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftChannels.Services.Events
{
    public record UserRegisteredIntegrationEvent : IntegrationEvent
    {
        private Guid _Id { get; set; }
        public string Message { get; set; }

        public UserRegisteredIntegrationEvent (Guid id, string message) : base (id)
        {
            Message = message;
        }
    }
}
