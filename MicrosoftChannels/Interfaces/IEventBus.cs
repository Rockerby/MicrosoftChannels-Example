using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftChannels.Interfaces
{
    public interface IEventBus
    {
        Task PublishAsync<T>(
            T integrationEvent,
            CancellationToken cancellationToken = default)
            where T : class, IIntegrationEvent;
    }
}
