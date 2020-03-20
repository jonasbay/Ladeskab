using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ladeskab
{
    [TestFixture]
    public class TestRFIDReaderSimulator
    {
        private RFIDreaderSimulator _uut;
        private int e_;

        [SetUp]
        public void Setup()
        {
            _uut = new RFIDreaderSimulator();
        }

        [Test]
        public void TestRFIDEvent_IDCorrect()
        {
            _uut.RFIDEvent += (o, e) => e_ = e;
            _uut.OnRfidRead(500000);
            Assert.That(e_, Is.EqualTo(500000));
        }
    }
}
