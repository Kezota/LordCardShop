using LordCardShop.Controllers;
using LordCardShop.Model;
using LordCardShop.Views.Customer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class OrderCardPage : System.Web.UI.Page
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
            var (isTrue, message, cards) = CardController.GetAllCards();

            CardRepeater.DataSource = cards;
            CardRepeater.DataBind();
        }

        protected void CardRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int cardId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "AddToCart")
            {
                // Dummy add to cart logic
                ShowAlert($"Card ID {cardId} successfully added to cart!", true);
            }
            else if (e.CommandName == "ViewDetail")
            {
                Response.Redirect($"CardDetail.aspx?CardID={cardId}");
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