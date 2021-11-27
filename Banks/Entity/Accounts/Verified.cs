namespace Banks.Entity.Accounts
{
    public class Verified : Account
    {
        public Verified(Account account)
            : base(account.Id, account.Balance, account.OwnerId, account.InterestOnBalance)
        {
        }

        public override bool IsVerified => true;
    }
}