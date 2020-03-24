using System;
using System.CodeDom;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ladeskab;
using NSubstitute;
using NUnit.Framework;
using UsbSimulator;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class StationControlUnitTest
    {

        private StationControl _uut;
        private IUsbCharger _usbSimulator;
        private IChargeControl _chargeControl;
        private IDoor _door;
        private IConsoleWriteLine _console;
        private IDisplay _display;
        private ILogFile _logfile;
        private IRFIDreader _rfid;
        private int e_;

        [SetUp]
        public void Setup()
        {
            _usbSimulator = Substitute.For<IUsbCharger>();
            _chargeControl = Substitute.For<IChargeControl>();
            _door = Substitute.For<IDoor>();
            _display = Substitute.For<IDisplay>();
            _logfile = Substitute.For<ILogFile>();
            _rfid = Substitute.For<IRFIDreader>();
            _uut = new StationControl(_chargeControl, _door, _display, _logfile, _rfid);
        }

        [Test]
        public void TestRfidDetected_lockDoor_Called()
        {
            _chargeControl.IsConnected().Returns(true);

            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _door.Received().lockDoor();
        }

        [Test]
        public void TestRfidDetected_StartCharge_Called()
        {
            _chargeControl.IsConnected().Returns(true);

            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _chargeControl.Received().StartCharge();
        }

        [Test]
        public void TestRfidDetected_logDoorLocked_Called()
        {
            _chargeControl.IsConnected().Returns(true);

            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _logfile.Received().logDoorLocked(123);
        }

        [Test]
        public void TestRfidDetected_showStationMesage_Called()
        {
            _chargeControl.IsConnected().Returns(true);

            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _display.Received()
                .showStationMsg("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        [Test]
        public void TestRfidDetected_chargerNotConnected()
        {
            _chargeControl.IsConnected().Returns(false);

            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _display.showStationMsg("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }

        [Test]
        public void TestRfidDetected_doorOpened()
        {
            _chargeControl.IsConnected().Returns(true);

            _door.doorOpen += Raise.Event();
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

        }


        // TEST FOR RFIDDETECTED - STATE LOCKED //
        [Test]
        public void TestRfidDetected_StateLocked_idIsOldId_StopCharge_Called()
        {
            // Getting into state locked and raise event twice with same id
            _chargeControl.IsConnected().Returns(true);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _chargeControl.Received().StopCharge();
        }

        [Test]
        public void TestRfidDetected_StateLocked_IDIsOldID_UnlockDoor_Called()
        {
            // Getting into state locked and raise event twice with same id
            _chargeControl.IsConnected().Returns(true);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _door.Received().unlockDoor();
        }

        [Test]
        public void TestRfidDetected_StateLocked_IDIsOldID_logDoorUnlocked_Called()
        {
            // Getting into state locked and raise event twice with same id
            _chargeControl.IsConnected().Returns(true);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _logfile.Received().logDoorUnlocked(123);
        }

        [Test]
        public void TestRfidDetected_StateLocked_IDIsOldID_showStationMsg_Called()
        {
            // Getting into state locked and raise event twice with same id
            _chargeControl.IsConnected().Returns(true);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);

            _display.Received().showStationMsg("Tag din telefon ud af skabet og luk døren");
        }

        [Test]
        public void TestRfidDetected_StateLocked_IDIsNotOldID_showStationMsg_Called()
        {
            // Getting into state locked and raise event twice with different id
            _chargeControl.IsConnected().Returns(true);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 123);
            _rfid.RFIDEvent += Raise.Event<EventHandler<int>>(this, 555);

            _display.Received().showStationMsg("Forkert RFID tag");
        }

        // TEST FOR EVENT DOOROPENED //
        [Test]
        public void TestDoorOpened_RaiseDoorEvent_ShowMessage()
        {
            _door.doorOpen += Raise.Event<EventHandler>();
            _display.Received().showStationMsg("Tilslut telefon");
        }

        // TEST FOR EVENT DOORCLOSED //
        [Test]
        public void TestDoorClosed_RaiseDoorEvent_ShowMessage()
        {
            _door.doorClose += Raise.Event<EventHandler>();
            _display.Received().showStationMsg("Indlæs RFID");
        }
    }
}