using System;
using Banks.Entity.Accounts;

namespace Banks.Entity.Transactions
{
    public class DebitTransfer : Transaction
    {
        public DebitTransfer(Account from, Account to)
            : base(from, to)
        {
        }

        public override void Transfer(int sum)
        {
            if (From is DebitAccount debitAccount)
            {
                if (sum > debitAccount.Balance)
                    throw new Exception("Transaction: balance in negative");

                From.Caretaker.Backup();
                To.Caretaker.Backup();

                From.UpdateBalance(-sum);
                To.UpdateBalance(sum);
            }
            else
            {
                NextTransaction?.Transfer(sum);
            }
        }
    }
}