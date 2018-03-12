using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts_fileVersion_
{
    public static class TravelExpertsDB
    {
        // Global DB Connection Function
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TravelExperts_ARCH.mdf;Integrated Security=True;Connect Timeout=30";
                //"Data Source=ELF7OOSD219507\\SQLEXPRESS;Initial Catalog=TravelExperts_arch;" +
                //"Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
