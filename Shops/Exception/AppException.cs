namespace Shops.Exception
{
    public class AppException : System.Exception
    {
        public AppException() { }

        public AppException(string message)
            : base(message)
        {
        }
    }
}