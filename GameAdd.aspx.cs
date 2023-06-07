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
    public partial class GameAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
            {
                if (Page.IsPostBack == false)
                {
                    SqlCommand sqlCommandPlatform = new SqlCommand("SELECT * FROM TableGamePlatform", SqlDatabaseConnection.sqlConnection);
                    SqlCommand sqlCommandPublisher = new SqlCommand("SELECT * FROM TableGamePublisher", SqlDatabaseConnection.sqlConnection);
                    SqlCommand sqlCommandType = new SqlCommand("SELECT * FROM TableGameType", SqlDatabaseConnection.sqlConnection);
                    SqlDatabaseConnection.CheckConnection();
                    SqlDataReader dr = sqlCommandPlatform.ExecuteReader();
                    drpGamePlatform.DataTextField = "GamePlatform";
                    drpGamePlatform.DataValueField = "PlatformID";
                    drpGamePlatform.DataSource = dr;
                    drpGamePlatform.DataBind();
                    dr.Close();
                    dr = sqlCommandPublisher.ExecuteReader();
                    drpGamePublisher.DataTextField = "PublisherName";
                    drpGamePublisher.DataValueField = "PublisherID";
                    drpGamePublisher.DataSource = dr;
                    drpGamePublisher.DataBind();
                    dr.Close();
                    dr = sqlCommandType.ExecuteReader();
                    drpGameType.DataTextField = "GameTypeName";
                    drpGameType.DataValueField = "TypeID";
                    drpGameType.DataSource = dr;
                    drpGameType.DataBind();
                    dr.Close();
                }
            }
            else
            {
                Response.Redirect("GameList.aspx");
            }

        }
        protected void btnAddGame_Click(object sender, EventArgs e)
        {
            string gameName = txtName.Value.ToString();
            int gameType = Convert.ToInt32(drpGameType.SelectedValue);
            int gamePublisher = Convert.ToInt32(drpGamePublisher.SelectedValue);
            int gamePrice = int.Parse(txtGamePrice.Value);
            int gamePlatform = Convert.ToInt32(drpGamePlatform.SelectedValue);

            SqlCommand addCommand = new SqlCommand("INSERT INTO TableGame (GameName, GameTypeID, GamePublisherID,GamePrice,GamePlatformID) values (@pName,@pType,@pPublisher,@pPrice,@pPlatform)", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();

            addCommand.Parameters.AddWithValue("@pName", gameName);
            addCommand.Parameters.AddWithValue("@pType", gameType);
            addCommand.Parameters.AddWithValue("@pPublisher", gamePublisher);
            addCommand.Parameters.AddWithValue("@pPrice", gamePrice);
            addCommand.Parameters.AddWithValue("@pPlatform", gamePlatform);

            addCommand.ExecuteNonQuery();

        }
    }
}