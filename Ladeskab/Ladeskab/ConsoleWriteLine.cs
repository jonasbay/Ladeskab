using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ladeskab
{
    public class ConsoleWriteLine : IConsoleWriteLine
    {
        StringWriter stringWriter;
        StringReader reader;
        public void writeLine(string message)
        {
            //Console.WriteLine(message);
            reader = new StringReader(message);
            stringWriter = new StringWriter();
            stringWriter.Write(reader);
        }
    }
}
