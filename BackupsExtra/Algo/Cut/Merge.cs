using System.Collections.Generic;
using BackupsExtra.Algo.Save;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Cut
{
    public class Merge : CutAlgo
    {
        public Merge(IRestorePointRepo restorePointRepo)
            : base(restorePointRepo)
        {
        }

        public override RestorePoint UpTo(RestorePoint restorePoint)
        {
            RestorePoint main = restorePoint;
            RestorePoint prev = RestorePointRepo.GetPrev(restorePoint);
            while (prev != null)
            {
                main = Combine(main, prev);
                prev = RestorePointRepo.GetPrev(restorePoint);
            }

            RestorePointRepo.Save(main);
            return main;
        }

        private RestorePoint Combine(RestorePoint main, RestorePoint prev)
        {
            var backups = new List<Backup>(main.Backups);
            if (prev.PointType == SaveAlgoType.Singl) return main;
            foreach (Backup p in prev.Backups)
            {
                if (main.Backups.Find(b => b.Id == p.Id) == null)
                    backups.Add(p);
            }

            return new RestorePoint(main.Id, main.CreatedAt, main.PointType, backups);
        }
    }
}