using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class DoorSimulator : IDoor
    {
        private bool doorLocked = true;

        public event EventHandler doorOpen;
        public event EventHandler doorClose;

        public virtual void OnDoorOpen()
        {
            doorOpen?.Invoke(this,null);
        }

        public virtual void OnDoorClose()
        {
            doorClose?.Invoke(this, null);
        }

        public void unlockDoor()
        {
            doorLocked = false;
        }

        public void lockDoor()
        {
            doorLocked = true;
        }

        public bool DoorLockStatus
        {
            get { return doorLocked; }
            set { doorLocked = value; }
        }
    }
}
