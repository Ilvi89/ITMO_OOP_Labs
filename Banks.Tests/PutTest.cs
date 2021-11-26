using System;
using Banks.Entity.Accounts;
using Banks.Entity.Banks;
using Banks.Entity.Clients;
using NUnit.Framework;

namespace Banks.Tests
{
    public class PutTest
    {
        private Bank _bank;
        private Client _client;
        private DebitAccount _debitAccount;
        
        [SetUp]
        public void Setup()
        {
            _bank = new Bank("123");
            _client = Client.Builder("1", "Ilya", "Pizik").GetClient();
            _debitAccount = new DebitAccount("1", 100, _client.Id, 3.65f);
            _bank.AddClient(_client);
            _bank.AddAccountToClient(_client, _debitAccount);
        }

        [Test]
        public void Put()
        {
            Assert.AreEqual("1", _debitAccount.Id);
            _bank.Put(_debitAccount.Id, 100);
            Assert.AreEqual(200, _debitAccount.Balance);
        }

        [Test]
        public void CancelPut()
        {
            _bank.CancelTransaction(_debitAccount.Id, null);
            Assert.AreEqual(100, _debitAccount.Balance);
        }
    }
}