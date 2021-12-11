namespace BackupsExtra.Algorithms.Cut
{
    public interface IGetLastAvailableRestorePoint
    {
        public void Execute(BackupJobExtra backupJobExtra);
    }
}