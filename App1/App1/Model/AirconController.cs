using App1.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    internal class AirconController : IAirconController
    {
        public void Off()
        {
            Debug.WriteLine($"エアコンをOFFしました。(本物エアコン)");
        }

        public void On()
        {
            Debug.WriteLine($"エアコンをONしました。(本物エアコン)");
        }

        public void SetMode(Mode mode)
        {
            Debug.WriteLine($"エアコンモードを {mode} にしました。(本物エアコン)");
        }

        public void SetTemperature(int temperature)
        {
            Debug.WriteLine($"エアコン温度を {temperature} ℃にしました。(本物エアコン)");
        }
    }
}
