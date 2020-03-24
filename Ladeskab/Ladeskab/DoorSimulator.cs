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
        private bool doorLocked = false;

        public event EventHandler doorOpen;
        public event EventHandler doorClose;

        public void OnDoorOpen()
        {
            if (DoorIsLocked == false)
            {
                doorOpen?.Invoke(this, null);
            }
            else
            {
                Console.WriteLine("Door is locked");
            }
        }

        public void OnDoorClose()
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

        public bool DoorIsLocked
        {
            get { return doorLocked; }
            set { doorLocked = value; }
        }
    }
}
