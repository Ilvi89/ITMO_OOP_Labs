using System;

namespace Banks.Entity.Banks
{
    public class BankTimeProvider
    {
        public BankTimeProvider(DateTime currentDate, DateTime lastAccountsUpdate)
        {
            CurrentDate = currentDate;
            LastAccountsUpdate = lastAccountsUpdate;
        }

        public DateTime CurrentDate { get; set; }
        public DateTime LastAccountsUpdate { get; set; }
    }
}