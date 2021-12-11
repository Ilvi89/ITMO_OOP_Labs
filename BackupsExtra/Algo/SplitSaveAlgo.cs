using System;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo
{
    public class SplitSaveAlgo : SaveAlgo
    {
        public SplitSaveAlgo(IRestorePointRepo restorePointRepo)
            : base(restorePointRepo)
        {
        }

        public override RestorePoint Save(RestorePoint restorePoint)
        {
            throw new NotImplementedException();
        }
    }
}