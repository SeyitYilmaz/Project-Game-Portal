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
        protected void btnAddGame_Click(object sender, EventArgs e)
        {
            string gameName = txtName.Value.ToString();
            string gameType = drpGameType.SelectedValue;
            string gamePublisher = drpGamePublisher.SelectedValue;
            decimal gamePrice = decimal.Parse(txtGamePrice.Value);
            string gamePlatform = drpGamePlatform.SelectedValue;

            SqlCommand addCommand = new SqlCommand("", SqlDatabaseConnection.sqlConnection);

        }
    }
}