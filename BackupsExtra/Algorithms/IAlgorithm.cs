using BackupsExtra.Entity;

namespace BackupsExtra.Algorithms
{
    public interface IAlgorithm
    {
        IAlgorithm SetNext(IAlgorithm chain);
        public void Cut(BackupJobExtra backupJobExtra);
        public void Save(BackupJobExtra backupJobExtra);
    }
}