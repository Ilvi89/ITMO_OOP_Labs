namespace Shops.Entity
{
    public class ProductName
    {
        public ProductName(string name)
        {
            Name = name.ToUpper();
        }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (obj is not ProductName)
                return false;
            var productName = (ProductName)obj;
            return productName.Name == Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}