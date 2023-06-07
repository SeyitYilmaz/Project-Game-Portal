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
            HtmlGenericControl icon = (HtmlGenericControl)logText.FindControl("iconText"); ;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //icon.Attributes["class"] = "fas fa-sign-in-alt mr-1";
                logText.InnerText = "Çıkış Yap";
                logText.HRef = "Logout.aspx";
            }
            else
            {
                //iconText.Attributes["class"] = "fas fa-sign-in-alt mr-1";
                logText.InnerText = "Giriş Yap";
                logText.HRef = "LoginPage.aspx";
            }
        }
    }
}