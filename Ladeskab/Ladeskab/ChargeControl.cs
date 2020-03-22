using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Ladeskab
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger UsbCharger_;
        private IDisplay Display_;

        public bool IsConnected()
        {
            return UsbCharger_.Connected;
        }
        
        //{ get;  set; }

        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            UsbCharger_ = usbCharger;
            Display_ = display;
        }
        public void StartCharge()
        {
            UsbCharger_.StartCharge();
            chargingMessages();
        }

        public void StopCharge()
        {
            UsbCharger_.StopCharge();
        }
        public void chargingMessages()
        {
            if (UsbCharger_.CurrentValue == 0)
            {
                Display_.showChargeMsg("Ladeværdi er nul");
            }

            else if(UsbCharger_.CurrentValue > 0 && UsbCharger_.CurrentValue <= 5)
            {
                Display_.showChargeMsg("Telefonen er nu fuldt opladet. Frakobel telefon.");
                StopCharge();
            }
            else if(UsbCharger_.CurrentValue > 5 && UsbCharger_.CurrentValue <= 500)
            {
                Display_.showChargeMsg("Ladning er i gang!");
            }
            else
            {
                Display_.showChargeMsg("Fejl! Ladning af telefon er stoppet!");
                StopCharge();
            } 
        }
    }
}
