using System;
using System.Web.UI;
using LordCardShop.Controllers;
using System.Web.UI.WebControls;
using System.Web;
using LordCardShop.Middleware;

namespace LordCardShop.Views.Customer
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "customer" });
            if (!IsPostBack)
            {
                LoadTransactionHistory();
            }
        }

        protected void LoadTransactionHistory()
        {
            // Ambil User ID dari sesi
            int userId = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

            if (userId == 0)
            {
                // Jika User ID tidak ditemukan di sesi, tampilkan pesan error
                lblMessage.Text = "<p class='alert alert-danger'>User not logged in.</p>";
                lblMessage.Visible = true;
                return;
            }

            // Memanggil controller untuk mengambil data transaksi berdasarkan User ID
            var (isSuccess, message, transactions) = TransactionController.GetTransactionHistoryByUserId(userId);

            if (isSuccess)
            {
                // Menampilkan data transaksi di GridView
                gvTransactionHistory.DataSource = transactions;
                gvTransactionHistory.DataBind();
            }
            else
            {
                // Jika gagal mengambil data, tampilkan pesan error
                lblMessage.Text = $"<p class='alert alert-danger'>{message}</p>";
                lblMessage.Visible = true;
            }
        }

        // Fungsi untuk menangani klik tombol "View"
        protected void gvTransactionHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                // Arahkan ke halaman detail transaksi
                Response.Redirect($"/Views/Customer/TransactionDetail.aspx?TransactionID={transactionId}");
            }
        }
    }
}
