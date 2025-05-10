using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        // Dummy current user data
        private readonly string currentPassword = "pass1234";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Dummy data, normally from session/db
                txtUsername.Text = "John Doe";
                txtEmail.Text = "john@example.com";
                txtPassword.Text = "pass1234";
                ddlGender.SelectedValue = "Male";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblError.CssClass = "alert alert-danger d-none";
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string gender = ddlGender.SelectedValue;

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
                if (txtOldPassword.Text != currentPassword)
                {
                    ShowError("Old password does not match current password.");
                    return;
                }

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