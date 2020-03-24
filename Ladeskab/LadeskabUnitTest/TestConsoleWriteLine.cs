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
            
            StringReader reader = new StringReader("writeLine message");
            
            uut_.writeLine("writeLine message");
           
            //string input = Console.ReadLine();
            Assert.AreEqual(reader.Read(), "writeLine message");
        }
        
    }
}
