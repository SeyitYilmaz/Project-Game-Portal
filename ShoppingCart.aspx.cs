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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        int userAuthID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                PullDataToRepeater();
                if (totalPriceText != null)
                {
                    totalPriceText.InnerText = CalculatePrice().ToString("0.00");
                }
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btn.NamingContainer;
            //var totalPriceText = cartRepeater.Controls[cartRepeater.Controls.Count - 1].FindControl("totalPriceText") as HtmlGenericControl;
            
            HtmlTableCell cellCartGameID = (HtmlTableCell)repeaterItem.FindControl("CartGameID");
            HtmlTableCell cellCartID = (HtmlTableCell)repeaterItem.FindControl("CartID");
            SqlCommand command = new SqlCommand("DELETE FROM TableUserGamesCart WHERE CartGameID = @pCartGameID", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            command.Parameters.AddWithValue("@pCartGameID", cellCartGameID.InnerText);
            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                if (totalPriceText != null)
                {
                    PullDataToRepeater();
                    totalPriceText.InnerText = CalculatePrice().ToString("0.00");
                }
                Response.Write("Ürün Sepetten Silindi");
            }
            else
            {
                Response.Write("Ürün silme işlemi sırasında bir hata oluştu.");
            }
            
        }

        private void PullDataToRepeater()
        {

            SqlCommand idCommand = new SqlCommand("SELECT UserID FROM TableUser WHERE UserName=@pUserName", SqlDatabaseConnection.sqlConnection);
            idCommand.Parameters.AddWithValue("@pUserName", HttpContext.Current.User.Identity.Name);
            userAuthID = Convert.ToInt32(idCommand.ExecuteScalar());
            SqlCommand command = new SqlCommand("SELECT c.CartID, c.CartGameID, tg.GameName,tg.GamePrice FROM TableUserGamesCart as c  INNER JOIN TableGame as tg ON c.CartGameID = tg.GameID WHERE (SELECT TableCart.CartUserID from TableCart WHERE TableCart.CartID = C.CartID ) = @pUserID", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            command.Parameters.AddWithValue("@pUserID", userAuthID);
            SqlDataReader dr = command.ExecuteReader();

            cartRepeater.DataSource = dr;
            cartRepeater.DataBind();
            dr.Close();
        }
        private double CalculatePrice()
        {
            double totalPrice = 0;
            SqlCommand priceCommand = new SqlCommand("SELECT SUM(TableGame.GamePrice) FROM TableUserGamesCart INNER JOIN TableGame ON TableUserGamesCart.CartGameID = TableGame.GameID INNER JOIN TableCart ON TableUserGamesCart.CartID = TableCart.CartID WHERE TableCart.CartUserID = @pUserID", SqlDatabaseConnection.sqlConnection);
            priceCommand.Parameters.AddWithValue("@pUserID", userAuthID);
            object result = priceCommand.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                totalPrice = Convert.ToDouble(result);
            }
            else
            {
                return 0;
            }
            return totalPrice;
        }

        protected void btnSiparisTamamla_Click(object sender, EventArgs e)
        {

        }

    }
}