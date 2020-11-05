namespace UsersApi.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Zip { get; set; }

        public Address() { }

        public Address(string line1, string line2, string zip)
        {
            Line1 = line1;
            Line2 = line2;
            Zip = zip;
        }
    }
}
