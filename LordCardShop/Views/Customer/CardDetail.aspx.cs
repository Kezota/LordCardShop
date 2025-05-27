using LordCardShop.Controllers;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views
{
    public partial class CardDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                RoleMiddleware.RedirectIfUnauthorized(this, new[] { "customer" });
                int cardId;
                if (int.TryParse(Request.QueryString["CardID"], out cardId))
                {
                    LoadDummyCardDetail(cardId);
                }
                else
                {
                    ShowAlert("Invalid Card ID.", false);
                }
            }
        }

        private void LoadDummyCardDetail(int cardId)
        {
            var (isTrue, message, card) = CardController.ViewCard(cardId);

            if (card != null)
            {
                CardNameLabel.Text = card.CardName;
                CardPriceLabel.Text = $"${card.CardPrice}";
                CardDescLabel.Text = card.CardDesc;
                CardTypeLabel.Text = card.CardType;
                CardFoilLabel.Text = (card.IsFoil != null && card.IsFoil.Length > 0 && card.IsFoil[0] == 1) ? "Foil" : "Non-Foil";
            }
            else
            {
                ShowAlert("Card not found.", false);
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderCard.aspx");
        }

        private void ShowAlert(string message, bool isSuccess)
        {
            AlertPanel.CssClass = isSuccess ? "alert alert-success" : "alert alert-danger";
            AlertMessage.Text = message;
            AlertPanel.Visible = true;
        }
    }
}