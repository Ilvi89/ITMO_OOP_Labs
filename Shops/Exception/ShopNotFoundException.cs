using System.Runtime.Serialization;

namespace Shops.Exception
{
    public class ShopNotFoundException : ShopsException
    {
        public ShopNotFoundException()
            : base("Shop not found")
        {
        }

        public ShopNotFoundException(string message)
            : base(message)
        {
        }

        public ShopNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected ShopNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}