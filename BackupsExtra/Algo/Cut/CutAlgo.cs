using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Cut
{
    public abstract class CutAlgo : Algo
    {
        protected CutAlgo(IRestorePointRepo restorePointRepo)
            : base(restorePointRepo)
        {
        }

        public abstract RestorePoint UpTo(RestorePoint restorePoint);
    }
}