﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class Display : IDisplay
    {

        public void showChargeMsg(string chargeMessage)
        {
            Console.WriteLine(chargeMessage);
        }
        public void showStationMsg(string stationMessage)
        {
            Console.WriteLine(stationMessage);
        }
    }
}
