using System;
using System.Runtime.Serialization;

namespace Shops.Exception
{
    [Serializable]
    public class ShopException : System.Exception
    {
        public ShopException() { }

        public ShopException(string message)
            : base(message)
        {
        }

        public ShopException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected ShopException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}