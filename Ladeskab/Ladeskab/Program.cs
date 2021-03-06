﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;


namespace Ladeskab
{
    class Program
    {
        static void Main(string[] args)
        {
            DoorSimulator door = new DoorSimulator();
            RFIDreaderSimulator rfidReader = new RFIDreaderSimulator();
            Display display = new Display(new ConsoleWriteLine());
            UsbChargerSimulator USBCharger = new UsbChargerSimulator();
            ChargeControl CC = new ChargeControl(USBCharger, display);
            LogFile logfile = new LogFile();

            StationControl SC = new StationControl(CC, door, display, logfile, rfidReader);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.OnRfidRead(id);
                        break;

                    default:
                        break;
                }
            } while (!finish);
        }
    }
}
