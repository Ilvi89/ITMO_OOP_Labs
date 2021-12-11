using System;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Save
{
    public class Singl : SaveAlgo
    {
        public Singl(IRestorePointRepo restorePointRepo, string basePath)
            : base(restorePointRepo, basePath)
        {
        }

        public override RestorePoint Save(RestorePoint restorePoint)
        {
            throw new NotImplementedException();
        }
    }
}