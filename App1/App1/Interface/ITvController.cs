using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Interface
{
    internal interface ITvController
    {
        void On();

        void Off();

        void SetChannel(int chNo);
    }
}
