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
    public partial class SignupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlCommand contactCommand = new SqlCommand("INSERT INTO TableUser (UserName,UserMail,UserPassword) values (@pUserName,@pMail,@pPassword)", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();

            string encPass = Sha256Converter.ComputeSha256Hash(txtPassword.Text);
            contactCommand.Parameters.AddWithValue("@pUserName", txtName.Text);
            contactCommand.Parameters.AddWithValue("@pMail", txtMail.Text);
            contactCommand.Parameters.AddWithValue("@pPassword", encPass);
            contactCommand.ExecuteNonQuery();

        }
    }
}