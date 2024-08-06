using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public class DataLogger : LoggerBase
    {
        public DataLogger(string logDirectory)
            : base(logDirectory, "DataLog")
        {
        }

        public void LogData(string message)
        {
            WriteLog(message);
        }
    }
}

