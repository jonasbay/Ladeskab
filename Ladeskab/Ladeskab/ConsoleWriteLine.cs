﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class ConsoleWriteLine : IConsoleWriteLine
    {
        public void writeLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
