using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UsersApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }

        public User() { }

        public User(string name, string surname, Address address)
        {
            Name = name;
            Surname = surname;
            Address = address;
        }

        public User(string id, string name, string surname, Address address) : this(name, surname, address)
        {
            Id = id;
        }

        public void CopyFrom(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Address = user.Address;
        }
    }
}
