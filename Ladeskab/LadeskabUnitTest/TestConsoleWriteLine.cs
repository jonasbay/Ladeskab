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
    class TestConsoleWriteLine
    {
        private IConsoleWriteLine uut_;

        [SetUp]
        public void setup()
        {
            uut_ = new ConsoleWriteLine();
        }

        
        [Test]
        public void writeLineReceivedString()
        {
            uut_.writeLine("writeLine message");
            string input = Console.ReadLine();
            Assert.AreEqual(input, "writeLine message");
        }
        
    }
}
