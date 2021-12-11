using BackupsExtra.Entity;

namespace BackupsExtra.Repo
{
    public interface IRestorePointRepo
    {
        public RestorePoint Save(RestorePoint restorePoint);
        public void DeleteUpTo(RestorePoint restorePoint);
    }
}