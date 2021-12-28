using System;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Cut
{
    public class Delete : CutAlgo
    {
        public Delete(IRestorePointRepo restorePointRepo)
            : base(restorePointRepo)
        {
        }

        public override RestorePoint UpTo(RestorePoint restorePoint)
        {
            return RestorePointRepo.DeleteLatter(restorePoint);
        }
    }
}