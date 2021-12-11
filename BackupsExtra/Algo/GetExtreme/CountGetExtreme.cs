using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.GetExtreme
{
    public class CountGetExtreme : GetExtremeAlgo
    {
        private readonly int _count;

        public CountGetExtreme(IRestorePointRepo restorePointRepo, int count)
            : base(restorePointRepo)
        {
            _count = count;
        }

        public override RestorePoint GetExtreme(RestorePoint restorePoint)
        {
            int count = restorePoint.Backups.Count - _count > 0
                ? restorePoint.Backups.Count - _count
                : 0;
            if (count != 0) return RestorePointRepo.GetByOrder(count);
            return null;
        }
    }
}