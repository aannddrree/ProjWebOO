using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ILogDB
    {
        void Insert(string msg);
        List<Log> Select();
    }
}
