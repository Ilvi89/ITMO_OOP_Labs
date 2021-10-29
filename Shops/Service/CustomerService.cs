using System;
using Shops.Entity;
using Shops.Repo;

namespace Shops.Service
{
    public class CustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        private readonly IdGenerator _generator;

        public CustomerService(IdGenerator generator, ICustomerRepo customerRepo)
        {
            _generator = generator;
            _customerRepo = customerRepo;
        }

        public Customer Create(int balance)
        {
            return _customerRepo.Save(new Customer(_generator.New(), balance));
        }

        public Customer GetById(string id)
        {
            return _customerRepo.GetById(id);
        }

        public Customer SpendMoney(string id, int count)
        {
            Customer customer = GetById(id);
            if (customer.Balance - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "customer balance cannot be negative");
            return _customerRepo.Update(new Customer(customer.Id, customer.Balance - count));
        }
    }
}