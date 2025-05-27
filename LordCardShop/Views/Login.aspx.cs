using LordCardShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Helpers;

namespace LordCardShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the username and password from the form
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            // Call the AuthController.Login method
            var (isSuccess, message) = AuthController.Login(username, password);

            if (isSuccess)
            {
                // Redirect to the home page or dashboard on successful login
                var user = SessionHelper.GetCurrentUser();
                if (user != null && user.UserRole == "admin")
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                // Display the error message
                ErrorMessage.Text = message;
                ErrorMessage.Visible = true;
            }
        }
    }
}
