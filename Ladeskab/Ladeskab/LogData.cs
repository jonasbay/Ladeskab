using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class LogData
    {
        string date;
        int id;
        string state;

        public LogData(int lId, string lDate, string lState)
        {
            date = lDate;
            id = lId;
            state = lState;
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string State
        {
            get { return state; }
        }
    }
}