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
    public partial class UpdateGame : System.Web.UI.Page
    {
        int gameID = 0;
        int gameTypeID = 0;
        int gamePlatformID = 0;
        int gamePublisherID = 0;
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
                    if (Request.QueryString["gameID"] != null)
                    {
                        gameID = int.Parse(Request.QueryString["gameID"]);
                        ViewState["gameID"] = gameID;
                        Response.Write(gameID);
                        SqlCommand getDataCommand = new SqlCommand("SELECT GameID, GameName, GamePublisherID, GamePrice, GamePlatformID, GameTypeID, TypeId,GameTypeName, PublisherID, PublisherName, GameDescription, PlatformID,GamePlatform FROM TableGame INNER JOIN TableGamePlatform on TableGame.GamePlatformID = TableGamePlatform.PlatformID INNER JOIN TableGamePublisher on TableGame.GamePublisherID = TableGamePublisher.PublisherID INNER JOIN TableGameType on TableGame.GameTypeID = TableGameType.TypeID WHERE GameID=@pGameID", SqlDatabaseConnection.sqlConnection);
                        SqlDatabaseConnection.CheckConnection();
                        getDataCommand.Parameters.AddWithValue("@pGameID", gameID);
                        SqlDataReader reader = getDataCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            txtName.Value = reader["GameName"].ToString();
                            txtGamePrice.Value = reader["GamePrice"].ToString();
                            int gameTypeID = Convert.ToInt32(reader["GameTypeID"].ToString());
                            int gamePlatformID = Convert.ToInt32(reader["GamePlatformID"].ToString());
                            int gamePublisherID = Convert.ToInt32(reader["GamePublisherID"].ToString());
                            ListItem selectedGameType = drpGameType.Items.FindByValue(gameTypeID.ToString());
                            ListItem selectedGamePlatform = drpGamePlatform.Items.FindByValue(gamePlatformID.ToString());
                            ListItem selectedGamePublisher = drpGamePublisher.Items.FindByValue(gamePublisherID.ToString());
                            if (selectedGameType != null && selectedGamePlatform != null && selectedGamePublisher != null)
                            {
                                selectedGameType.Selected = true;
                                selectedGamePlatform.Selected = true;
                                selectedGamePublisher.Selected = true;
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("GameList.aspx");
            }

        }
        protected void btnUpdateGame_Click(object sender, EventArgs e)
        {
            string gameName = txtName.Value.ToString();
            string gameType = drpGameType.SelectedItem.Text;
            string gamePublisher = drpGamePublisher.SelectedItem.Text;
            int gamePrice = Convert.ToInt32(txtGamePrice.Value);
            string gamePlatform = drpGamePlatform.SelectedItem.Text;

            int gameIDBtn = (int)ViewState["gameID"];
            SqlCommand updateCommand = new SqlCommand("UPDATE TableGame SET GameName = @pName, GameTypeID=@pType, GamePublisherID=@pPublisher,GamePrice=@pPrice,GamePlatformID=@pPlatform WHERE GameID = @pGameID", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();

            updateCommand.Parameters.AddWithValue("@pGameID", gameIDBtn);
            updateCommand.Parameters.AddWithValue("@pName", gameName);
            updateCommand.Parameters.AddWithValue("@pType", GetTypeIdFromDatabase(gameType));
            updateCommand.Parameters.AddWithValue("@pPublisher", GetPublisherIdFromDatabase(gamePublisher));
            updateCommand.Parameters.AddWithValue("@pPrice", gamePrice);
            updateCommand.Parameters.AddWithValue("@pPlatform", GetPlatformIdFromDatabase(gamePlatform));
            int affectedRows = updateCommand.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                Response.Write("Veri güncellendi.");
            }
            else
            {
                Response.Write("Veri güncelleme işlemi sırasında bir hata oluştu.");
            }


        }

        private int GetTypeIdFromDatabase(string textValue)
        {
            int returnedId = 0;

            string query = "SELECT TypeID FROM TableGameType WHERE GameTypeName = @pGameTypeName";
            using (SqlCommand command = new SqlCommand(query, SqlDatabaseConnection.sqlConnection))
            {
                SqlDatabaseConnection.CheckConnection();
                command.Parameters.AddWithValue("@pGameTypeName", textValue);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        returnedId = Convert.ToInt32(reader["TypeID"]);
                    }

                    reader.Close();
                }
                command.Dispose();
            }

            return returnedId;
        }

        private int GetPublisherIdFromDatabase(string textValue)
        {
            int returnedId = 0;

            SqlDatabaseConnection.CheckConnection();
            string query = "SELECT PublisherID FROM TableGamePublisher WHERE PublisherName = @pPublisher";
            using (SqlCommand command = new SqlCommand(query, SqlDatabaseConnection.sqlConnection))
            {
                command.Parameters.AddWithValue("@pPublisher", textValue);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        returnedId = Convert.ToInt32(reader["PublisherID"]);
                    }
                    reader.Close();
                }
            }

            return returnedId;
        }

        private int GetPlatformIdFromDatabase(string textValue)
        {
            int returnedId = 0;

            SqlDatabaseConnection.CheckConnection();
            string query = "SELECT PlatformID FROM TableGamePlatform WHERE GamePlatform = @pPlatform";
            using (SqlCommand command = new SqlCommand(query, SqlDatabaseConnection.sqlConnection))
            {
                command.Parameters.AddWithValue("@pPlatform", textValue);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        returnedId = Convert.ToInt32(reader["PlatformID"]);
                    }
                    reader.Close();
                }
            }

            return returnedId;
        }

    }
}