using System;
using System.IO;

namespace Data_Access_Layer
{
    public interface ILogger
    {
        void LogError(string message);
        void LogError(string message, Exception ex);
    }

    // Simple logger implementation
    public class FileLogger : ILogger
    {
        private readonly string _logPath;

        public FileLogger(string logPath = "AppLog.txt")
        {
            _logPath = logPath;
        }

        public void LogError(string message)
        {
            LogToFile(message);
        }

        public void LogError(string message, Exception ex)
        {
            LogToFile($"{message}\nException: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }

        private void LogToFile(string message)
        {
            try
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n";
                File.AppendAllText(_logPath, logMessage);
            }
            catch
            {
                // Fail silently or handle as needed
            }
        }
    }
}
