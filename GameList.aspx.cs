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
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT GameID, GameName, GamePublisherID, GamePrice, GamePlatformID, GameTypeID, TypeId,GameTypeName, PublisherID, PublisherName, GameDescription, PlatformID,GamePlatform FROM TableGame INNER JOIN TableGamePlatform on TableGame.GamePlatformID = TableGamePlatform.PlatformID INNER JOIN TableGamePublisher on TableGame.GamePublisherID = TableGamePublisher.PublisherID INNER JOIN TableGameType on TableGame.GameTypeID = TableGameType.TypeID", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();

            SqlDataReader dr = command.ExecuteReader();
            GameDataList.DataSource = dr;
            GameDataList.DataBind();
            dr.Close();
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Button btnBuy = (Button)sender; // Tıklanan butonu al

            RepeaterItem item = (RepeaterItem)btnBuy.NamingContainer; // Butonun bulunduğu RepeaterItem'ı al

            if (item != null)
            {
                HtmlGenericControl txtGameID = (HtmlGenericControl)item.FindControl("txtGameID"); // txtGameID idsine sahip i elementini bul

                if (txtGameID != null)
                {
                    int gameID = Convert.ToInt32(txtGameID.InnerText);
                    string query = "INSERT INTO TableGamesCart (CartID, GameID) VALUES (@pCartID, @pGameID)";
                    using (SqlCommand command = new SqlCommand(query, SqlDatabaseConnection.sqlConnection))
                    {
                        string sepetIDQuery = "SELECT CartID FROM TableCart WHERE CartUserID = @pUserID";
                        using (SqlCommand sepetIDCommand = new SqlCommand(sepetIDQuery, SqlDatabaseConnection.sqlConnection))
                        {
                            sepetIDCommand.Parameters.AddWithValue("@pUserID", HttpContext.Current.User.Identity.Name);
                            int sepetID = Convert.ToInt32(sepetIDCommand.ExecuteScalar());
                            command.Parameters.AddWithValue("@pCartID", sepetID);
                        }

                        command.Parameters.AddWithValue("@pGameID", gameID);

                        command.ExecuteNonQuery();
                    }

                }
            }

        }
    }
}