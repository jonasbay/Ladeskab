using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class DoorSimulator : IDoor
    {
        private bool IsTheDoorOpen;
        private bool doorLocked;

        public event EventHandler<doorOpenEvent> doorOpen;
        public event EventHandler<doorCloseEvent> doorClose;

        protected virtual void OnDoorOpen(doorOpenEvent e)
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

        protected virtual void OnDoorClose(doorCloseEvent e)
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
                Console.WriteLine("Door is already open and cannot be unlocked.");
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
    }
}
