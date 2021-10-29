using System;

namespace Shops.Entity
{
    public class Product : Entity
    {
        public Product(string id, ProductName productName, string shopId, int price, int count)
        {
            Id = id;
            Name = productName;
            Price = price;
            Count = count;
            ShopId = shopId;
        }

        public ProductName Name { get; }
        public string ShopId { get; }
        public int Price { get; }
        public int Count { get; }

        public Product ChangePrice(int newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), newPrice, "New price cannot be negative");

            return new Product(Id, Name, ShopId, newPrice, Count);
        }

        public Product ChangeCount(int newCount)
        {
            if (newCount < 0)
                throw new ArgumentOutOfRangeException(nameof(newCount), newCount, "New count cannot be negative");

            return new Product(Id, Name, ShopId, Price, newCount);
        }
    }
}