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
            _client = _bank.CreateClient("Ilya", "Pizik", "passport");
            _debitAccount = _bank.CreateDebitAccount(_client, 100, 3.65f);
        }

        [Test]
        public void Put()
        {
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