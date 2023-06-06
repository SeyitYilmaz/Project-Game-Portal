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
    public partial class AdminGameList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
    }
}