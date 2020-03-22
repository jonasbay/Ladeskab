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
    public class TestChargeControl
    {
        private IChargeControl uut_;

        private IUsbCharger usbCharger_;
        private IDisplay display_;
        private int currentvalue;

        [SetUp]
        public void setup()
        {
            usbCharger_ = Substitute.For<IUsbCharger>();
            display_ = Substitute.For<IDisplay>();
            uut_ = new ChargeControl(usbCharger_, display_);
        }

        [Test]
        public void StartChargingICalled()
        {
            //Act
            uut_.StartCharge();
            //Assert
            usbCharger_.Received(1).StartCharge();
        }
        //Se billede fra Thanh (Coronatilflugten)
        //private ChargeControl uut_;

        [Test]
        public void StopChargingICalled()
        {
            //Act
            uut_.StopCharge();
            //Assert
            usbCharger_.Received(1).StopCharge();
        }

        [TestCase(0)]
        [TestCase(6)]
        [TestCase(499)]
        public void DidDisplayReceiveMessageCurrentZeroOrBetween6and499(int c)
        {
            //Act
            usbCharger_.CurrentValueEvent += (o, e) => currentvalue = c;
            
            uut_.chargingMessages();
            display_.DidNotReceive().showChargeMsg("");
        }

        [Test]
        public void DidStopChargeReceiveCall()
        {
            //Act
            usbCharger_.CurrentValueEvent += (o, e) => currentvalue = 600;

            uut_.chargingMessages();
            display_.Received(1).showChargeMsg("Fejl! Ladning af telefon er stoppet!");
        }
    }
}
