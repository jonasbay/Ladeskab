using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ladeskab;
using NSubstitute;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestLogFile
    {
        private LogFile uut_;
        private LogData logdata_;
        private string id_;
        private string date_;
        private string state_;


        [SetUp]
        public void setup()
        {
            uut_ = new LogFile();
        }

        [Test]
        public void logDoorUnlockedReceivedCorrectInfo()
        {
            uut_.logDoorUnlocked(1234);

            id_ = uut_.logfileList[0].Id.ToString();
            date_ = uut_.logfileList[0].Date;
            state_ = uut_.logfileList[0].State;

            string alle = id_ + date_ + state_;

            string TimeNow = DateTime.Now.ToString("dd/MM/yyyy");
            Assert.That(alle, Is.EqualTo($"1234{TimeNow}Unlocked"));
        }
        [Test]
        public void logDoorLockedReceivedCorrectInfo()
        {
            uut_.logDoorLocked(1234);

            id_ = uut_.logfileList[0].Id.ToString();
            date_ = uut_.logfileList[0].Date;
            state_ = uut_.logfileList[0].State;

            string alle = id_ + date_ + state_;

            string TimeNow = DateTime.Now.ToString("dd/MM/yyyy");
            Assert.That(alle, Is.EqualTo($"1234{TimeNow}Locked"));
        }
    }
}
