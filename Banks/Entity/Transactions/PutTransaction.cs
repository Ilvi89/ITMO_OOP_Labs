using Banks.Entity.Accounts;

namespace Banks.Entity.Transactions
{
    public class PutTransaction : Transaction
    {
        public PutTransaction(Account account)
            : base(account)
        {
        }

        public override void Put(int sum)
        {
            To.Caretaker.Backup();
            To.UpdateBalance(sum);
        }
    }
}