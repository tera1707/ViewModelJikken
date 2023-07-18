using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interface
{
    internal interface ILightController
    {
        void On();

        void Off();

        void SetBrightness(int brightness);
    }
}
