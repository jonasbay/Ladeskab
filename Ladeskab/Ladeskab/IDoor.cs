using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class doorOpenEvent : EventArgs
    {
        public bool Status { get; set; }
    }

    public class doorCloseEvent : EventArgs
    {
        public bool Status { get; set; }
    }

    public interface IDoor
    {
        bool unlockDoor();
        bool lockDoor();
        event EventHandler<doorOpenEvent> doorOpen;
        event EventHandler<doorCloseEvent> doorClose;
    }
}
