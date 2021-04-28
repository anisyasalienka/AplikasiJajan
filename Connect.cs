using System;
using MySql.Data.MySqlClient;

namespace AplikasiJajan
{
    public class Connect
    {
        private static string connectionString = "server=localhost; port=3306; uid=anisyasalienka;" +
                                         "pwd=12345; database=db_aplikasijajan; charset=utf8; sslMode=none";
        private static MySqlConnection  connection = new MySqlConnection(connectionString); 
        public MySqlConnection Connection
        {
            get{ return connection; }
        }
    }
}
