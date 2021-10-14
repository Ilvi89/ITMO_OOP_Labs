using System.Collections.Generic;
using Shops.Entity;
using Shops.Exception;

namespace Shops.Service
{
    public class ShopsService
    {
        private readonly List<ProductName> _productNames;
        private readonly List<Shop> _shops;
        private int _nextId;

        public ShopsService()
        {
            _nextId = 0;
            _productNames = new List<ProductName>();
            _shops = new List<Shop>();
        }

        public Shop Create(string name, string address)
        {
            var shop = new Shop(GenerateId(), name, address);
            _shops.Add(shop);
            return shop;
        }

        public Shop GetShop(string id)
        {
            return _shops.Find(s => s.Id == id);
        }

        public ProductName RegisterProductName(string name)
        {
            var productNameToCreate = new ProductName(name);
            if (_productNames.Exists(pn => pn.Equals(productNameToCreate)))
                throw new ProductNameExistsException(name);
            _productNames.Add(productNameToCreate);
            return productNameToCreate;
        }

        public Shop AddProductToShop(Shop shop, ProductName productName, int count, int price)
        {
            if (shop.FindProduct(productName) is not null)
                throw new ProductAlreadyExistException(productName.Name);
            Shop changedShop = shop.AddProduct(productName, count, price);
            _shops.Remove(shop);
            _shops.Add(changedShop);
            return changedShop;
        }

        public Shop FindShopWithLowestPrice(ProductName productName)
        {
            Shop lowShop = null;
            int lowPrice = int.MaxValue;
            foreach (Shop shop in _shops)
            {
                Product product = shop.FindProduct(productName);
                if (product != null && product.Price < lowPrice)
                {
                    lowShop = shop;
                    lowPrice = product.Price;
                }
            }

            return lowShop ?? throw new ShopNotFoundException();
        }

        public Customer Buy(Customer customer, Shop shop, ProductName productName, int quantityToBuy)
        {
            Product product = shop.FindProduct(productName) ?? throw new ProductNotFoundException();
            if (customer.Balance < quantityToBuy * product.Price)
                throw new BalanceInsufficientException();
            Shop changedShop = shop.ChangeProductCount(product.Name, product.Count - quantityToBuy);
            _shops.Remove(shop);
            _shops.Add(changedShop);
            return customer.SpendMoney(quantityToBuy * product.Price);
        }

        private string GenerateId()
        {
            return _nextId++.ToString();
        }
    }
}