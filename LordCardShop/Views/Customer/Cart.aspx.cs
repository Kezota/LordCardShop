using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;
using LordCardShop.Controllers;

namespace LordCardShop.Views.Customer
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        // Fungsi untuk memuat data keranjang
        private void LoadCart()
        {
            int userId = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

            // Memanggil CartController untuk mendapatkan data keranjang berdasarkan userId
            var (isTrue, message, cartItems) = CartController.ViewCart(userId);

            if (isTrue)
            {
                rptCart.DataSource = cartItems;
                rptCart.DataBind();
            }
            else
            {
                lblCartMessage.Text = message;
                lblCartMessage.CssClass = "alert alert-danger";
                lblCartMessage.Visible = true;
            }
        }

        // Fungsi untuk tombol Proceed to Checkout
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            var (isTrue, message) = CartController.CheckoutCart(userId);

            if (isTrue)
            {
                lblCartMessage.Text = "Successfully Checkout Cart";
                lblCartMessage.CssClass = "alert alert-success";
                lblCartMessage.Visible = true;
                Response.Redirect("TransactionHistory.aspx");
            }
            else
            {
                lblCartMessage.Text = message;
                lblCartMessage.CssClass = "alert alert-danger";
                lblCartMessage.Visible = true;
            }
        }

        // Fungsi untuk tombol Clear Cart
        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            var (isTrue, message) = CartController.ClearCart(userId);

            if (isTrue)
            {
                LoadCart();
                lblCartMessage.Text = "Your cart has been cleared.";
                lblCartMessage.CssClass = "alert alert-success";
                lblCartMessage.Visible = true;
            }
            else
            {
                lblCartMessage.Text = message;
                lblCartMessage.CssClass = "alert alert-danger";
                lblCartMessage.Visible = true;
            }
        }

        // Fungsi untuk memperbarui quantity
        protected void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnClicked.NamingContainer;
            int cartId = Convert.ToInt32(((Label)item.FindControl("lblCartID")).Text);
            int cardId = Convert.ToInt32(((Label)item.FindControl("lblCardID")).Text);
            int quantity = Convert.ToInt32(((TextBox)item.FindControl("txtQuantity")).Text);

            if (btnClicked.CommandArgument == "increase")
            {
                quantity++;  // Menambah quantity
            }
            else if (btnClicked.CommandArgument == "decrease")
            {
                quantity--;  // Mengurangi quantity
            }

            var (isTrue, message) = CartController.UpdateCart(cartId, cardId, quantity);

            lblCartMessage.Text = message;
            lblCartMessage.CssClass = isTrue ? "alert alert-success" : "alert alert-danger";
            lblCartMessage.Visible = true;

            if (isTrue)
            {
                LoadCart();
            }
        }

        // Fungsi untuk menghapus item dari cart
        protected void btnRemoveCard_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnClicked.NamingContainer;

            // Mendapatkan CartID dan CardID dari Label yang ada dalam Repeater
            int cartId = Convert.ToInt32(((Label)item.FindControl("lblCartID")).Text);
            int cardId = Convert.ToInt32(((Label)item.FindControl("lblCardID")).Text);

            // Memanggil CartController untuk menghapus item dari keranjang
            var (isTrue, message) = CartController.DeleteCardFromCart(cartId, cardId);

            // Menampilkan pesan sesuai hasil operasi
            lblCartMessage.Text = message;
            lblCartMessage.CssClass = isTrue ? "alert alert-success" : "alert alert-danger";
            lblCartMessage.Visible = true;

            // Memuat ulang keranjang setelah penghapusan
            if (isTrue)
            {
                LoadCart();
            }
        }
    }
}
