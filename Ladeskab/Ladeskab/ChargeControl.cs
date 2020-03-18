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
        private IUsbCharger UsbCharger_;
        private IDisplay Message_;
        public bool Connected { get; private set; }

        void StartCharge()
        {
            UsbCharger_.StartCharge();
            chargingMessages();
        }

        void StopCharge()
        {
            UsbCharger_.StopCharge();
        }
        private void chargingMessages()
        {
            if (UsbCharger_.CurrentValue == 0)
            {
                //Gør ingenting
            }

            else if(UsbCharger_.CurrentValue > 0 && UsbCharger_.CurrentValue <= 5)
            {
                Message_.showChargeMsg("Telefonen er nu fuldt opladet. Frakobel telefon.");
            }
            else if(UsbCharger_.CurrentValue > 5 && UsbCharger_.CurrentValue <= 500)
            {
                Message_.showChargeMsg("Ladning er i gang!");
            }
            else
            {
                Message_.showChargeMsg("Fejl! Ladning af telefon er stoppet!");
                StopCharge();
            } 
        }
    }
}
