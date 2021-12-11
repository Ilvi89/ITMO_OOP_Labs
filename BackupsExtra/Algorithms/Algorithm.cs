using BackupsExtra.Algorithms.Cut;
using BackupsExtra.Entity;

namespace BackupsExtra.Algorithms
{
    public class Algorithm : IAlgorithm
    {
        protected IAlgorithm NextChain { get; private set; }

        public IAlgorithm SetNext(IAlgorithm chain)
        {
            NextChain = chain;
            return NextChain;
        }

        public virtual void Cut(BackupJobExtra backupJobExtra)
        {
            NextChain = new CutAlgorithm();
            NextChain.Cut(backupJobExtra);
        }

        public virtual void Save(BackupJobExtra backupJobExtra)
        {
            NextChain = new CutAlgorithm();
            NextChain.SetNext(new)
        }
    }
}