namespace Shops.Entity
{
    public class Shop : Entity
    {
        public Shop(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public string Name { get; }
        public string Address { get; }
    }
}