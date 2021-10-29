using System.Collections.Generic;
using Shops.Entity;

namespace Shops.Repo
{
    public interface IProductRepo
    {
        Product GetById(string id);
        List<Product> GetByShopId(string shopId);
        List<Product> FindByName(ProductName name);
        Product FindWithLowestPrice(ProductName productName);
        Product Update(Product product);
        Product Save(Product product);
    }
}