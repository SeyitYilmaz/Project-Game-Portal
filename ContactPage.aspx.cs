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
    public partial class ContactPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SqlCommand contactCommand = new SqlCommand("INSERT INTO TableContact (ContactMessage,ContactMail,ContactUsername) values (@pMessage,@pMail,@pUsername)", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            contactCommand.Parameters.AddWithValue("@pMessage", txtMessage.Text);
            contactCommand.Parameters.AddWithValue("@pMail", txtEmail.Text);
            contactCommand.Parameters.AddWithValue("@pUsername", txtUsername.Text);
            contactCommand.ExecuteNonQuery();
        }
    }
}