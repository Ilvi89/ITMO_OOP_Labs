using System.Runtime.Serialization;

namespace Shops.Exception
{
    public class ProductNotFoundException : ShopsException
    {
        public ProductNotFoundException()
        {
        }

        public ProductNotFoundException(string name)
            : base("Product \"{name}\" not found")
        {
        }

        public ProductNotFoundException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected ProductNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}