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
    public partial class GameList : System.Web.UI.Page
    {
        protected List<string> ButtonUniqueIDs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SqlCommand command = new SqlCommand("SELECT GameID, GameName, GamePublisherID, GamePrice, GamePlatformID, GameTypeID, TypeId,GameTypeName, PublisherID, PublisherName, GameDescription, PlatformID,GamePlatform FROM TableGame INNER JOIN TableGamePlatform on TableGame.GamePlatformID = TableGamePlatform.PlatformID INNER JOIN TableGamePublisher on TableGame.GamePublisherID = TableGamePublisher.PublisherID INNER JOIN TableGameType on TableGame.GameTypeID = TableGameType.TypeID", SqlDatabaseConnection.sqlConnection);
                SqlDatabaseConnection.CheckConnection();

                SqlDataReader dr = command.ExecuteReader();
                GameDataList.DataSource = dr;
                GameDataList.DataBind();
                dr.Close();
            }
        }


        protected void btnBuy_Click(object sender, EventArgs e)
        {
            SqlCommand idCommand = new SqlCommand("SELECT UserID FROM TableUser WHERE UserName=@pUserName", SqlDatabaseConnection.sqlConnection);
            SqlCommand getGameIDCommand = new SqlCommand("SELECT GameID FROM TableGame WHERE GameName=@pGameName", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            idCommand.Parameters.AddWithValue("@pUserName", HttpContext.Current.User.Identity.Name);

            int userAuthID = Convert.ToInt32(idCommand.ExecuteScalar());
            Button btnBuy = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnBuy.NamingContainer;

            if (item != null)
            {
                Label txtGameName = (Label)item.FindControl("txtGameName");

                if (txtGameName != null)
                {

                    SqlCommand checkQuery = new SqlCommand( "SELECT COUNT(*) FROM dbo.TableCart WHERE CartUserID = @pUserID",SqlDatabaseConnection.sqlConnection);
                    SqlCommand sepetIDCommand = new SqlCommand("SELECT CartID FROM TableCart WHERE CartUserID = @pUserID", SqlDatabaseConnection.sqlConnection);
                    checkQuery.Parameters.AddWithValue("@pUserID", userAuthID);

                    int existingCount = (int)checkQuery.ExecuteScalar();

                    if (existingCount > 0) { }
                    else
                    {
                        SqlCommand insertToCartCommand = new SqlCommand("INSERT INTO TableCart (CartUserID) VALUES (@pUserID)", SqlDatabaseConnection.sqlConnection);
                        insertToCartCommand.Parameters.AddWithValue("@pUserID", userAuthID);
                        insertToCartCommand.ExecuteNonQuery();
                    }
                    sepetIDCommand.Parameters.AddWithValue("@pUserID", userAuthID);
                    int sepetID = Convert.ToInt32(sepetIDCommand.ExecuteScalar());
                    getGameIDCommand.Parameters.AddWithValue("@pGameName", txtGameName.Text);
                    int gameID = Convert.ToInt32(getGameIDCommand.ExecuteScalar());
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO TableUserGamesCart (CartID, CartGameID) VALUES (@pCartID, @pGameID)", SqlDatabaseConnection.sqlConnection);
                    insertCommand.Parameters.AddWithValue("@pGameID", gameID);
                    insertCommand.Parameters.AddWithValue("@pCartID", sepetID);
                    insertCommand.ExecuteNonQuery();
                }
            }

        }
    }
}