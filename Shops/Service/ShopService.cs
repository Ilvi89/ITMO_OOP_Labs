using Shops.Entity;
using Shops.Repo;

namespace Shops.Service
{
    public class ShopService
    {
        private readonly IdGenerator _idGenerator;
        private readonly IShopRepo _shopRepo;

        public ShopService(IdGenerator generator, IShopRepo shopRepo)
        {
            _idGenerator = generator;
            _shopRepo = shopRepo;
        }

        public Shop Create(string name, string address)
        {
            return _shopRepo.Save(new Shop(_idGenerator.New(), name, address));
        }

        public Shop GetById(string id)
        {
            return _shopRepo.GetById(id);
        }
    }
}