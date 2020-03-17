using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Ladeskab
{
    class ChargeControl
    {
        private IUsbCharger Current_;
        private IDisplay Message_;        

        private void chargingMessages()
        {
            if (Current_.CurrentValue == 0)
            {
                //Gør ingenting
            }

            else if(Current_.CurrentValue > 0 && Current_.CurrentValue <= 5)
            {
                Message_.showChargeMsg("Telefonen er nu fuldt opladet. Frakobel telefon.");
            }
            else if(Current_.CurrentValue > 5 && Current_.CurrentValue <= 500)
            {
                Message_.showChargeMsg("Ladning er i gang!");
            }
            else
            {
                Message_.showChargeMsg("Fejl! Frakobel straks telefon!");
            } 
        }
    }
}
