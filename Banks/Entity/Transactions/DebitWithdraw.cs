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