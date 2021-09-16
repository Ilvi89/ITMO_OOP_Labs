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
        public int Price { get; private set; }
        public int Count { get; private set; }

        public void ChangePrice(int newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), newPrice, "New price cannot be negative");
            Price = newPrice;
        }

        public void ChangeCount(int newCount)
        {
            if (newCount < 0)
                throw new ArgumentOutOfRangeException(nameof(newCount), newCount, "New count cannot be negative");
            Count = newCount;
        }
    }
}