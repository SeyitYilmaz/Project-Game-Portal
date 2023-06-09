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
        protected int GetUserID()
        {
            int userAuthID = 0;
            SqlCommand idCommand = new SqlCommand("SELECT UserID FROM TableUser WHERE UserName=@pUserName", SqlDatabaseConnection.sqlConnection);
            idCommand.Parameters.AddWithValue("@pUserName", HttpContext.Current.User.Identity.Name);
            userAuthID = Convert.ToInt32(idCommand.ExecuteScalar());
            return userAuthID;
        }
        protected void btnSil_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btn.NamingContainer;
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
            SqlCommand command = new SqlCommand("SELECT c.CartID, c.CartGameID, tg.GameName,tg.GamePrice FROM TableUserGamesCart as c  INNER JOIN TableGame as tg ON c.CartGameID = tg.GameID WHERE (SELECT TableCart.CartUserID from TableCart WHERE TableCart.CartID = C.CartID ) = @pUserID", SqlDatabaseConnection.sqlConnection);
            SqlDatabaseConnection.CheckConnection();
            command.Parameters.AddWithValue("@pUserID", GetUserID());
            SqlDataReader dr = command.ExecuteReader();

            cartRepeater.DataSource = dr;
            cartRepeater.DataBind();
            dr.Close();
        }
        private double CalculatePrice()
        {
            double totalPrice = 0;
            SqlCommand priceCommand = new SqlCommand("SELECT SUM(TableGame.GamePrice) FROM TableUserGamesCart INNER JOIN TableGame ON TableUserGamesCart.CartGameID = TableGame.GameID INNER JOIN TableCart ON TableUserGamesCart.CartID = TableCart.CartID WHERE TableCart.CartUserID = @pUserID", SqlDatabaseConnection.sqlConnection);
            priceCommand.Parameters.AddWithValue("@pUserID", GetUserID());
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
            try
            {
                SqlCommand checkQuery = new SqlCommand("SELECT COUNT(*) FROM dbo.TableOrder WHERE UserID = @pUserID", SqlDatabaseConnection.sqlConnection);
                SqlCommand orderIDCommand = new SqlCommand("SELECT OrderID FROM TableOrder WHERE UserID = @pUserID", SqlDatabaseConnection.sqlConnection);
                SqlDatabaseConnection.CheckConnection();
                checkQuery.Parameters.AddWithValue("@pUserID", GetUserID());

                int existingCount = (int)checkQuery.ExecuteScalar();
                orderIDCommand.Parameters.AddWithValue("@pUserID", GetUserID());
                if (existingCount > 0) { }
                else
                {
                    SqlCommand insertToCartCommand = new SqlCommand("INSERT INTO TableOrder (UserID) VALUES (@pUserID)", SqlDatabaseConnection.sqlConnection);
                    insertToCartCommand.Parameters.AddWithValue("@pUserID", GetUserID());
                    insertToCartCommand.ExecuteNonQuery();
                }
                int orderID = Convert.ToInt32(orderIDCommand.ExecuteScalar());
                using (SqlConnection connection = SqlDatabaseConnection.sqlConnection)
                {
                    SqlCommand selectCommand = new SqlCommand("SELECT CartGameID FROM TableUserGamesCart WHERE CartID = (SELECT CartID FROM TableCart WHERE CartUserID = @pCartUserID)", connection);
                    selectCommand.Parameters.AddWithValue("@pCartUserID", GetUserID());
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int cartGameID = (int)reader["CartGameID"];
                            using (SqlCommand insertTryCommand = new SqlCommand("INSERT INTO TableUserOrder (UserOrderID, OrderGameID) VALUES (@pUserOrderID,@pOrderGameID)", connection))
                            {
                                insertTryCommand.Parameters.AddWithValue("@pUserOrderID", orderID);
                                insertTryCommand.Parameters.AddWithValue("@pOrderGameID", cartGameID);
                                insertTryCommand.ExecuteNonQuery();
                            }
                        }
                        reader.Close();

                    }
                    SqlCommand deleteGameCommand = new SqlCommand("DELETE FROM TableUserGamesCart WHERE CartID = @pCartID", SqlDatabaseConnection.sqlConnection);
                    SqlCommand cartIDCommand = new SqlCommand("SELECT CartID FROM TableCart WHERE CartUserID = @pUserID", SqlDatabaseConnection.sqlConnection);
                    cartIDCommand.Parameters.AddWithValue("@pUserID", GetUserID());
                    int cartID = Convert.ToInt32(cartIDCommand.ExecuteScalar());
                    System.Diagnostics.Debug.WriteLine(cartID);
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM TableCart WHERE CartUserID = @pUserID", SqlDatabaseConnection.sqlConnection);
                    deleteCommand.Parameters.AddWithValue("@pUserID", GetUserID());
                    deleteGameCommand.Parameters.AddWithValue("@pCartID", cartID);
                    deleteGameCommand.ExecuteNonQuery();
                    deleteCommand.ExecuteNonQuery();

                    if (totalPriceText != null)
                    {
                        PullDataToRepeater();
                        totalPriceText.InnerText = CalculatePrice().ToString("0.00");
                    }
                }
                Response.Write("Sipariş Tamamlandı");
            }
            catch (Exception ex)
            {

                Response.Write("Hata Meydana Geldi : " + ex.Message);
            }

        }


    }
}