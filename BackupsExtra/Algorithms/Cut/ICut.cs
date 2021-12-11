using BackupsExtra.Entity;

namespace BackupsExtra.Algorithms.Cut
{
    public interface ICut
    {
        public void Execute(RestorePoint restorePoint);
    }
}