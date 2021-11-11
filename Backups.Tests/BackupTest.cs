using Backups.Entity;
using Isu.Tests;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTest
    {
        [Test]
        public void BackupSplitCreationTest()
        {
            var localStorageRepo = new LocalStorageRepository();
            var backupJob = new BackupJob("SuperBackup", localStorageRepo, null);
            
            backupJob.AddFile("./first.file");
            backupJob.AddFile("./second.file");
            RestorePoint fRp = backupJob.CreateSplitRestorePoint();

            backupJob.RemoveFile("./first.file");
            RestorePoint sRp = backupJob.CreateSplitRestorePoint();

            Assert.AreEqual(localStorageRepo.GetByRestorePointId(sRp.Id).Count, 1);
            Assert.AreEqual(localStorageRepo.GetByRestorePointId(fRp.Id).Count, 2);
            Assert.AreEqual(localStorageRepo.CountOfStorages, 3);
            
            backupJob.AddFile("./first.file");
            backupJob.RemoveFile("./second.file");
            RestorePoint tRp = backupJob.CreateSplitRestorePoint();
            
            Assert.AreEqual(localStorageRepo.CountOfStorages, 4);
            Assert.AreEqual(localStorageRepo.GetByRestorePointId(tRp.Id).Count, 1);
        }
        
        [Test]
        public void BackupSingleCreationTest()
        {
            var fileStorageRepo = new FileStorageRepository();
            var backupJob = new BackupJob("SuperBackup", fileStorageRepo, null);
            
            backupJob.AddFile("./first.file");
            backupJob.AddFile("./second.file");
            RestorePoint fRp = backupJob.CreateSingleRestorePoint();
        }
    }
}