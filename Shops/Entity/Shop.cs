using System;
using System.Collections.Generic;
using Shops.Exception;

namespace Shops.Entity
{
    public class Shop
    {
        public Shop(string id, string name, string address, List<Product> products)
        {
            Id = id;
            Name = name;
            Address = address;
            Products = products;
        }

        public Shop(string id, string name, string address)
            : this(id, name, address, new List<Product>())
        {
        }

        public string Id { get; }
        public string Name { get; }
        public string Address { get; }
        public List<Product> Products { get; }

        public void AddProduct(ProductName productName, int count, int price)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), count, "count cannot be negative");
            if (Products.Exists(p => p.Name == productName))
                throw new ShopException("product already exist");

            Products.Add(new Product(productName, price, count));
        }

        public Product FindProduct(ProductName productName)
        {
            return Products.Find(p => p.Name == productName);
        }

        public void ChangeProductPrice(ProductName productName, int newPrice)
        {
            Product product = FindProduct(productName);
            if (product == null) throw new ShopException("Product not fount");
            product.ChangePrice(newPrice);
        }

        public void ChangeProductCount(ProductName productName, int newCount)
        {
            Product product = FindProduct(productName);
            if (product == null) throw new ShopException("Product not fount");
            product.ChangeCount(newCount);
        }
    }
}