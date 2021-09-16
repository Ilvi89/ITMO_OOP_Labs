namespace Shops.Entity
{
    public class ProductName
    {
        public ProductName(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (obj is not ProductName productName) return false;
            return productName.Id == Id && productName.Name == Name;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}