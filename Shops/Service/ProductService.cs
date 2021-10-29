using System.Collections.Generic;
using Shops.Entity;
using Shops.Exception;
using Shops.Repo;

namespace Shops.Service
{
    public class ProductService
    {
        private readonly IdGenerator _idGenerator;
        private readonly IProductRepo _productRepo;
        private readonly ShopService _shopService;

        public ProductService(IdGenerator generator, IProductRepo productRepo, ShopService shopService)
        {
            _idGenerator = generator;
            _productRepo = productRepo;
            _shopService = shopService;
        }

        public Product Create(string name, string shopId, int price)
        {
            var productName = new ProductName(name);
            if (_productRepo.GetByShopId(shopId).Find(p => p.Name.Equals(productName)) != null)
                throw new EntityAlreadyExistsException("Shop already have product");
            return _productRepo.Save(new Product(
                _idGenerator.New(),
                productName,
                _shopService.GetById(shopId).Id,
                price,
                0));
        }

        public Product GetById(string id)
        {
            return _productRepo.GetById(id) ?? throw new EntityNotFoundException(id);
        }

        public List<Product> GetByShopId(string shopId)
        {
            return _productRepo.GetByShopId(shopId);
        }

        public List<Product> FindByName(ProductName name)
        {
            return _productRepo.FindByName(name);
        }

        public Product FindWithLowestPrice(ProductName productName)
        {
            return _productRepo.FindWithLowestPrice(productName);
        }

        public Product ChangePrice(string id, int newPrice)
        {
            Product product = GetById(id);
            return _productRepo.Update(
                product.ChangePrice(newPrice));
        }

        public Product ChangeCount(string id, int newCount)
        {
            Product product = GetById(id);
            return _productRepo.Update(
                product.ChangeCount(newCount));
        }
    }
}