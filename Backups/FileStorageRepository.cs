using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Entity;
using Backups.Repository;

namespace Backups
{
    public class FileStorageRepository : IStorageRepository
    {
        private string _basePath;

        public FileStorageRepository(string basePath)
        {
            _basePath = basePath;
        }

        public Storage GetById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Storage> GetByRestorePointId(string restorePointId)
        {
            throw new NotImplementedException();
        }

        public Storage SplitSave(Storage storage)
        {
            string dirPath = @$"./{_basePath}/{storage.RestorePointId}";
            Directory.CreateDirectory(dirPath);

            string path = $"./{storage.Id}";
            File.Create(path).Close();
            File.WriteAllLines(
                path,
                new[] { "adad", storage.Id, storage.OriginalFilePath });
            Directory.Move(path, dirPath + path);

            return storage;
        }

        public List<Storage> SingleSave(List<Storage> storages)
        {
            string dirPath = @$"./{_basePath}/{storages[0].RestorePointId}";
            Directory.CreateDirectory(dirPath);
            foreach (Storage storage in storages)
            {
                string path = $"./{storage.Id}";
                File.Create(path).Close();
                File.WriteAllLines(
                    path,
                    new[] { "adad", storage.Id, storage.OriginalFilePath });
                Directory.Move(path, dirPath + path);
                File.Delete(path);
            }

            ZipFile.CreateFromDirectory(dirPath, dirPath + ".zip");
            foreach (FileInfo file in new DirectoryInfo(dirPath).GetFiles()) file.Delete();
            Directory.Delete(dirPath);
            return storages;
        }
    }
}