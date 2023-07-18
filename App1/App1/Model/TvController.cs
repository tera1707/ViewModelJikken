using App1.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    internal class TvController : ITvController
    {
        public void Off()
        {
            Debug.WriteLine($"テレビをOFFしました。(本物テレビ)");
        }

        public void On()
        {
            Debug.WriteLine($"テレビをONしました。(本物テレビ)");
        }

        public void SetChannel(int chNo)
        {
            Debug.WriteLine($"テレビのチャンネルを {chNo} chにしました。(本物テレビ)");
        }
    }
}
