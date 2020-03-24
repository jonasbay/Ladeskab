using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ladeskab;
using NSubstitute;
using UsbSimulator;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestLogFile
    {
        private ILogFile uut_;

        private IUsbCharger usbCharger_;
        private StationControl stationControl_;

        [SetUp]
        public void setup()
        {
            stationControl_ = Substitute.For<StationControl>();
            usbCharger_ = Substitute.For<UsbChargerSimulator>();
            uut_ = new LogFile();
        }
        /*
        [Test]
        public void logDoorUnlockedReceivedCall()
        {
            usbCharger_.Connected = true;
            //stationControl_.RFid
        }
        */
    }
}
