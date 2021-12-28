using System;

namespace BackupsExtra.Entity
{
    [Serializable]
    public class Backup
    {
        public Backup(string id, string originalFilePath)
        {
            Id = id;
            OriginalFilePath = originalFilePath;
        }

        public string Id { get; }
        public string OriginalFilePath { get; }
    }
}