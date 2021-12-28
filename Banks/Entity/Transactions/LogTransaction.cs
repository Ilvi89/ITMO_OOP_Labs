using System;

namespace Banks.Entity.Transactions
{
    public class LogTransaction : ITransaction
    {
        private readonly Transaction _transaction;

        public LogTransaction(Transaction transaction)
        {
            _transaction = transaction;
        }

        public ITransaction SetNext(ITransaction transactionChain)
        {
            return _transaction.SetNext(transactionChain);
        }

        public void Put(int sum)
        {
            Console.WriteLine($"Put {sum}");
            _transaction.Put(sum);
        }

        public void Withdraw(int sum)
        {
            Console.WriteLine($"Withdraw {sum}");
            _transaction.Withdraw(sum);
        }

        public void Transfer(int sum)
        {
            Console.WriteLine($"Transfer {sum}");
            _transaction.Transfer(sum);
        }

        public void Undo()
        {
            Console.WriteLine($"Undo");
            _transaction.Undo();
        }
    }
}