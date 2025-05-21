using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class CardDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            var dummyCards = new[]
            {
                new Card { CardID = 1, CardName = "Dragon Slayer", CardPrice = (float)100.0, CardType = "Attack", IsFoil = new byte[] { 1 } },
                new Card { CardID = 2, CardName = "Phoenix Wing", CardPrice = (float)150.5, CardType = "Magic", IsFoil = new byte[] { 0 } },
                new Card { CardID = 3, CardName = "Knight's Valor", CardPrice = (float)80.0, CardType = "Defense", IsFoil = new byte[] { 0 } }
            };

            var card = Array.Find(dummyCards, c => c.CardID == cardId);
            if (card != null)
            {
                CardNameLabel.Text = card.CardName;
                CardPriceLabel.Text = $"${card.CardPrice}";
                CardTypeLabel.Text = card.CardType;
                CardFoilLabel.Text = (card.IsFoil != null && card.IsFoil.Length > 0 && card.IsFoil[0] == 1) ? "Foil" : "Non-Foil";
            }
            else
            {
                ShowAlert("ummyCard not found.", false);
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