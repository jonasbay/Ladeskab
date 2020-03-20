using System;
using System.CodeDom;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using DoorSimulator = Ladeskab.DoorSimulator;

namespace Ladeskab
{
    [TestFixture]
    public class TestDoorSimulator
    {
        private DoorSimulator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new DoorSimulator();
        }

        [Test]
        public void doorOpenEvent()
        {
            var command

            Assert.That(_uut.doorOpen.didStuff);
        }
    }
}