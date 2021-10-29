namespace Shops.Exception
{
    public class EntityNotFoundException : AppException
    {
        public EntityNotFoundException(string id)
            : base($"Entity by {id} not fount")
        {
        }
    }
}