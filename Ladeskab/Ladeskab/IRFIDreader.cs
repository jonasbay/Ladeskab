﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public interface IRFIDreader
    {
        event EventHandler<int> RFIDEvent;
        void OnRfidRead(int e);
    }
}
