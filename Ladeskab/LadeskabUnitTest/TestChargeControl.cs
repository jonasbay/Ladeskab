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

        [Test]
        public void DidReceiveMessage()
        {
            //Act
            uut_.chargingMessages();
            usbCharger_.Received(1).StartCharge()
        }
    }
}
