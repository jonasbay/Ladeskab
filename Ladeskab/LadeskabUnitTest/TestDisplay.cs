using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Ladeskab;
using NSubstitute;

namespace LadeskabUnitTest
{
    [TestFixture]
    public class TestDisplay
    {
        private IDisplay _uut;
        private IConsoleWriteLine _consoleWriteLine;

        [SetUp]
        public void setup()
        {
            _consoleWriteLine = Substitute.For<IConsoleWriteLine>();
            _uut = new Display(_consoleWriteLine);
  
        }

        //se https://nsubstitute.github.io/help/received-calls/ for mere hjælp!
        [Test]
        public void ChargeMessageDidWriteLineRecieveMessage()
        {
            //Act:
            _uut.showChargeMsg("This is charge message");
            //Assert:
            _consoleWriteLine.DidNotReceive().writeLine("");
        }

        [Test]
        public void StationMessageDidWriteLineRecieveMessage()
        {
            //Act:
            _uut.showStationMsg("This is charge message");
            //Assert:
            _consoleWriteLine.DidNotReceive().writeLine("");
        }

    }
}
