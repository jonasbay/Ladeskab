using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public interface ILogFile
    {
        void logDoorLocked(int id);
        void logDoorUnlocked(int id);
    }
}
