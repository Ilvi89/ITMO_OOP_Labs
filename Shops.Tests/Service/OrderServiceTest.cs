using NUnit.Framework;
using Shops.Entity;
using Shops.Repo.RepoImpl;
using Shops.Service;

namespace Shops.Tests.Service
{
    public class OrderServiceTest
    {
        private CustomerService _customerService;
        private OrderService _orderService;
        private ProductService _productService;
        private ShopService _shopService;
        private SupplyService _supplyService;

        [SetUp]
        public void Setup()
        {
            _customerService = new CustomerService(new IdGenerator(), new CustomerRepo());
            _shopService = new ShopService(
                new IdGenerator(),
                new ShopRepo());
            _productService = new ProductService(
                new IdGenerator(),
                new ProductRepo(),
                _shopService);
            _orderService = new OrderService(
                new IdGenerator(),
                _productService,
                _customerService
            );
            _supplyService = new SupplyService(new IdGenerator(), _productService, new SupplyRepo());
        }

        [Test]
        public void CreateOrder_ReturnOrder()
        {
            var customer = _customerService.Create(100);

            Shop shop = _shopService.Create("Lenta", "Tam");
            Product product = _productService.Create("apple", shop.Id, 10);
            _supplyService.New(shop.Id, product.Id, 10);

            Order order = _orderService.Create(customer.Id, product.Id, 5);

            Assert.AreEqual(_productService.GetById(product.Id).Count, 5);
        }
    }
}