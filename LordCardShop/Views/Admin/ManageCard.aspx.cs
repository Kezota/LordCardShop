using LordCardShop.Controllers;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views.Admin
{
    public partial class ManageCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "Admin" });
            if (!IsPostBack)
            {
                LoadCards();
            }
        }

        private void LoadCards()
        {
            var (isTrue, message, cards) = CardController.GetAllCards();

            if (isTrue)
            {
                CardGridView.DataSource = cards;
                CardGridView.DataBind();
            }
            else
            {
                // Tampilkan pesan error jika data gagal diambil
                ShowAlert(message, false);
            }
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
                var (isTrue, message) = CardController.DeleteCard(cardId);

                if (!isTrue)
                {
                    ShowAlert(message, false);
                    return;
                }

                ShowAlert("Card deleted successfully!", true);
                LoadCards(); // refresh
            }
        }
        
        protected void CardGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Ambil data dari kolom IsFoil
                var card = (Card)e.Row.DataItem;
                var isFoilLabel = (Label)e.Row.FindControl("lblIsFoil");

                if (card.IsFoil != null && card.IsFoil.Length > 0)
                {
                    // Jika byte[] memiliki nilai, tampilkan true atau false
                    isFoilLabel.Text = card.IsFoil[0] == 1 ? "True" : "False";
                }
                else
                {
                    // Jika null atau kosong, tampilkan False
                    isFoilLabel.Text = "False";
                }
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