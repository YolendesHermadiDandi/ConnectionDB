using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.Database
{
    internal class Connection
    {

        private static readonly string connectionString = "Data Source=DESKTOP-8R407N6; Integrated " +
            "Security=True;Database=db_hr;Connect Timeout=30";

        public Connection() { }

        public static SqlConnection Connect()
        {
            var conn = new SqlConnection(connectionString);
            return conn;

        }

        public static SqlCommand SqlCommand()
        {
            var command = new SqlCommand();
            return command;
        }
    }
}
