namespace BackupsExtra.Entity.Backup
{
    public class Backup
    {
        public Backup(string id, string restorePointId, string originalFilePath)
        {
            Id = id;
            RestorePointId = restorePointId;
            OriginalFilePath = originalFilePath;
        }

        public string Id { get; }
        public string RestorePointId { get; }
        public string OriginalFilePath { get; }
    }
}