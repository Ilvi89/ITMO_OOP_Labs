using System;
using Banks.Entity.Clients;

namespace Banks.Entity.Accounts
{
    public class CreditAccount : Account
    {
        public CreditAccount(string id, int balance, string ownerId, int limit, int fee, bool isVerified)
            : base(id, balance, ownerId, 0, isVerified)
        {
            Limit = limit;
            Fee = fee;
        }

        public float Fee { get; }
        public int Limit { get; }

        public override int Balance
        {
            get => base.Balance < 0
                ? base.Balance - ((int)(Fee / 1000) * Math.Abs(base.Balance))
                : base.Balance;
            protected set => base.Balance = value;
        }
    }
}