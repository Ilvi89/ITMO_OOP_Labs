using System;
using BackupsExtra.Entity;

namespace BackupsExtra.Repo
{
    public interface IRestorePointRepo
    {
        public RestorePoint Save(RestorePoint restorePoint);
        public RestorePoint DeleteLatter(RestorePoint restorePoint);
        public RestorePoint DeleteLatter(DateTime dateTime);
        public RestorePoint GetByOrder(int count);
        public RestorePoint GetPrev(RestorePoint restorePoint);
    }
}