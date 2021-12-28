using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.GetExtreme
{
    public abstract class GetExtremeAlgo
    {
        protected GetExtremeAlgo(IRestorePointRepo restorePointRepo)
        {
            RestorePointRepo = restorePointRepo;
        }

        protected IRestorePointRepo RestorePointRepo { get; }
        public abstract RestorePoint GetExtreme(RestorePoint restorePoint);
    }
}