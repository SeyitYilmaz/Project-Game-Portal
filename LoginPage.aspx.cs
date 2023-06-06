using Project_Game_Portal.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Project_Game_Portal
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            SqlCommand loginCommand = new SqlCommand("SELECT * FROM TableUser where UserMail=@pMail and UserPassword=@pPassword ", SqlDatabaseConnection.sqlConnection);
            SqlCommand checkCommand = new SqlCommand("SELECT IsAdmin FROM TableUser where UserMail=@pEmail ",SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            checkCommand.Parameters.AddWithValue("@pEmail", txtMail.Text);
            int isAdmin = (int)checkCommand.ExecuteScalar();
            Response.Write("Deger"+isAdmin);
            string decPass = Sha256Converter.ComputeSha256Hash(txtPassword.Text);
            loginCommand.Parameters.AddWithValue("@pMail", txtMail.Text);
            loginCommand.Parameters.AddWithValue("@pPassword", decPass);




            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(loginCommand);
            da.Fill(dt);

            if (dt.Rows.Count>0)
            {
                if (isAdmin==1)
                {
                    Response.Redirect("AdminPage.aspx");
                }
                
            }
            else
            {
                Response.Write("Mail Adresi veya Sifre Hatali");
            }
            //loginCommand.ExecuteNonQuery();
        }
    }
}