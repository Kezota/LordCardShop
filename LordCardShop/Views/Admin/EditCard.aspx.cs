using LordCardShop.Controllers;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views.Admin
{
    public partial class EditCard : System.Web.UI.Page
    {
        private int cardId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idStr = Request.QueryString["CardID"];
                if (string.IsNullOrEmpty(idStr) || !int.TryParse(idStr, out cardId))
                {
                    Response.Redirect("ManageCard.aspx");
                }
                else
                {
                    LoadCardData(cardId); // (Optional) Load existing data
                }
            }
        }

        protected void LoadCardData(int cardId)
        {
            var (isTrue, message, card) = CardController.ViewCard(cardId);

            if (card != null)
            {
                TxtName.Text = card.CardName;
                TxtPrice.Text = card.CardPrice.ToString();
                TxtDescription.Text = card.CardDesc;
                TxtType.Text = card.CardType;
                TxtFoil.Text = (card.IsFoil != null && card.IsFoil.Length > 0 && card.IsFoil[0] == 1) ? "yes" : "no";
            }
            else
            {
                ShowAlert("Card not found.", false);
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int cardId = int.Parse(Request.QueryString["CardID"]);
            string name = TxtName.Text.Trim();
            string priceStr = TxtPrice.Text.Trim();
            string description = TxtDescription.Text.Trim();
            string type = TxtType.Text.Trim();
            string foil = TxtFoil.Text.Trim().ToLower();

            if (!IsValidInput(name, priceStr, type, foil))
                return;

            // Update database here
            var (isTrue, message) = CardController.UpdateCard(cardId, name, float.Parse(priceStr), description, type, foil == "yes" ? "yes" : "no");

            ShowAlert("Card updated successfully!", true);
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