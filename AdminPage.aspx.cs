using Project_Game_Portal.Scripts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Project_Game_Portal
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
            {
                if (Page.IsPostBack == false)
                {
                    SqlCommand command = new SqlCommand("SELECT GameID, GameName, GamePublisherID, GamePrice, GamePlatformID, GameTypeID, TypeId,GameTypeName, PublisherID, PublisherName, GameDescription, PlatformID,GamePlatform FROM TableGame INNER JOIN TableGamePlatform on TableGame.GamePlatformID = TableGamePlatform.PlatformID INNER JOIN TableGamePublisher on TableGame.GamePublisherID = TableGamePublisher.PublisherID INNER JOIN TableGameType on TableGame.GameTypeID = TableGameType.TypeID", SqlDatabaseConnection.sqlConnection);
                    SqlDatabaseConnection.CheckConnection();

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

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btn.NamingContainer;
            HtmlTableCell cellGameName = (HtmlTableCell)repeaterItem.FindControl("GameName");
            SqlCommand command = new SqlCommand("SELECT GameID FROM TableGame WHERE GameName = @pGameName", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            command.Parameters.AddWithValue("@pGameName", cellGameName.InnerText);
            int gameID = (int)command.ExecuteScalar();
            command.Dispose();
            Response.Redirect("UpdateGame.aspx?gameID=" + gameID.ToString());
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btn.NamingContainer;
            HtmlTableCell cellGameName = (HtmlTableCell)repeaterItem.FindControl("GameName");
            SqlCommand command = new SqlCommand("DELETE FROM TableGame WHERE GameName = @pGameName", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            command.Parameters.AddWithValue("@pGameName", cellGameName.InnerText);
            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                Response.Write("Veri güncellendi.");
            }
            else
            {
                Response.Write("Veri güncelleme işlemi sırasında bir hata oluştu.");
            }
            Response.Redirect("AdminPage.aspx");
        }
    }
}