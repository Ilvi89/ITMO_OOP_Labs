using System.IO;
using BackupsExtra.Entity;
using Newtonsoft.Json;

namespace BackupsExtra
{
    public class App
    {
        private readonly JsonSerializerSettings _settings;
        private BackupJobExtra _backupJob;

        public App()
        {
            this._settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
            };
        }

        public void Save(string dataFile)
        {
            var json = JsonConvert.SerializeObject(_backupJob, _settings);
            File.WriteAllText(dataFile + ".dat", json);
        }

        public void Run(BackupJobExtra backupJob, string dataFile)
        {
            if (File.Exists(dataFile + ".dat"))
            {
                _backupJob = JsonConvert.DeserializeObject<BackupJobExtra>(dataFile + ".dat", _settings);
            }
            else
            {
                File.Create(dataFile + ".dat").Close();
                _backupJob = backupJob;
            }
        }
    }
}