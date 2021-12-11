using BackupsExtra.Repo;

namespace BackupsExtra.Algo
{
    public abstract class AgoFabric
    {
        protected AgoFabric(IRestorePointRepo restorePointRepo)
        {
            RestorePointRepo = restorePointRepo;
        }

        protected IRestorePointRepo RestorePointRepo { get; }
    }
}