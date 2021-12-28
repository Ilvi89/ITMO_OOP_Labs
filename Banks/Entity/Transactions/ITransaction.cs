namespace Banks.Entity.Transactions
{
    public interface ITransaction
    {
        ITransaction SetNext(ITransaction transactionChain);
        public void Put(int sum);
        public void Withdraw(int sum);
        public void Transfer(int sum);
        public void Undo();
    }
}