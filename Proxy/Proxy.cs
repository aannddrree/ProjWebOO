using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Proxy : IMonitore
    {
        private LogDB _logDB;
        public Proxy(LogDB logDB)
        {
            this._logDB = logDB;
        }

        public void SaveLog(string msg)
        {
            _logDB.Insert(msg);
        }

        public List<Log> Select()
        {
            return _logDB.Select();
        }
    }
}
