using System.IO;
using System.Text.Json;
using System.Xml;
using BackupsExtra.Entity;

namespace BackupsExtra
{
    public class App
    {
        private BackupJobExtra _backupJob;

        public void Run(BackupJobExtra backupJob, string dataFile)
        {
            File.Create(dataFile + ".dat").Close();
            _backupJob = backupJob;
        }

        public async void Save(string dataFile)
        {
            // File.WriteAllText(dataFile + ".dat", JsonSerializer.Serialize(_backupJob));
            await using var fs = new FileStream(dataFile + ".dat", FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync(fs, _backupJob);
        }
    }
}