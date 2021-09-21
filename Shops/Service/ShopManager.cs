using System.Collections.Generic;
using Shops.Entity;
using Shops.Exception;

namespace Shops.Service
{
    public class ShopManager
    {
        private readonly List<ProductName> _productNames;
        private readonly List<Shop> _shops;
        private int _nextId;

        public ShopManager()
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

        public ProductName RegisterProductName(string name)
        {
            if (_productNames.Exists(pn => pn.Name == name))
                throw new ProductNameExistsException(name);
            var productNameToCreate = new ProductName(GenerateId(), name);
            _productNames.Add(productNameToCreate);
            return productNameToCreate;
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

        public void Buy(Customer customer, Shop shop, ProductName productName, int quantityToBuy)
        {
            Product product = shop.FindProduct(productName) ?? throw new ProductNotFoundException();
            if (customer.Balance < quantityToBuy * product.Price)
                throw new BalanceInsufficientException();
            shop.ChangeProductCount(product.Name, product.Count - quantityToBuy);
            customer.SpendMoney(quantityToBuy * product.Price);
        }

        private string GenerateId()
        {
            return _nextId++.ToString();
        }
    }
}