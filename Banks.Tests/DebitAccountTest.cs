using System;
using Banks.Entity.Accounts;
using Banks.Entity.Clients;
using NUnit.Framework;

namespace Banks.Tests.Entity.Account
{
    public class DebitAccountTest
    {
        private DebitAccount _account;
        private Client _client;
        [SetUp]
        public void Setup()
        {
            _client = Client.Builder("1", "Ilya", "Pizik").GetClient();
            _account = new DebitAccount("123", 100000 , _client.Id, 3.65f);
        }

        [Test]
        public void CalculateDailyInterest_CurrentInterestOnBalanceChanged()
        {
            _account.CalculateDailyInterest(1, DateTime.Now);
            Assert.AreEqual(_account.CurrentInterestOnBalance, 10);
            
            _account.UpdateBalance(100000);
            _account.CalculateDailyInterest(2, DateTime.Now);
            Assert.AreEqual(_account.CurrentInterestOnBalance, 50);
        }
    }
}