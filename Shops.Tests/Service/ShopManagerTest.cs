using NUnit.Framework;
using Shops.Entity;
using Shops.Exception;
using Shops.Service;

namespace Shops.Tests.Service
{
    public class ShopManagerTest
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }

        [TestCase("apple", "Apple", "aPPle")]
        [TestCase("COCACOLA", "CocaCola", "COCACOLa")]
        public void RegisterExistingProductName_ThrowProductNameExistsException(string name1, string name2,
            string name3)
        {
            Assert.Catch<ProductNameExistsException>(() =>
            {
                _shopManager.RegisterProductName(name1);
                _shopManager.RegisterProductName(name2);
                _shopManager.RegisterProductName(name3);
            });
        }

        [Test]
        public void RegisterProductName()
        {
            _shopManager.RegisterProductName("name1");
            _shopManager.RegisterProductName("name2");
            _shopManager.RegisterProductName("name3");
        }

        [Test]
        public void ProductNameEquality()
        {
            Assert.IsFalse(new ProductName("dadaya").Equals(new ProductName("apple")));
            Assert.IsTrue(new ProductName("dadaya").Equals(new ProductName("dadaya")));
        }

        [Test]
        public void FindShopWithLowestPrice_ReturnLowestPrice()
        {
            int lowestPrice = 10;
            string shopNameWithLowestPrice = "Здесь могла быть ваша реклама";

            ProductName apple = _shopManager.RegisterProductName("apple");
            Shop lowShop = _shopManager.Create(shopNameWithLowestPrice, "Some st. 1");
            Shop firstShop = _shopManager.Create("First", "Some st. 1");
            Shop secondShop = _shopManager.Create("Second", "Some st. 1");


            secondShop.AddProduct(apple, 0, lowestPrice + 1);
            lowShop.AddProduct(apple, 0, lowestPrice);
            firstShop.AddProduct(apple, 0, lowestPrice + 2);

            Shop lowestShop = _shopManager.FindShopWithLowestPrice(apple);
            Product lowestProduct = lowestShop.FindProduct(apple);
            Assert.AreEqual(lowShop.Name, shopNameWithLowestPrice);
            Assert.AreEqual(lowestProduct.Price, lowestPrice);
        }

        [Test]
        public void FindShopWithLowestPrice_ThrowShopNotFoundException()
        {
            ProductName apple = _shopManager.RegisterProductName("apple");
            Assert.Catch<ShopNotFoundException>(() => _shopManager.FindShopWithLowestPrice(apple));
        }

        [Test]
        public void BuyProduct_CustomerBalanceAndProductCountChanged()
        {
            int oldBalance = 1000;
            int quantityToBuy = 5;
            int oldProductCount = 5;
            var customer = new Customer(oldBalance);

            ProductName apple = _shopManager.RegisterProductName("apple");
            Shop shop = _shopManager.Create("BestShop", "Tyta st. 1");
            shop.AddProduct(apple, oldProductCount, 10);
            _shopManager.Buy(customer, shop, apple, quantityToBuy);
            Product product = shop.FindProduct(apple);

            Assert.AreEqual(customer.Balance, oldBalance - quantityToBuy * product.Price);
            Assert.AreEqual(product.Count, oldProductCount - quantityToBuy);
        }

        public void BuyProduct_ThrowBalanceInsufficientException()
        {
            var customer = new Customer(0);
            ProductName apple = _shopManager.RegisterProductName("apple");
            Shop shop = _shopManager.Create("BestShop", "Tyta st. 1");

            shop.AddProduct(apple, 10, 10);
            Assert.Catch<BalanceInsufficientException>(()
                => _shopManager.Buy(customer, shop, apple, 1));
        }
    }
}