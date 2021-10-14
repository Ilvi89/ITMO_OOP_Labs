using System;

namespace Shops.Entity
{
    public class Product
    {
        public Product(ProductName productName, int price, int count)
        {
            Name = productName;
            Price = price;
            Count = count;
        }

        public ProductName Name { get; }
        public int Price { get; }
        public int Count { get; }

        public Product ChangePrice(int newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), newPrice, "New price cannot be negative");

            return new Product(Name, newPrice, Count);
        }

        public Product ChangeCount(int newCount)
        {
            if (newCount < 0)
                throw new ArgumentOutOfRangeException(nameof(newCount), newCount, "New count cannot be negative");

            return new Product(Name, Price, newCount);
        }
    }
}