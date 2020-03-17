using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    class LogData
    {
        string date;
        int id;
        string state;
        public LogData() { }

        public LogData(int lId, string lDate, string lstate)
        {
            date = lDate;
            id = lId;
            state = lstate;
        }

        public string Date { get; set; }

        public int Id { get; set; }
    }
}
