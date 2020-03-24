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
        private UsbChargerSimulator _usbSimulator;
        private IChargeControl _chargeControl;
        private IDoor _door;
        private ConsoleWriteLine _console;
        private Display _display;
        private LogFile _logfile;
        private IRFIDreader _rfid;
        private int e_;

        [SetUp]
        public void Setup()
        {
            _usbSimulator = Substitute.For<UsbChargerSimulator>();
            _chargeControl = Substitute.For<IChargeControl>();
            _door = Substitute.For<IDoor>();
            _console = Substitute.For<ConsoleWriteLine>();
            _display = Substitute.For<Display>(_console);
            _logfile = Substitute.For<LogFile>();
            _rfid = Substitute.For<IRFIDreader>();
            _uut = new StationControl(_chargeControl, _door, _display, _logfile, _rfid);
        }

        [Test]
        public void TestRfidDetected_lockDoor_Called()
        {
            _chargeControl.IsConnected().Returns(true);

            _rfid.OnRfidRead(1234);

            _door.Received().lockDoor();
        }

        [Test]
        public void TestRfidDetected_StartCharge_Called()
        {
            _chargeControl.IsConnected().Returns(true);

            _rfid.OnRfidRead(1234);

            _chargeControl.Received().StartCharge();
        }

        [Test]
        public void TestRfidDetected_logDoorLocked_Called()
        {
            _chargeControl.IsConnected().Returns(true);

            _rfid.OnRfidRead(1234);

            _logfile.Received().logDoorLocked(1234);
        }


        // TEST FOR RFIDDETECTED - STATE LOCKED //
        [Test]
        public void TestRfidDetected_StateLocked_IDIsOldID_StopCharged_Called()
        {
            // Getting into state locked
            _chargeControl.IsConnected().Returns(true);
            _rfid.OnRfidRead(1234);

            // Raise event in state locked - ID is OLD ID
            _rfid.OnRfidRead(1234);

            // Test if stopCharge is called
            _chargeControl.Received().StopCharge();
        }
    }
}
