using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App1.Service.App1Service;

namespace App1.Interface
{

    internal interface IApp1Service
    {
        Task InitAsync();

        IReadOnlyList<(string FuncName, IReadOnlyList<string> ValueNames)> GetFuctions();

        void SetValue(int FuncID, int ValueID);
    }
}
