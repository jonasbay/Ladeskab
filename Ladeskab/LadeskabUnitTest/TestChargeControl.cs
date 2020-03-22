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
        private IConsoleWriteLine console_;
        private double currentvalue;

        [SetUp]
        public void setup()
        {
            //usbCharger_ = new UsbChargerSimulator();
            usbCharger_ = Substitute.For<UsbChargerSimulator>();
            console_ = Substitute.For<ConsoleWriteLine>();
            display_ = Substitute.For<Display>(console_);
            //display_ = new Display(console_);
                //Substitute.For<new Display (console_)>();
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

        [Test]
        public void StopChargingICalled()
        {
            //Act
            uut_.StopCharge();
            //Assert
            usbCharger_.Received(1).StopCharge();
        }

        [Test]
        public void DidMsgReceiveCall0()
        {
            //Act
            usbCharger_.CurrentValueEvent += (o, e) => currentvalue = 0;
            usbCharger_.CurrentValue = 0;

            uut_.chargingMessages();
            display_.Received(1).showChargeMsg("Ladeværdi er nul");
        }

        [TestCase(1)]
        [TestCase(5)]
        public void DidMsgReceiveCallBetween1And5(double c)
        {
            //Act
            usbCharger_.CurrentValueEvent += (o, e) => currentvalue = c;
            usbCharger_.CurrentValue = c;

            uut_.chargingMessages();
            display_.Received(1).showChargeMsg("Telefonen er nu fuldt opladet. Frakobel telefon.");
        }
        [TestCase(6)]
        [TestCase(499)]
        [TestCase(500)]
        public void DidMsgReceiveCallBetween6And500(double c)
        {
            //Act
            usbCharger_.CurrentValueEvent += (o, e) => currentvalue = c;
            usbCharger_.CurrentValue = c;

            uut_.chargingMessages();
            display_.Received(1).showChargeMsg("Ladning er i gang!");
        }
        [Test]
        public void DidMsgReceiveCallOver500()
        {
            //Act
            usbCharger_.CurrentValueEvent += (o, e) => currentvalue = 600;
            usbCharger_.CurrentValue = 600;

            uut_.chargingMessages();
            display_.Received(1).showChargeMsg("Fejl! Ladning af telefon er stoppet!");
        }
    }
}
