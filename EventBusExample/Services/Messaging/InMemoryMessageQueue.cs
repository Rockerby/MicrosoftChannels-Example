using EventBusExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EventBusExample.Services.Messaging
{
    public class InMemoryMessageQueue
    {
        private readonly Channel<IIntegrationEvent> _channel =
            Channel.CreateUnbounded<IIntegrationEvent>();

        public ChannelReader<IIntegrationEvent> Reader => _channel.Reader;

        public ChannelWriter<IIntegrationEvent> Writer => _channel.Writer;
    }
}
