using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo
{
    public abstract class SaveAlgo
    {
        private IRestorePointRepo _restorePointRepo;

        protected SaveAlgo(IRestorePointRepo restorePointRepo)
        {
            _restorePointRepo = restorePointRepo;
        }

        public abstract RestorePoint Save(RestorePoint restorePoint);
    }
}