using LordCardShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Get user input from the form
            string username = Username.Text.Trim();
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();
            string gender = Gender.SelectedValue;
            string role = Role.SelectedValue;
            DateTime dob;

            // Validate Date of Birth
            if (!DateTime.TryParse(DOB.Text.Trim(), out dob))
            {
                ErrorMessage.Text = "Invalid date of birth format. Please use yyyy-MM-dd.";
                ErrorMessage.CssClass = "alert alert-danger";
                ErrorMessage.Visible = true;
                return;
            }

            // Call the Register method
            var (isSuccess, message) = AuthController.Register(username, email, password, gender, dob, role);

            // Display the result to the user
            if (isSuccess)
            {
                ErrorMessage.Text = "Registration successful!";
                ErrorMessage.CssClass = "alert alert-success";
                ErrorMessage.Visible = true;

                // Optionally redirect to another page
                Response.Redirect("Login.aspx");
            }
            else
            {
                ErrorMessage.Text = message;
                ErrorMessage.CssClass = "alert alert-danger";
                ErrorMessage.Visible = true;
            }
        }
    }
}
