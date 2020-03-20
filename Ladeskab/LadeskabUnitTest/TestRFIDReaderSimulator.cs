using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LadeskabUnitTest
{
    [TestFixture]
    class TestRFIDReaderSimulator
    {
        private TestRFIDReaderSimulator _uut;
        private bool _doorStatus;

        [SetUp]
        public void Setup()
        {
            _uut = new TestRFIDReaderSimulator();
        }

        [Test]
        public void TestDoorOpenEvent()
        {
            _doorStatus = false;
            _uut.RFIDEvent
            _uut.RFIDEvent += (o, e) => _doorStatus = true;
            _uut.OnDoorOpen();
            Assert.That(_doorStatus);
        }
    }
}

public event EventHandler<int> RFIDEvent;

public virtual void OnRfidRead(int e)
{
RFIDEvent?.Invoke(this, e);
}
