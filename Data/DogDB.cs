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
    public class DogDB
    {
        private ConnectionDB conn;

        public void Insert(Dog dog)
        {
            string sql = string.Format("INSERT INTO TB_DOG (name) VALUES ('{0}')", dog.Name);

            using (conn = ConnectionDB.GetConnection())
            {
                conn.ExecQuery(sql);
            }   
        }

        public List<Dog> Select()
        {

            using (conn = ConnectionDB.GetConnection())
            {
                string sql = "SELECT id, name FROM TB_DOG";
                var returnData = conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData);
            }
        }

        private List<Dog> TransformSQLReaderToList (SqlDataReader returnData)
        {
            var list = new List<Dog>();

            while (returnData.Read())
            {
                var item = new Dog() { 
                    Id = int.Parse(returnData["id"].ToString()),
                    Name = returnData["name"].ToString(),
                };

                list.Add(item);
            }
            return list;
        }
    }
}
