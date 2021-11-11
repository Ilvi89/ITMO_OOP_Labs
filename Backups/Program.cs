using Backups.Entity;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var fileStorageRepo = new FileStorageRepository("repo");
            var backupJob = new BackupJob("SuperBackup", fileStorageRepo, null);

            backupJob.AddFile("./first.file");
            backupJob.AddFile("./second.file");
            RestorePoint fRp = backupJob.CreateSingleRestorePoint();

            backupJob.RemoveFile("./second.file");
            backupJob.AddFile("./third.file");

            RestorePoint sRp = backupJob.CreateSplitRestorePoint();
        }
    }
}