using MicrosoftChannels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MicrosoftChannels.Services.Messaging
{
    internal sealed class InMemoryMessageQueue
    {
        private readonly Channel<IIntegrationEvent> _channel =
            Channel.CreateUnbounded<IIntegrationEvent>();

        public ChannelReader<IIntegrationEvent> Reader => _channel.Reader;

        public ChannelWriter<IIntegrationEvent> Writer => _channel.Writer;
    }
}
