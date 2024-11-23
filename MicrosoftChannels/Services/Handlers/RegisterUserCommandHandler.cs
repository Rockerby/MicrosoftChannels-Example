using MicrosoftChannels.Interfaces;
using MicrosoftChannels.Repositories;
using MicrosoftChannels.Repositories.Models;
using MicrosoftChannels.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftChannels.Services.Handlers
{
    internal sealed class RegisterUserCommandHandler(
    IUserRepository userRepository,
    IEventBus eventBus)
    {
        public async Task<User> CreateUser(
            CancellationToken cancellationToken)
        {
            // First, register the user.
            User user = new User(Guid.NewGuid());

            userRepository.AddUser(user);

            // Now we can publish the event.
            await eventBus.PublishAsync(
                new UserRegisteredIntegrationEvent(user.Id, "HELLO"),
                cancellationToken);

            return user;
        }
    }
}
