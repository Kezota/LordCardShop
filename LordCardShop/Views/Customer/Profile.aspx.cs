using LordCardShop.Controllers;
using LordCardShop.Helper;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views.Customer
{
    public partial class Profile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "User", "Admin" });
            if (!IsPostBack)
            {
                var (isSuccess, message, user) = UserController.GetCurrentUser();

                if (!isSuccess || user == null)
                {
                    lblError.CssClass = "alert alert-danger d-block";
                    lblError.Text = message;
                    return;
                }

                // Populate user data
                txtUsername.Text = user.UserName;
                txtEmail.Text = user.UserEmail;
                ddlGender.SelectedValue = user.UserGender;
                txtDOB.Text = user.UserDOB.ToString("yyyy-MM-dd");
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var (isSuccess, message, user) = UserController.GetCurrentUser();

            if (!isSuccess || user == null)
            {
                lblError.CssClass = "alert alert-danger d-block";
                lblError.Text = message;
                return;
            }

            lblError.CssClass = "alert alert-danger d-none";
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtOldPassword.Text.Trim();
            string gender = ddlGender.SelectedValue;
            DateTime dob = DateTime.Parse(txtDOB.Text.Trim());

            // Validations
            if (!Regex.IsMatch(username, @"^[A-Za-z ]{5,30}$"))
            {
                ShowError("Username must be 5–30 characters and alphabet with spaces only.");
                return;
            }

            if (!email.Contains("@"))
            {
                ShowError("Email must contain '@'.");
                return;
            }

            if (!Regex.IsMatch(password, @"^[A-Za-z0-9]{8,}$"))
            {
                ShowError("Password must be at least 8 characters and alphanumeric.");
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                ShowError("Gender must be selected.");
                return;
            }

            // New password logic
            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                if (!Regex.IsMatch(txtNewPassword.Text, @"^[A-Za-z0-9]{8,}$"))
                {
                    ShowError("New password must be at least 8 characters and alphanumeric.");
                    return;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    ShowError("Confirmation password must match the new password.");
                    return;
                }
            }

            // Simulate update
            string newPassword = string.IsNullOrEmpty(txtNewPassword.Text) ? password : txtNewPassword.Text;

            var (isSuccess2, errorMessage) = UserController.UpdateProfile(username, email, newPassword, password, gender, dob);

            if (!isSuccess2)
            {
                ShowError(errorMessage);
                return;
            }

            lblError.CssClass = "alert alert-success d-block";
            lblError.Text = "Profile updated successfully!";
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.CssClass = "alert alert-danger d-block";
        }
    }
}