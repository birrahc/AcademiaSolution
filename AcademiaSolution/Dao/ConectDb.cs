using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaSolution.Dao
{
    public class ConectDb
    {
        public MySqlConnection connection;

        public ConectDb()
        {
            string strConn = @"Server = localhost; Database=academia_lr ; Uid = root; Pwd = 123456;";
            connection = new MySqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

    }
}
