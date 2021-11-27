using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Entity.Accounts;
using Banks.Entity.Clients;
using Banks.Entity.Transactions;

namespace Banks.Entity.Banks
{
    public class Bank
    {
        public Bank(string id, List<Client> clients, List<Account> accounts)
        {
            Clients = clients;
            Accounts = accounts;
            Time = new BankTimeProvider(DateTime.Now, DateTime.Now);
            Id = id;
        }

        public Bank(string id)
            : this(id, new List<Client>(), new List<Account>())
        {
        }

        public string Id { get; }
        public List<Client> Clients { get; }
        public List<Account> Accounts { get; }
        public BankTimeProvider Time { get; }

        public void AddClient(Client client)
        {
            // ToDo: change exception
            if (Clients.Exists(x => x.Id == client.Id))
                throw new Exception("Bank: client exist");
            Clients.Add(client);
        }

        public void AddAccountToClient(Client client, Account account)
        {
            if (!Clients.Exists(x => x.Id == client.Id))
                throw new Exception("Bank: client not exist");
            if (client.Passport != null)
                Accounts.Add(new Verified(account));
            else
                Accounts.Add(account);
        }

        public void Put(string accountId, int sum)
        {
            UpdateAccountsInterest();
            Account account = Accounts.FirstOrDefault(a => a.Id == accountId)
                              ?? throw new Exception("Bank: account not found");
            new Transaction(account).Put(sum);
        }

        public void Withdraw(string accountId, int sum)
        {
            UpdateAccountsInterest();
            Account account = Accounts.FirstOrDefault(a => a.Id == accountId)
                              ?? throw new Exception("Bank: account not found");

            new Transaction(account).Withdraw(sum);
        }

        public void CancelTransaction(string fromId, string toId)
        {
            UpdateAccountsInterest();
            Account fromAccount = Accounts.FirstOrDefault(account => account.Id == fromId)
                                  ?? throw new Exception("Bank: account not found");
            Account toAccount = toId != null
                ? Accounts.FirstOrDefault(account => account.Id == fromId)
                  ?? throw new Exception("Bank: account not found")
                : null;

            new Transaction(fromAccount, toAccount).Undo();
        }

        public void UpdateAccountsInterest()
        {
            foreach (Account account in Accounts)
            {
                if ((Time.CurrentDate - account.LastInterestCharge).Days < 1) continue;
                account.CalculateDailyInterest((Time.CurrentDate - Time.LastAccountsUpdate).Days, Time.CurrentDate);
            }
        }

        public void ChargeInterestOnBalance()
        {
            Accounts.ForEach(account => account.UpdateBalance(account.CurrentInterestOnBalance));
            Accounts.ForEach(account => account.CurrentInterestOnBalance = 0);
            Time.LastAccountsUpdate = Time.CurrentDate;
        }
    }
}