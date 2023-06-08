using Project_Game_Portal.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
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
            
            SqlCommand loginCommand = new SqlCommand("SELECT * FROM TableUser where UserMail=@pMail", SqlDatabaseConnection.sqlConnection);
            SqlCommand checkCommand = new SqlCommand("SELECT IsAdmin FROM TableUser where UserMail=@pEmail ",SqlDatabaseConnection.sqlConnection);
            SqlCommand userNameCommand = new SqlCommand("SELECT UserName FROM TableUser where UserMail=@pEmail ",SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            checkCommand.Parameters.AddWithValue("@pEmail", txtMail.Text);
            int isAdmin = (int)checkCommand.ExecuteScalar();
            string decPass = Sha256Converter.ComputeSha256Hash(txtPassword.Text);
            loginCommand.Parameters.AddWithValue("@pMail", txtMail.Text);
            loginCommand.Parameters.AddWithValue("@pPassword", decPass);
            userNameCommand.Parameters.AddWithValue("@pEmail",txtMail.Text);
            string userName = (string)userNameCommand.ExecuteScalar();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(loginCommand);
            da.Fill(dt);

            if (dt.Rows.Count>0)
            {
                if (isAdmin==1)
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    Session["IsUserAdmin"] = true;
                    Session["UserMail"] = dt.Rows[0].ItemArray[2].ToString();
                    Response.Redirect("AdminPage.aspx");

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    Session["IsUserOnline"] = true;
                    Session["UserMail"] = dt.Rows[0].ItemArray[2].ToString();
                    Response.Write(dt.Rows[0].ItemArray[2].ToString());
                    Response.Redirect("GameList.aspx");
                }

            }
            else
            {
                Response.Write("Mail Adresi veya Sifre Hatali");
            }

        }
    }
}