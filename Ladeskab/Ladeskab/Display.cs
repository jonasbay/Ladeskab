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
        string old_stationMsg = "";
        string old_chargeMsg = "";
        string new_chargeMsg;
        string new_stationMsg;
        public Display(IConsoleWriteLine console)
        {
            Console_ = console;
        }
        
        public void showChargeMsg(string chargeMessage)
        {
            new_chargeMsg = old_stationMsg + "\t" + chargeMessage;
            Console_.writeLine(new_chargeMsg);
            old_chargeMsg = chargeMessage;
        }
        public void showStationMsg(string stationMessage)
        {
            new_stationMsg = stationMessage + "\t" + old_chargeMsg;
            Console_.writeLine(new_stationMsg);
            old_stationMsg = stationMessage;
        }
    }
}
