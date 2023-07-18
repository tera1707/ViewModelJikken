using App1.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    internal class LightController : ILightController
    {
        public void Off()
        {
            Debug.WriteLine("ライトをOFFしました。(本物ライト)");
        }

        public void On()
        {
            Debug.WriteLine("ライトをONしました。(本物ライト)");
        }

        public void SetBrightness(int brightness)
        {
            Debug.WriteLine($"ライトの明るさを {brightness} にしました。(本物ライト)");
        }
    }
}
