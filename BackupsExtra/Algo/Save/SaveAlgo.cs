using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Save
{
    public abstract class SaveAlgo
    {
        protected SaveAlgo(IRestorePointRepo restorePointRepo, string basePath)
        {
            RestorePointRepo = restorePointRepo;
            BasePath = basePath;
        }

        protected IRestorePointRepo RestorePointRepo { get; }
        protected string BasePath { get; }

        public abstract RestorePoint Save(RestorePoint restorePoint);
    }
}