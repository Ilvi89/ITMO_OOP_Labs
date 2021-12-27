using System;

namespace Shops.Entity
{
    public class Customer : Entity
    {
        public Customer(string id, int balance)
        {
            Balance = balance;
            Id = id;
        }

        public int Balance { get; }

        public Customer SpendMoney(int count)
        {
            if (Balance - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "customer balance cannot be negative");
            return new Customer(Id, Balance - count);
        }
    }
}