using System;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.GetExtreme
{
    public class DateGetExtreme : GetExtremeAlgo
    {
        private DateTime _date;
        public DateGetExtreme(IRestorePointRepo repo, DateTime date)
            : base(repo)
        {
            _date = date;
        }

        public override RestorePoint GetExtreme(RestorePoint restorePoint)
        {
            return RestorePointRepo.DeleteLatter(_date);
        }
    }
}