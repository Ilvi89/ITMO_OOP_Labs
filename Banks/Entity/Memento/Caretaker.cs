using System.Collections.Generic;
using System.Linq;
using Banks.Entity.Account;
using Banks.Entity.Memento;

namespace Banks
{
    public class Caretaker
    {
        private readonly Account _account;
        private readonly List<BalanceMemento> _mementos = new ();

        public Caretaker(Account account)
        {
            _account = account;
        }

        public void Backup()
        {
            _mementos.Add(_account.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0) return;

            BalanceMemento memento = _mementos.Last();
            _mementos.Remove(memento);
            _account.Restore(memento);
        }
    }
}