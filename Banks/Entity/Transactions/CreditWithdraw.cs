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
                if (!creditAccount.IsVerified && sum > 1000)
                    throw new Exception("Transaction: withdraw from unverified account must be less 1000");

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