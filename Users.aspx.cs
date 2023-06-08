using Project_Game_Portal.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Project_Game_Portal
{
    public partial class Users : System.Web.UI.Page
    {
        int isAdmin = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
            {
                if (Page.IsPostBack == false)
                {
                    SqlCommand command = new SqlCommand("SELECT UserID,UserName, UserMail, IsAdmin FROM TableUser", SqlDatabaseConnection.sqlConnection);
                    SqlCommand checkCommand = new SqlCommand("SELECT IsAdmin FROM TableUser", SqlDatabaseConnection.sqlConnection);
                    SqlDatabaseConnection.CheckConnection();

                    isAdmin = (int)checkCommand.ExecuteScalar();
                    SqlDataReader dr = command.ExecuteReader();

                    gameRepeater.DataSource = dr;
                    gameRepeater.DataBind();
                    dr.Close();
                }
            }
            else
            {
                Response.Redirect("GameList.aspx");
            }
        }

        protected void gameRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox adminCheckBox = (CheckBox)e.Item.FindControl("adminCheckBox");

                object isAdminObj = DataBinder.Eval(e.Item.DataItem, "isAdmin");
                if (isAdminObj != null && isAdminObj != DBNull.Value)
                {
                    int isAdmin = Convert.ToInt32(isAdminObj);
                    adminCheckBox.Checked = isAdmin == 1;
                }
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btn.NamingContainer;
            HtmlTableCell cellGameName = (HtmlTableCell)repeaterItem.FindControl("UserID");
            SqlCommand command = new SqlCommand("DELETE FROM TableUser WHERE UserID = @pUserID", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            command.Parameters.AddWithValue("@pUserID", cellGameName.InnerText);
            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                Response.Write("Kullanıcı Silindi");
            }
            else
            {
                Response.Write("Kullanıcı silme işlemi sırasında bir hata oluştu.");
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}