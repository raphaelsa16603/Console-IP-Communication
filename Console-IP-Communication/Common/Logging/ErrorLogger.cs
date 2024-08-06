using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public class ErrorLogger : LoggerBase
    {
        public ErrorLogger(string logDirectory)
            : base(logDirectory, "ErrorLog")
        {
        }

        public void LogError(string message)
        {
            WriteLog(message);
        }

        public void LogError(Exception ex)
        {
            WriteLog($"{ex.Message}\n{ex.StackTrace}");
        }
    }
}

