using System;

namespace Shops.Entity
{
    public class Customer
    {
        public Customer(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; }

        public Customer SpendMoney(int count)
        {
            if (Balance - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "customer balance cannot be negative");
            return new Customer(Balance - count);
        }
    }
}