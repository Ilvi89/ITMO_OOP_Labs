using System;
using System.Collections.Immutable;
using Shops.Exception;

namespace Shops.Entity
{
    public class Shop
    {
        public Shop(string id, string name, string address)
            : this(id, name, address, ImmutableList<Product>.Empty)
        {
        }

        private Shop(string id, string name, string address, ImmutableList<Product> products)
        {
            Id = id;
            Name = name;
            Address = address;
            Products = ImmutableList<Product>.Empty.AddRange(products);
        }

        public string Id { get; }
        public string Name { get; }
        public string Address { get; }
        public ImmutableList<Product> Products { get; }

        public Shop AddProduct(ProductName productName, int count, int price)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), count, "count cannot be negative");
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), price, "price cannot be negative");
            if (Products.Exists(p => p.Name.Equals(productName)))
                throw new ProductAlreadyExistException(productName.Name);

            return new Shop(Id, Name, Address, Products.Add(new Product(productName, price, count)));
        }

        public Product FindProduct(ProductName productName)
        {
            return Products.Find(p => p.Name.Equals(productName));
        }

        public Shop ChangeProductPrice(ProductName productName, int newPrice)
        {
            Product product = FindProduct(productName);
            if (product == null) throw new ShopsException("Product not fount");
            Product changedProduct = product.ChangePrice(newPrice);
            return new Shop(Id, Name, Address, Products.Remove(product).Add(changedProduct));
        }

        public Shop ChangeProductCount(ProductName productName, int newCount)
        {
            Product product = FindProduct(productName);
            if (product == null) throw new ShopsException("Product not fount");
            Product changedProduct = product.ChangeCount(newCount);
            return new Shop(Id, Name, Address, Products.Remove(product).Add(changedProduct));
        }
    }
}