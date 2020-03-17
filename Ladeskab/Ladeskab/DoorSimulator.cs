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
        private bool IsTheDoorOpen = false;
        private bool doorLocked = true;

        public event EventHandler<doorOpenEvent> doorOpen;
        public event EventHandler<doorCloseEvent> doorClose;

        public virtual void OnDoorOpen()
        {
            if (doorLocked)
            {
                Console.Write("Door cannot open! Its locked.");
            }
            else
            {
                IsTheDoorOpen = true;
            }
        }

        public virtual void OnDoorClose()
        {
            if (IsTheDoorOpen)
            {
                IsTheDoorOpen = false;
            }
            else
            {
                Console.Write("Door is not open!");
            }
        }

        public bool unlockDoor()
        {
            if (IsTheDoorOpen == true)
            {
                Console.WriteLine("Door is already open and cannot be unlocked!");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool lockDoor()
        {
            if (IsTheDoorOpen == false)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Door is already open and cannot be locked.");
                return false;
            }
        }

        public bool DoorStatus
        {
            get { return IsTheDoorOpen; }
            set { IsTheDoorOpen = value; }
        }

        public bool DoorLockStatus
        {
            get { return doorLocked; }
            set { doorLocked = value; }
        }
    }
}
