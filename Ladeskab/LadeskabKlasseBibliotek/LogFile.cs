using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class LogFile : ILogFile
    {
        public List<LogData> logfileList { get; }
        string date_;
        int id_;
        string dataLock = "Locked";
        string dataUnlock = "Unlocked";
        public LogFile() 
        {
            logfileList = new List<LogData>();
        }
        public void logDoorLocked(int id)
        {
            date_ = DateTime.Now.ToString("dd/MM/yyyy");
            id_ = id;

            logfileList.Add(new LogData(id_, date_, dataLock));
        }
        public void logDoorUnlocked(int id)
        {
            //date_ = DateTime.Today.ToString();
            date_ = DateTime.Now.ToString("dd/MM/yyyy");
            id_ = id;

            logfileList.Add(new LogData(id_, date_, dataUnlock));
        }


    }
}
