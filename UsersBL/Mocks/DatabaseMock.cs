using System.Collections.Generic;
using MongoDB.Driver;
using UsersApi.Interfaces;
using UsersApi.Models;
using UsersBL.Interfaces;

namespace UsersApi.Mocks
{
    public class DatabaseMock : IUsersStorage
    {
        private readonly IMongoCollection<User> _users;

        public DatabaseMock(IUsersDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public User GetUser(string id) => 
            _users.Find(u => u.Id == id).FirstOrDefault();

        public IEnumerable<User> GetUsers() =>
            _users.Find(u => true).ToList();

        public User InsertUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void UpdateUser(string id, User user)
        {
            user.Id = id;
            _users.ReplaceOne(u => u.Id == id, user);
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(u => u.Id == id);
        }
    }
}
