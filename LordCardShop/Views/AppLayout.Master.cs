using LordCardShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class AppLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Panggil AuthController.Logout
            AuthController.Logout();

            // Hapus session
            Session.Clear();
            Session.Abandon();

            // Redirect ke halaman login
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}