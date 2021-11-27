using System;
using Banks.Entity.Accounts;

namespace Banks.Entity.Transactions
{
    public class CreditTransfer : Transaction
    {
        public CreditTransfer(Account from, Account to)
            : base(from, to)
        {
        }

        public override void Transfer(int sum)
        {
            if (From is CreditAccount creditAccount)
            {
                if (creditAccount.Balance - sum < -creditAccount.Limit)
                    throw new Exception("Transaction: credit limit exceeded");
                if (!creditAccount.IsVerified)
                    throw new Exception("Transaction: transfer from unverified account is prohibited");

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