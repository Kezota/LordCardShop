using LordCardShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views.Admin
{
    public partial class HandleTransaction : Page
    {
        public string Filter { get; set; } = "All";

        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "admin" });
            if (!IsPostBack)
            {
                Filter = Request.QueryString["statusFilter"] ?? "All";
                Page.DataBind(); // Untuk <%= Filter == ... %> agar bisa jalan
                RenderTransactions();
            }
        }

        private void RenderTransactions()
        {
            List<Model.TransactionHeader> filteredTransactions;
            var (isTrue, message, transactions) = TransactionController.GetAllTransactionHistory();

            if (Filter == "Handled")
            {
                filteredTransactions = transactions.Where(t => t.Status == "Handled").ToList();
            }
            else if (Filter == "Unhandled")
            {
                filteredTransactions = transactions.Where(t => t.Status == "Unhandled").ToList();
            }
            else
            {
                filteredTransactions = transactions;
            }

            gvTransactions.DataSource = filteredTransactions;
            gvTransactions.DataBind();
        }

        // Menangani perintah "Handle" untuk setiap transaksi
        protected void gvTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Handle")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);

                // Panggil TransactionController.HandleTransaction dengan hasil berupa (isTrue, message)
                var (isTrue, message) = TransactionController.HandleTransaction(transactionId);

                // Periksa apakah transaksi berhasil ditangani
                if (isTrue)
                {
                    lblMessage.Text = message; // Menampilkan pesan sukses
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Visible = true;
                    RenderTransactions(); // Refresh the grid after handling the transaction
                }
                else
                {
                    lblMessage.Text = message; // Menampilkan pesan gagal
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
            }
        }
    }
}
