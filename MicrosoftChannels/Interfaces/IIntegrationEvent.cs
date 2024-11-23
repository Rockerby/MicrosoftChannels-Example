using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MicrosoftChannels.Interfaces
{
    public interface IIntegrationEvent : INotification
    {
        Guid Id { get; init; }
    }

    public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent;
}
