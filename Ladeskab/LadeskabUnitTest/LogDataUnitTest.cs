using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using NSubstitute;
using NUnit.Framework;
using UsbSimulator;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class LogDataUnitTest
    {
        private LogData _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new LogData(55, "20-02-2020", "Available");
        }

        [Test]
        public void TestGetID()
        {
            Assert.That(_uut.Id, Is.EqualTo(55));
        }

        [Test]
        public void TestSetID()
        {
            _uut.Id = 100;
            Assert.That(_uut.Id, Is.EqualTo(100));
        }

        [Test]
        public void TestGetDate()
        {
            Assert.That(_uut.Date, Is.EqualTo("20-02-2020"));
        }

        [Test]
        public void TestSetDate()
        {
            _uut.Date = "05-05-2010";
            Assert.That(_uut.Date, Is.EqualTo("05-05-2010"));
        }
    }
}