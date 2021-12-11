using System.Collections.Generic;
using BackupsExtra.Algo.Cut;
using BackupsExtra.Algo.GetExtreme;
using BackupsExtra.Algo.Save;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            IRestorePointRepo repo = new RestoreRepo();
            var watched = new List<string> { "1.txt", "2.txt" };
            var job = new BackupJobExtra(
                "Test",
                watched,
                Logger.GetInstance(),
                repo,
                CutType.Delete,
                new CountGetExtreme(repo, 1));

            var app = new App();
            app.Run(job, "data");
            job.CreateRestorePoint(SaveAlgoType.Split);
            job.CreateRestorePoint(SaveAlgoType.Split);
            job.CreateRestorePoint(SaveAlgoType.Split);
            job.CreateRestorePoint(SaveAlgoType.Split);
            job.CreateRestorePoint(SaveAlgoType.Split);
            job.CreateRestorePoint(SaveAlgoType.Split);
            job.CreateRestorePoint(SaveAlgoType.Split);

            app.Save("data");
        }
    }
}