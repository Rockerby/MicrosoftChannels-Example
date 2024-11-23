using EventBusExample.Interfaces.Repositories;
using EventBusExample.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusExample.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        /// <summary>
        /// The in-memory store of users
        /// </summary>
        private static List<User> UserStore { get; set; } = new List<User>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the already exists</exception>
        public User AddUser(User user)
        {
            if(UserStore.Any(u => u.Id == user.Id)) throw new ArgumentException("User already exists in the list");

            UserStore.Add(user);
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User? GetUser(Guid id)
        {
            return UserStore.FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            return UserStore;
        }
    }
}
