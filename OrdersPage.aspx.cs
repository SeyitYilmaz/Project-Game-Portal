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
    public partial class OrdersPage : System.Web.UI.Page
    {
        protected HtmlGenericControl GameContainer;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT OrderGameID, UserOrderID,OrderID,GameName,GameID,UserMail FROM TableUserOrder INNER JOIN TableOrder ON TableUserOrder.UserOrderID = TableOrder.OrderID INNER JOIN TableGame ON TableUserOrder.OrderGameID = TableGame.GameID INNER JOIN TableUser ON TableOrder.UserID = TableUser.UserID", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            SqlDataReader dr = command.ExecuteReader();
            GameDataList.DataSource = dr;
            GameDataList.DataBind();
            dr.Close();

        }

        protected int GetUserID()
        {
            int userAuthID = 0;
            SqlCommand idCommand = new SqlCommand("SELECT UserID FROM TableUser WHERE UserName=@pUserName", SqlDatabaseConnection.sqlConnection);
            idCommand.Parameters.AddWithValue("@pUserName", HttpContext.Current.User.Identity.Name);
            userAuthID = Convert.ToInt32(idCommand.ExecuteScalar());
            return userAuthID;
        }
    }
}