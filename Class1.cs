using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace TurAgent
{

    class Country
    {
        public int id { get; set; }
        public String name { get; set; }
        public String climate { get; set; }

    }

    class Duration
    {
        public int daysCount { get; set; }
    }

    class Client
    {
        public int id { get; set; }
        public String name { get; set; }
    }

    class Hotel
    {
        public int id { get; set; }
        public String name { get; set; }
        public int price { get; set; }

    }

    public enum FormStatus
    {
        Close,
        Reopen
    }

    public class ConnectionsManager
    {
        private const string connectionString = @"Data Source=LAPTOP-HGF17FN9\SQLEXPRESS;Initial Catalog=Tur_Agenstvo;Integrated Security=True";
        private static SqlConnection connection = null;

        public static void openConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }

        public static void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
