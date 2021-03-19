using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IMonitore
    {
        void SaveLog(string msg);

        List<Log> Select();
    }
}
