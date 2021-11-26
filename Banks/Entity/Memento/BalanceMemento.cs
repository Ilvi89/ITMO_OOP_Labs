using System;

namespace Banks.Entity.Memento
{
    public class BalanceMemento : IMemento<int>
    {
        private int _balance;

        public BalanceMemento(int balance)
        {
            _balance = balance;
        }

        public int GetState()
        {
            return _balance;
        }
    }
}