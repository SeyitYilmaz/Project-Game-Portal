using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Project_Game_Portal
{
    public partial class _Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            adminLink.Visible = false;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (Convert.ToBoolean(Session["IsUserAdmin"]) == true)
                {
                    adminLink.Visible = true;
                }
                logText.InnerText = "Çıkış Yap";
                logText.HRef = "Logout.aspx";
            }
            else
            {
                logText.InnerText = "Giriş Yap";
                logText.HRef = "LoginPage.aspx";
            }
        }
    }
}