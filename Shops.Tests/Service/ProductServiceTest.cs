using NUnit.Framework;
using Shops.Entity;
using Shops.Exception;
using Shops.Repo.RepoImpl;
using Shops.Service;

namespace Shops.Tests.Service
{
    public class ProductServiceTest
    {
        private ProductService _productService;
        private ShopService _shopService;

        [SetUp]
        public void Setup()
        {
            _shopService = new ShopService(new IdGenerator(), new ShopRepo());
            _productService = new ProductService(new IdGenerator(), new ProductRepo(), _shopService);
        }

        [TestCase("apple", "Apple", "aPPle")]
        [TestCase("COCACOLA", "CocaCola", "COCACOLa")]
        public void RegisterExistingProductName_ThrowEntityAlreadyExistsException(string name1, string name2,
            string name3)
        {
            string shop1 = _shopService.Create("1", "2").Id;
            string shop2 = _shopService.Create("3", "4").Id;

            Assert.Catch<EntityAlreadyExistsException>(() =>
            {
                _productService.Create(name1, shop1, 100);
                _productService.Create(name2, shop2, 100);
                _productService.Create(name3, shop1, 100);
            });
        }

        [Test]
        public void FindProductWithLowestPrice_ReturnLowestPrice()
        {
            int lowestPrice = 10;
            string productName = "Apple";
            string shopNameWithLowestPrice = "Здесь могла быть ваша реклама";

            Shop lowShop = _shopService.Create(shopNameWithLowestPrice, "Some st. 1");
            Shop firstShop = _shopService.Create("First", "Some st. 1");
            Shop secondShop = _shopService.Create("Second", "Some st. 1");

            _productService.Create(productName, lowShop.Id, lowestPrice);
            _productService.Create(productName, firstShop.Id, lowestPrice + 1);
            _productService.Create(productName, secondShop.Id, lowestPrice + 2);

            Product lowestProduct = _productService.FindWithLowestPrice(new ProductName(productName));
            Assert.AreEqual(lowestProduct.Price, lowestPrice);
            Assert.AreEqual(lowestProduct.ShopId, lowShop.Id);
        }
    }
}