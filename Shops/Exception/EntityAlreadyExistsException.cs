namespace Shops.Exception
{
    public class EntityAlreadyExistsException : AppException
    {
        public EntityAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}