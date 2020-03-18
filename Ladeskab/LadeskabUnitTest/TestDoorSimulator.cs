using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using DoorSimulator = Ladeskab.DoorSimulator;

namespace Ladeskab
{
    [TestClass]
    public class TestDoorSimulator
    {
        private DoorSimulator _doorSimulator;
        [SetUp]
        public void Setup()
        {
            _doorSimulator = new DoorSimulator();
        }

        [Test]
        public void doorOpenEvent()
        {
            _doorSimulator.doorOpen +=
            _doorSimulator.OnDoorOpen();
            Assert.That(_doorSimulator.)
        }
    }
}