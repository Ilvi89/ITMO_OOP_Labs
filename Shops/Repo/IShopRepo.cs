using Shops.Entity;

namespace Shops.Repo
{
    public interface IShopRepo
    {
        public Shop Save(Shop shop);
        public Shop GetById(string id);
    }
}