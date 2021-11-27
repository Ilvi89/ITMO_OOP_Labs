using System;
using Banks.Entity.Accounts;

namespace Banks.Entity.Transactions
{
    public class DebitWithdraw : Transaction
    {
        public DebitWithdraw(Account account)
            : base(account)
        {
        }

        public override void Withdraw(int sum)
        {
            if (To is DebitAccount debitAccount)
            {
                if (sum > debitAccount.Balance)
                    throw new Exception("Transaction: balance in negative");
                if (!debitAccount.IsVerified && sum > 1000)
                    throw new Exception("Transaction: withdraw from unverified account must be less 1000");

                To.Caretaker.Backup();
                To.UpdateBalance(-sum);
            }
            else
            {
                NextTransaction?.Withdraw(-sum);
            }
        }
    }
}