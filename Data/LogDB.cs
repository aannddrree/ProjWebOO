using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Data
{
    public class LogDB : ILogDB
    {
        private ConnectionDB _conn;
        public void Insert(string msg)
        {
            string sql = string.Format(Log.INSERT, msg);

            using (_conn = new ConnectionDB())
            {
                _conn.ExecQuery(sql);
            }
        }

        public List<Log> Select()
        {
            using (_conn = new ConnectionDB())
            {
                string sql = Log.SELECT;
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData);
            }
        }

        private List<Log> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Log>();

            while (returnData.Read())
            {
                var item = new Log()
                {
                    DateInformation = DateTime.Parse(returnData["dateInformation"].ToString()),
                    Description = returnData["description"].ToString(),
                };

                list.Add(item);
            }
            return list;
        }
    }
}
