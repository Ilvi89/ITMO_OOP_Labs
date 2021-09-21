using System;

namespace Shops.Entity
{
    public class Customer
    {
        public Customer(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; private set; }

        public void SpendMoney(int count)
        {
            if (Balance - count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "customer balance cannot be negative");
            Balance -= count;
        }
    }
}