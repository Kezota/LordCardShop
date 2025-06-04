using LordCardShop.Controllers;
using LordCardShop.Model;
using LordCardShop.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views
{
    public partial class OrderCardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "customer" });
            if (!IsPostBack)
            {
                LoadCards();
            }
        }

        private void LoadCards()
        {
            string searchTerm = Request.QueryString["search"];
            var (isTrue, message, cards) = CardController.GetAllCards();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Assuming Card has a Name property, adjust as needed
                cards = cards
                    .Where(card => card.CardName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            CardRepeater.DataSource = cards;
            CardRepeater.DataBind();
        }

        protected void CardRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int cardId = Convert.ToInt32(e.CommandArgument);
            int userId = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

            if (e.CommandName == "AddToCart")
            {
                var (isSuccess, message) = CartController.AddCardToCart(userId, cardId, 1);

                if (isSuccess)
                {
                    ShowAlert($"Card ID {cardId} successfully added to cart!", true);
                }
                else
                {
                    ShowAlert($"Failed to add Card ID {cardId} to cart. {message}", false);
                }
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
