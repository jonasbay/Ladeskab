using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ladeskab;
using NSubstitute;
using System.IO;


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
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            uut_.writeLine("writeLine message");

            Assert.That(stringWriter.ToString(), Is.EqualTo("writeLine message\r\n"));
        }

    }
}
