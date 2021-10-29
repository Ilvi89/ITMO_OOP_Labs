using Shops.Entity;

namespace Shops.Repo
{
    public interface ICustomerRepo
    {
        Customer GetById(string id);
        Customer Update(Customer customer);
        Customer Save(Customer customer);
    }
}