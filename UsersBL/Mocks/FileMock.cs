using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using UsersApi.Interfaces;
using UsersApi.Models;

namespace UsersApi.Mocks
{
    public class FileMock : IUsersStorage
    {
        private static string filePath = "data.dat";
        private readonly List<User> _users;

        public FileMock()
        {
            string data = System.IO.File.ReadAllText(filePath);
            _users = JsonSerializer.Deserialize<List<User>>(data);
        }

        public User GetUser(string id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public User InsertUser(User user)
        {
            _users.Add(user);
            Save();
            return _users.Single(u => u.Id == user.Id);
        }

        public void UpdateUser(string id, User user)
        {
            var tempUser = _users.SingleOrDefault(u => u.Id == user.Id);

            if (tempUser == null)
            {
                InsertUser(user);
            }
            else
            {
                tempUser.CopyFrom(user);
                Save();
            }
        }

        public void DeleteUser(string id)
        {
            _users.RemoveAll(u => u.Id == id);
            Save();
        }

        private void Save()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(_users));
        }
    }
}
