using System;
using System.Collections.Generic;
using Shops.Entity;
using Shops.Exception;

namespace Shops.Service
{
    public class ShopManager
    {
        public Shop Create(string name, string address)
        {
            throw new NotImplementedException();
        }

        public ProductName RegisterProductName(string name)
        {
            throw new NotImplementedException();
        }

        public Shop FindShopWithLowestPrice(ProductName productName)
        {
            throw new NotImplementedException();
        }

        public void Buy(Customer customer, ProductName apple, int quantityToBuy)
        {
            throw new NotImplementedException();
        }
    }
}