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
    [TestClass]
    public class StationControlUnitTest
    {

        private StationControl _uut;
        private UsbChargerSimulator usbSimulator;
        private ChargeControl chargeControl;
        private DoorSimulator door;
        private ConsoleWriteLine console;
        private Display display;
        private LogFile logfile;
        private RFIDreaderSimulator RFIDreader;

        [SetUp]
        public void Setup()
        {
            usbSimulator = Substitute.For<UsbChargerSimulator>();
            chargeControl = Substitute.For<ChargeControl>(usbSimulator);
            door = Substitute.For<DoorSimulator>();
            console = Substitute.For<ConsoleWriteLine>();
            display = Substitute.For<Display>(console);
            logfile = Substitute.For<LogFile>();
            RFIDreader = Substitute.For<RFIDreaderSimulator>();
            _uut = new StationControl(chargeControl, door, display, logfile, RFIDreader);
        }

        [TestMethod]
        public void RfidDetected_LadeskabAvailable_ChargerConnected_DoorUnlocked()
        {
            usbSimulator.SimulateConnected(true);
            RFIDreader.OnRfidRead(1234);

            Assert.That(door.DoorLockStatus);
        }
    }
}
