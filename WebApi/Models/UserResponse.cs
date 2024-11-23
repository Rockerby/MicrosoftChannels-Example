using EventBusExample.Repositories.Models;

namespace WebApi.Models
{
    public class UserResponse
    {
        public string? Message { get; set; }
        public User? User { get; set; }
    }
}
