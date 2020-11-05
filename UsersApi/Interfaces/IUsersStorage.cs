using System.Collections.Generic;
using UsersApi.Models;

namespace UsersApi.Interfaces
{
    public interface IUsersStorage
    {
        User GetUser(string id);
        IEnumerable<User> GetUsers();
        User InsertUser(User user);
        void UpdateUser(string id, User user);
        void DeleteUser(string id);
    }
}
