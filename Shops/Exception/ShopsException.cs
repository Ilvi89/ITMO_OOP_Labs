using System;
using System.Runtime.Serialization;

namespace Shops.Exception
{
    [Serializable]
    public class ShopsException : System.Exception
    {
        public ShopsException() { }

        public ShopsException(string message)
            : base(message)
        {
        }

        public ShopsException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected ShopsException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}