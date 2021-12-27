using System.Collections.Generic;
using Shops.Entity;

namespace Shops.Repo.RepoImpl
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public List<Product> GetByShopId(string shopId)
        {
            return Store.FindAll(p => p.ShopId.Equals(shopId));
        }

        public List<Product> FindByName(ProductName name)
        {
            return Store.FindAll(p => p.Name.Equals(name));
        }

        public Product FindWithLowestPrice(ProductName productName)
        {
            Product minProduct = null;

            foreach (Product product in Store)
                if ((minProduct?.Price ?? int.MaxValue) > product.Price) minProduct = product;
            return minProduct;
        }
    }
}