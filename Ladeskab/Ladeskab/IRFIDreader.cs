using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class RFIDreaderEvent : EventArgs
    {
        public bool ID { get; set; }
    }

    interface IRFIDreader
    {
        event EventHandler<RFIDreaderEvent> RFIDEvent;
    }
}
