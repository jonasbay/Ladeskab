using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ladeskab;
using NSubstitute;
using NUnit.Framework;

namespace LadeskabUnitTest
{
    [TestClass]
    public class StationControlUnitTest
    {

        private StationControl _uut;
        [SetUp]
        public void Setup()
        {
            ChargeControl chargeControl = new Substitute(ChargeControl)
            _uut = new StationControl(chargeControl, door, display, logfile, RFIDreader);
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
