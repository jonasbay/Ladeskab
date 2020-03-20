using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class Display : IDisplay
    {
        private IConsoleWriteLine Console_;
        public Display(IConsoleWriteLine console)
        {
            Console_ = console;
        }
        
        public void showChargeMsg(string chargeMessage)
        {
            Console_.writeLine(chargeMessage);
        }
        public void showStationMsg(string stationMessage)
        {
            Console_.writeLine(stationMessage);
        }
    }
}
