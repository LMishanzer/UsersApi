using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Interfaces;
using UsersApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersStorage _users;

        public UsersController(IUsersStorage users)
        {
            _users = users;
        }

        // GET: <UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _users.GetUsers();
        }

        // GET <UsersController>/{id}
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _users.GetUser(id);
        }

        // POST <UsersController>
        [HttpPost]
        public User Insert(User user)
        {
            return _users.InsertUser(user);
        }

        // POST <UsersController>
        [HttpPost("{id}")]
        public void Update(string id, User user)
        {
            _users.UpdateUser(id, user);
        }

        // DELETE <UsersController>
        [HttpDelete]
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _users.DeleteUser(id);
        }
    }
}
