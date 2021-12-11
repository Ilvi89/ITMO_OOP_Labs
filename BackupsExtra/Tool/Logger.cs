using System;
using System.IO;

namespace BackupsExtra.Entity
{
    // https://github.com/NLog/NLog/wiki/Tutorial#best-practices-for-using-nlog
    // https://stackoverflow.com/questions/8472678/is-it-a-good-practice-to-have-logger-as-a-singleton
    internal class Logger : ILogger
    {
        private static Logger _instance;
        private Logger() { }
        public static Logger GetInstance()
        {
            return _instance ??= new Logger();
        }

        public void Info(string message)
        {
            Log(LogType.Info, message);
        }

        public void Warning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void Err(string message)
        {
            Log(LogType.Error, message);
        }

        public void Log(LogType logType, string message)
        {
            File.AppendAllLines("BackupExtra.log", new[] { $"[{DateTime.Now}] [{logType}]: {message}\n" });
        }
    }
}