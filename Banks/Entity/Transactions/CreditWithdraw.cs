using System;
using Banks.Entity.Accounts;

namespace Banks.Entity.Transactions
{
    public class CreditWithdraw : Transaction
    {
        public CreditWithdraw(Account account)
            : base(account)
        {
        }

        public override void Withdraw(int sum)
        {
            if (To is CreditAccount creditAccount)
            {
                if (creditAccount.Balance - sum < -creditAccount.Limit)
                    throw new Exception("Transaction: credit limit exceeded");

                To.Caretaker.Backup();
                To.UpdateBalance(-sum);
            }
            else
            {
                NextTransaction?.Withdraw(sum);
            }
        }
    }
}