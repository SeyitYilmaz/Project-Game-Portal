using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_Game_Portal.Scripts
{
    public class SqlDatabaseConnection
    {
        public static SqlConnection sqlConnection = new SqlConnection("Data Source=SMY\\SQLEXPRESS;Initial Catalog=GameForumDB;Integrated Security=True");
        public static void CheckConnection()
        {
            sqlConnection.Close();
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
    }
}