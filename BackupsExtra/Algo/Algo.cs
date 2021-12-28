using BackupsExtra.Repo;

namespace BackupsExtra.Algo
{
    public abstract class Algo
    {
        protected Algo(IRestorePointRepo restorePointRepo)
        {
            RestorePointRepo = restorePointRepo;
        }

        public IRestorePointRepo RestorePointRepo { get; }
    }
}