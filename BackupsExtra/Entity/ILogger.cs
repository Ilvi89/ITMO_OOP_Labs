namespace BackupsExtra.Entity
{
    public enum LogType
    {
        Info,
        Warning,
        Error
    }

    public interface ILogger
    {
        public void Info(string message);
        public void Warning(string message);
        public void Error(string message);
        public void Log(LogType logType, string message);
    }
}