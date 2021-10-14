using NUnit.Framework;
using Shops.Entity;
using Shops.Exception;
using Shops.Service;

namespace Shops.Tests.Service
{
    public class ShopServiceTest
    {
        private ShopsService _shopsService;

        [SetUp]
        public void Setup()
        {
            _shopsService = new ShopsService();
        }

        [TestCase("apple", "Apple", "aPPle")]
        [TestCase("COCACOLA", "CocaCola", "COCACOLa")]
        public void RegisterExistingProductName_ThrowProductNameExistsException(string name1, string name2,
            string name3)
        {
            Assert.Catch<ProductNameExistsException>(() =>
            {
                _shopsService.RegisterProductName(name1);
                _shopsService.RegisterProductName(name2);
                _shopsService.RegisterProductName(name3);
            });
        }

        [Test]
        public void RegisterProductName()
        {
            _shopsService.RegisterProductName("name1");
            _shopsService.RegisterProductName("name2");
            _shopsService.RegisterProductName("name3");
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

            ProductName apple = _shopsService.RegisterProductName("apple");
            Shop lowShop = _shopsService.Create(shopNameWithLowestPrice, "Some st. 1");
            Shop firstShop = _shopsService.Create("First", "Some st. 1");
            Shop secondShop = _shopsService.Create("Second", "Some st. 1");


            _shopsService.AddProductToShop(lowShop, apple, 0, lowestPrice);
            _shopsService.AddProductToShop(firstShop, apple, 0, lowestPrice + 1);
            _shopsService.AddProductToShop(secondShop, apple, 0, lowestPrice + 2);


            Shop lowestShop = _shopsService.FindShopWithLowestPrice(apple);
            Product lowestProduct = lowestShop.FindProduct(apple);
            Assert.AreEqual(lowShop.Name, shopNameWithLowestPrice);
            Assert.AreEqual(lowestProduct.Price, lowestPrice);
        }

        [Test]
        public void FindShopWithLowestPrice_ThrowShopNotFoundException()
        {
            ProductName apple = _shopsService.RegisterProductName("apple");
            Assert.Catch<ShopNotFoundException>(() => _shopsService.FindShopWithLowestPrice(apple));
        }

        [Test]
        public void BuyProduct_CustomerBalanceAndProductCountChanged()
        {
            int oldBalance = 1000;
            int quantityToBuy = 5;
            int oldProductCount = 5;
            var customer = new Customer(oldBalance);

            ProductName apple = _shopsService.RegisterProductName("apple");
            Shop shop = _shopsService.Create("BestShop", "Tyta st. 1");
            shop = _shopsService.AddProductToShop(shop, apple, oldProductCount, 10);
            
            // ToDo: Buн changes Customer and Shop but only one returns
            customer = _shopsService.Buy(customer, shop, apple, quantityToBuy);
            Product product = _shopsService.GetShop(shop.Id).FindProduct(apple);

            Assert.AreEqual(customer.Balance, oldBalance - quantityToBuy * product.Price,
                "New customer balance is incorrect");
            Assert.AreEqual(product.Count, (oldProductCount - quantityToBuy), "New product count is incorrect");
        }

        [Test]
        public void BuyProduct_ThrowBalanceInsufficientException()
        {
            var customer = new Customer(0);
            ProductName apple = _shopsService.RegisterProductName("apple");
            Shop shop = _shopsService.Create("BestShop", "Tyta st. 1");

            shop = _shopsService.AddProductToShop(shop, apple, 10, 10);
            Assert.Catch<BalanceInsufficientException>(()
                => _shopsService.Buy(customer, shop, apple, 1));
        }

        [Test]
        public void ChangeProductCount()
        {
            ProductName apple = _shopsService.RegisterProductName("apple");
            Shop shop = _shopsService.Create("BestShop", "Tyta st. 1");
            shop = _shopsService.AddProductToShop(shop, apple, 10, 0);
            shop = shop.ChangeProductCount(apple, 5);
            
            Assert.AreEqual(shop.FindProduct(apple).Count, 5);
        }
    }
}