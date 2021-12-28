using System.IO;
using System.IO.Compression;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Save
{
    public class Split : SaveAlgo
    {
        public Split(IRestorePointRepo restorePointRepo, string basePath)
            : base(restorePointRepo, basePath)
        {
        }

        public override RestorePoint Save(RestorePoint restorePoint)
        {
            string resPath = @$"./{BasePath}/RS-{restorePoint.Id}";
            Directory.CreateDirectory(resPath);

            foreach (Backup backup in restorePoint.Backups)
            {
                string backupPath = $"./{backup.Id}";
                File.Create(backupPath + ".txt").Close();
                File.WriteAllLines(
                    backupPath + ".txt",
                    new[] { "adad", restorePoint.Id, backup.Id, backup.OriginalFilePath });
                Directory.CreateDirectory(backupPath);
                File.Move(backupPath + ".txt", backupPath + backupPath + ".txt");

                // ZipFile.CreateFromDirectory(backupPath, backupPath + ".zip");
                // foreach (string file in Directory.GetFiles(backupPath)) File.Delete(file);
                // Directory.Delete(backupPath);
                Directory.Move(backupPath, resPath + backupPath);
            }

            return RestorePointRepo.Save(restorePoint);
        }
    }
}