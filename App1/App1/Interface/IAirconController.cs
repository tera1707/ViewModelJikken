using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interface
{
    internal enum Mode
    {
        Cooler,
        Heater,
    }

    internal interface IAirconController
    {
        void On();

        void Off();

        void SetMode(Mode mode);

        void SetTemperature(int temperature);
    }
}
