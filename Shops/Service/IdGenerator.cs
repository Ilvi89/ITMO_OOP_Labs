namespace Shops.Service
{
    public class IdGenerator
    {
        private int cur;

        public string New()
        {
            return cur++.ToString();
        }
    }
}