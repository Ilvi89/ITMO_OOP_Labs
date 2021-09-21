using System.Runtime.Serialization;

namespace Shops.Exception
{
    public class ProductAlreadyExistException : ShopsException
    {
        public ProductAlreadyExistException()
        {
        }

        public ProductAlreadyExistException(string productName)
            : base("Product \"{productName}\" already exist")
        {
        }

        public ProductAlreadyExistException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected ProductAlreadyExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}