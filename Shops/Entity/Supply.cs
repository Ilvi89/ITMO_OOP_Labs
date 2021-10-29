namespace Shops.Entity
{
    public class Supply : Entity
    {
        public Supply(string id, string shopId, string productId, int cout)
        {
            Id = id;
            ShopId = shopId;
            ProductId = productId;
            Cout = cout;
        }

        public string ShopId { get; }
        public string ProductId { get; }
        public int Cout { get; }
    }
}