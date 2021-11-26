using System;
using Banks.Entity.Accounts;

namespace Banks.Entity.Transactions
{
    // https://refactoring.guru/ru/design-patterns/chain-of-responsibility
    public class Transaction : ITransaction
    {
        public Transaction(Account from, Account to)
        {
            From = from;
            To = to;
        }

        public Transaction(Account account)
            : this(null, account)
        {
        }

        protected Account From { get; }
        protected Account To { get; }

        protected ITransaction NextTransaction { get; private set; }

        public ITransaction SetNext(ITransaction transactionChain)
        {
            NextTransaction = transactionChain;
            return transactionChain;
        }

        public virtual void Put(int sum)
        {
            NextTransaction = new PutTransaction(To);
            NextTransaction.Put(sum);
        }

        public virtual void Withdraw(int sum)
        {
            NextTransaction = new DebitWithdraw(To);

            NextTransaction
                .SetNext(new CreditWithdraw(To));
            NextTransaction.Withdraw(sum);
        }

        public virtual void Transfer(int sum)
        {
            NextTransaction = new DebitTransfer(From, To);
            NextTransaction
                .SetNext(new CreditTransfer(From, To));
            NextTransaction.Transfer(sum);
        }

        public void Undo()
        {
            From.Caretaker.Undo();
            To?.Caretaker.Undo();
        }
    }
}