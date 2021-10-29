using Shops.Entity;
using Shops.Repo;

namespace Shops.Service
{
    public class SupplyService
    {
        private readonly IdGenerator _idGenerator;
        private readonly ProductService _productService;
        private readonly ISupplyRepo _supplyRepo;

        public SupplyService(IdGenerator generator, ProductService productService, ISupplyRepo supplyRepo)
        {
            _idGenerator = generator;
            _productService = productService;
            _supplyRepo = supplyRepo;
        }

        public Supply New(string shopId, string productId, int count)
        {
            _productService.ChangeCount(productId, _productService.GetById(productId).Count + count);
            return _supplyRepo.Save(
                new Supply(_idGenerator.New(), shopId, productId, count));
        }
    }
}