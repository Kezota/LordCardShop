using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "User", "Admin" });
            if (!IsPostBack)
            {
                lblUsername.Text = HttpContext.Current.Session["Username"]?.ToString() ?? "Guest";
            }
        }
    }
}