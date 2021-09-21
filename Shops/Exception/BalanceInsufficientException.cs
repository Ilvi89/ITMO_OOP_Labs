using System.Runtime.Serialization;

namespace Shops.Exception
{
    public class BalanceInsufficientException : ShopsException
    {
        public BalanceInsufficientException()
        {
        }

        public BalanceInsufficientException(string message)
            : base(message)
        {
        }

        public BalanceInsufficientException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        protected BalanceInsufficientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}