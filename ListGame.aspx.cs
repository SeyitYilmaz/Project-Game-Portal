using Project_Game_Portal.Scripts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Project_Game_Portal
{
    public partial class ListGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM TableGame", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();

            SqlDataReader dr = command.ExecuteReader();

            GameDataList.DataSource= dr;

            GameDataList.DataBind();
        }
    }
}