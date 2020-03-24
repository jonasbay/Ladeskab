using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state = LadeskabState.Available;
        private IChargeControl _charger;
        private IDoor _door;
        private IDisplay _display;
        private ILogFile _logfile;
        private IRFIDreader _rfid;
        private int _oldId;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        public StationControl(IChargeControl chargeControl,
            IDoor door, IDisplay display, ILogFile logfile, IRFIDreader rfid)
        {
            _charger = chargeControl;
            _door = door;
            door.doorClose += doorClosed;
            door.doorOpen += doorOpened;
            _display = display;
            _logfile = logfile;
            _rfid = rfid;
            _rfid.RFIDEvent += RfidDetected;
        }

        

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(object obj, int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.IsConnected())
                    {
                        _door.lockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        _logfile.logDoorLocked(id);

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _display.showStationMsg("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                        _display.showStationMsg("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    Console.WriteLine("State - doorOpen");
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.unlockDoor();
                        _logfile.logDoorUnlocked(id);

                        _display.showStationMsg("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("SC: Forkert RFID tag");
                        _display.showStationMsg("Forkert RFID tag");
                    }

                    break;
                //
            }
        }

        private void doorOpened(object obj, EventArgs e)
        {
            _state = LadeskabState.DoorOpen;
            _display.showStationMsg("Tilslut telefon");
        }

        private void doorClosed(object obj, EventArgs e)
        {
            _state = LadeskabState.Available;
            _display.showStationMsg("Indlæs RFID");
        }
    }
}