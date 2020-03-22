using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ladeskab;
using NSubstitute;
using NUnit.Framework;
using UsbSimulator;

namespace LadeskabUnitTest
{
    [TestClass]
    public class StationControlUnitTest
    {

        private StationControl _uut;
        [SetUp]
        public void Setup()
        {
            UsbChargerSimulator usbSimulator = Substitute.For<UsbChargerSimulator>();
            ChargeControl chargeControl = Substitute.For<ChargeControl>(usbSimulator);
            DoorSimulator door = Substitute.For<DoorSimulator>();
            Display display = Substitute.For<Display>();
            //_uut = new StationControl(chargeControl, door, display, logfile, RFIDreader);
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
