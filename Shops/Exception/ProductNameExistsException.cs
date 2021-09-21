using System.Runtime.Serialization;

namespace Shops.Exception
{
    public class ProductNameExistsException : ShopsException
    {
        public ProductNameExistsException()
        {
        }

        public ProductNameExistsException(string productName)
            : base("Product called \"{productName}\" already exists")
        {
        }

        public ProductNameExistsException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected ProductNameExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}