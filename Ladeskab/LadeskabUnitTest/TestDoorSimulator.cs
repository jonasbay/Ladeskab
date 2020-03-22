using System;
using System.CodeDom;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using NSubstitute.Exceptions;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab
{
    [TestFixture]
    public class TestDoorSimulator
    {
        private DoorSimulator _uut;
        private bool _doorStatus;

        [SetUp]
        public void Setup()
        {
            _uut = new DoorSimulator();
        }

        [Test]
        public void TestDoorOpenEvent()
        {
            _doorStatus = false;
            _uut.doorOpen += (o, e) => _doorStatus = true;
            _uut.OnDoorOpen();
            Assert.That(_doorStatus);
        }

        [Test]
        public void TestDoorCloseEvent()
        {
            _doorStatus = false;
            _uut.doorClose += (o, e) => _doorStatus = true;
            _uut.OnDoorClose();
            Assert.That(_doorStatus);
        }

        [Test]
        public void testDoorIsLocked_withDoorLockStatusFunction()
        {
            _uut.DoorLockStatus = true;
            Assert.That(_uut.DoorLockStatus, Is.True);
        }

        [Test]
        public void testDoorIsUnlocked_withDoorLockStatusFunction()
        {
            _uut.DoorLockStatus = false;
            Assert.That(_uut.DoorLockStatus, Is.False);
        }

        [Test]
        public void testLockDoorFunction()
        {
            _uut.lockDoor();
            Assert.That(_uut.DoorLockStatus, Is.True);
        }

        [Test]
        public void testUnlockDoorFunction()
        {
            _uut.unlockDoor();
            Assert.That(_uut.DoorLockStatus, Is.False);
        }
    }
}