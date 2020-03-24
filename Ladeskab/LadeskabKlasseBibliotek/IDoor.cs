using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public interface IDoor
    {
        void unlockDoor();
        void lockDoor();
        event EventHandler doorOpen;
        event EventHandler doorClose;
    }
}
