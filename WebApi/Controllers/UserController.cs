using EventBusExample.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using EventBusExample.Interfaces;
using EventBusExample.Repositories.Models;
using EventBusExample.Services.Events;
using System.Threading;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, IEventBus eventBus, ILogger<UserController> logger)
        {
            _eventBus = eventBus;
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost(Name = "AddUser")]
        public async Task<UserResponse> AddUser(Guid id, string name)
        {
            UserResponse resp = new UserResponse();
            // First, register the user.
            User user = new User(id) { Name = name };
            try
            {
                resp.User = _userRepository.AddUser(user);
            }
            catch(ArgumentException ae)
            {
                resp.Message = ae.Message;
                return resp;
            }

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            // Now we can publish the event.
            await _eventBus.PublishAsync(
                new UserRegisteredIntegrationEvent(user.Id, "Pass extra information!"),
                token);

            return resp;
        }
    }
}
