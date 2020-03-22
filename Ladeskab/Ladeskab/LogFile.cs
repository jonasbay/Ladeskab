using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class LogFile : ILogFile
    {
        List<LogData> logfile;
        string date_;
        int id_;
        string dataLock = "Locked";
        string dataUnlock = "Unlocked";
        public LogFile() { }
        public void logDoorLocked(int id)
        {
            date_ = DateTime.Now.ToString("dd/MM/yyy");
            id_ = id;
            logfile = new List<LogData>();

            logfile.Add(new LogData(id_, date_, dataLock));
        }
        public void logDoorUnlocked(int id)
        {
            date_ = DateTime.Now.ToString("dd/MM/yyy");
            id_ = id;
            logfile = new List<LogData>();

            logfile.Add(new LogData(id_, date_, dataUnlock));
        }

        public void printLogFile()
        {
            Console.WriteLine(logfile);
        }
    }
}
