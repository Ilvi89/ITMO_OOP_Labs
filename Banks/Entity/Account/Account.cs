using System;
using Banks.Entity.Memento;

namespace Banks.Entity.Account
{
    public abstract class Account
    {
        private readonly float _interestOnBalance;
        private int _balance;
        private Caretaker _caretaker;
        private string _id;
        private DateTime _lastInterestCharge;
        private string _ownerId;

        protected Account(string id, int balance, string ownerId, float interestOnBalance)
        {
            _balance = balance;
            _id = id;
            _ownerId = ownerId;
            _interestOnBalance = interestOnBalance;
            _caretaker = new Caretaker(this);
        }

        public virtual int Balance => _balance;

        public int CurrentInterestOnBalance { get; private set; }

        public void UpdateBalance(int sum)
        {
            _balance += sum;
        }

        // https://www.raiffeisen.ru/wiki/kak-rasschitat-procenty-po-vkladu/
        public void CalculateDailyInterest(int days, DateTime updateDate)
        {
            CurrentInterestOnBalance += (int)Math.Floor(_interestOnBalance / 365 * _balance * days / 100);
            _lastInterestCharge = updateDate;
        }

        public BalanceMemento Save()
        {
            return new BalanceMemento(Balance);
        }

        public void Restore(BalanceMemento memento)
        {
            _balance = memento.GetState();
        }
    }
}