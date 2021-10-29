using Shops.Entity;
using Shops.Exception;

namespace Shops.Service
{
    public class OrderService
    {
        private readonly CustomerService _customerService;
        private readonly IdGenerator _generator;
        private readonly ProductService _productService;

        public OrderService(IdGenerator generator, ProductService productRepo, CustomerService customerService)
        {
            _generator = generator;
            _productService = productRepo;
            _customerService = customerService;
        }

        public Order Create(string customerId, string productId, int count)
        {
            Product product = _productService.GetById(productId);
            Customer customer = _customerService.GetById(customerId);
            if (product.Count < count) throw new EntityNotFoundException(productId);
            if (customer.Balance < product.Price * count) throw new EntityNotFoundException(customerId);

            _productService.ChangeCount(productId, product.Count - count);
            _customerService.SpendMoney(customer.Id, product.Price * count);

            return new Order(_generator.New(), customer.Id, product.Id, count);
        }
    }
}