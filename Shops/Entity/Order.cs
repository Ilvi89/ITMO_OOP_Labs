namespace Shops.Entity
{
    public class Order : Entity
    {
        public Order(string id, string customerId, string productId, int count)
        {
            Id = id;
            CustomerId = customerId;
            ProductId = productId;
            Count = count;
        }

        public string CustomerId { get; }
        public string ProductId { get; }
        public int Count { get; }
    }
}