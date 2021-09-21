using System.Runtime.Serialization;

namespace Shops.Exception
{
    public class ProductAlreadyExist : ShopsException
    {
        public ProductAlreadyExist()
        {
        }

        public ProductAlreadyExist(string productName)
            : base("Product \"{productName}\" already exist")
        {
        }

        public ProductAlreadyExist(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected ProductAlreadyExist(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}