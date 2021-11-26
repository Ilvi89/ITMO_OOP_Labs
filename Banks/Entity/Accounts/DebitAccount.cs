namespace Banks.Entity.Accounts
{
    public class DebitAccount : Account
    {
        public DebitAccount(string id, int balance, string ownerId, float interestOnBalance)
            : base(id, balance, ownerId, interestOnBalance)
        {
        }
    }
}