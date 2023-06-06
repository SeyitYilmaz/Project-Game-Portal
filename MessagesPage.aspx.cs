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
    public partial class MessagesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SqlCommand command = new SqlCommand("SELECT ContactID, ContactMessage, ContactMail, ContactUsername FROM TableContact", SqlDatabaseConnection.sqlConnection);
                SqlDatabaseConnection.CheckConnection();

                SqlDataReader dr = command.ExecuteReader();

                messageRepeater.DataSource = dr;
                messageRepeater.DataBind();
                dr.Close();
            }
        }
    }
}