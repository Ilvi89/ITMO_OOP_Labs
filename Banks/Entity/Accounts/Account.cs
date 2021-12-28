using System;
using Banks.Entity.Clients;
using Banks.Entity.Memento;

namespace Banks.Entity.Accounts
{
    public abstract class Account
    {
        protected Account(string id, int balance, string ownerId, float interestOnBalance = 0, bool isVerified = false)
        {
            Balance = balance;
            Id = id;
            OwnerId = ownerId;
            InterestOnBalance = interestOnBalance;
            Caretaker = new Caretaker(this);
            IsVerified = isVerified;
        }

        public float InterestOnBalance { get; }

        public string Id { get; }

        public DateTime LastInterestCharge { get; private set; }
        public Caretaker Caretaker { get; }

        public string OwnerId { get; }
        public bool IsVerified { get; }

        public int CurrentInterestOnBalance { get; set; }
        public virtual int Balance { get; protected set; }

        public void UpdateBalance(int sum)
        {
            Balance += sum;
        }

        // https://www.raiffeisen.ru/wiki/kak-rasschitat-procenty-po-vkladu/
        public void CalculateDailyInterest(int days, DateTime updateDate)
        {
            CurrentInterestOnBalance += (int)Math.Floor(InterestOnBalance / 365 * Balance * days / 100);
            LastInterestCharge = updateDate;
        }

        public BalanceMemento Save()
        {
            return new BalanceMemento(Balance);
        }

        public void Restore(BalanceMemento memento)
        {
            Balance = memento.GetState();
        }
    }
}