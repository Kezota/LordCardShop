using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views.Admin
{
    public partial class ManageCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCards();
            }
        }

        private void LoadCards()
        {
            // Dummy Data
            var cards = new List<dynamic>
        {
            new { CardID = 1, CardName = "Dragon", CardPrice = 15000, CardType = "Monster", IsFoil = "Yes" },
            new { CardID = 2, CardName = "Fireball", CardPrice = 12000, CardType = "Spell", IsFoil = "No" },
            new { CardID = 3, CardName = "Phoenix", CardPrice = 20000, CardType = "Monster", IsFoil = "Yes" }
        };

            CardGridView.DataSource = cards;
            CardGridView.DataBind();
        }

        protected void BtnAddCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCard.aspx");
        }

        protected void CardGridView_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int cardId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateCard")
            {
                Response.Redirect($"EditCard.aspx?CardID={cardId}");
            }
            else if (e.CommandName == "DeleteCard")
            {
                // Delete logic here
                ShowAlert("Card deleted successfully!", true);
                LoadCards(); // refresh
            }
        }

        private void ShowAlert(string message, bool isSuccess)
        {
            AlertPanel.CssClass = isSuccess ? "alert alert-success" : "alert alert-danger";
            AlertMessage.Text = message;
            AlertPanel.Visible = true;
        }
    }
}