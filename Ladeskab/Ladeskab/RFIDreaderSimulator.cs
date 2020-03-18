﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    class RFIDreaderSimulator : IRFIDreader
    {
        public event EventHandler<int> RFIDEvent;

        public virtual void OnRfidRead(int e)
        {
            RFIDEvent?.Invoke(this, e);
        }
    }
}
