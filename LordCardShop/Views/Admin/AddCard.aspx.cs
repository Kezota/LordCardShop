using LordCardShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views.Admin
{
    public partial class AddCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "Admin" });
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            string name = TxtName.Text.Trim();
            string priceStr = TxtPrice.Text.Trim();
            string description = TxtDescription.Text.Trim();
            string type = TxtType.Text.Trim();
            string foil = TxtFoil.Text.Trim().ToLower();

            if (!IsValidInput(name, priceStr, type, foil))
                return;

            // Insert to database here
            var (isTrue, message) = CardController.AddCard(name, float.Parse(priceStr), "Dummy Description", type, foil == "yes" ? "yes" : "no");

            if (!isTrue)
            {
                ShowAlert(message, false);
                return;
            }

            ShowAlert("Card inserted successfully!", true);
        }

        private bool IsValidInput(string name, string priceStr, string type, string foil)
        {
            double price;

            if (name.Length < 5 || name.Length > 50 || !System.Text.RegularExpressions.Regex.IsMatch(name, @"^[A-Za-z\s]+$"))
            {
                ShowAlert("Name must be 5-50 alphabetic characters.", false);
                return false;
            }
            if (!double.TryParse(priceStr, out price) || price < 10000)
            {
                ShowAlert("Price must be a number >= 10000.", false);
                return false;
            }
            if (string.IsNullOrEmpty(type) || (type != "Spell" && type != "Monster"))
            {
                ShowAlert("Type must be 'Spell' or 'Monster'.", false);
                return false;
            }
            if (foil != "yes" && foil != "no")
            {
                ShowAlert("Foil must be 'yes' or 'no'.", false);
                return false;
            }

            return true;
        }

        private void ShowAlert(string message, bool isSuccess)
        {
            AlertPanel.CssClass = isSuccess ? "alert alert-success" : "alert alert-danger";
            AlertMessage.Text = message;
            AlertPanel.Visible = true;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageCard.aspx");
        }
    }
}