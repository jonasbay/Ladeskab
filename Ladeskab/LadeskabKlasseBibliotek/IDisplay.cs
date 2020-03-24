using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public interface IDisplay
    {
        void showChargeMsg(string chargeMessage);
        void showStationMsg(string stationMessage);
    }
}
