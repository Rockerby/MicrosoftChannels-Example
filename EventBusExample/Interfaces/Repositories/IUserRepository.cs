using EventBusExample.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusExample.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Guid id);
        List<User> GetUsers();
        User AddUser(User user);
    }
}
