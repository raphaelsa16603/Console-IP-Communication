using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Timers;


namespace Common.Logging
{
    public abstract class LoggerBase
    {
        private readonly System.Timers.Timer _timer;
        protected string LogDirectory;
        protected string LogFileName;

        protected LoggerBase(string logDirectory, string logFileNamePrefix)
        {
            LogDirectory = logDirectory;
            LogFileName = $"{logFileNamePrefix}_{DateTime.Now:yyyyMMdd_HHmm}.log";
            Directory.CreateDirectory(logDirectory);

            _timer = new System.Timers.Timer(1800000); // 30 minutos
            _timer.Elapsed += (sender, args) => CreateNewLogFile(logFileNamePrefix);
            _timer.Start();
        }

        private void CreateNewLogFile(string logFileNamePrefix)
        {
            LogFileName = $"{logFileNamePrefix}_{DateTime.Now:yyyyMMdd_HHmm}.log";
        }

        protected void WriteLog(string message)
        {
            var filePath = Path.Combine(LogDirectory, LogFileName);
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            }
        }
    }
}


