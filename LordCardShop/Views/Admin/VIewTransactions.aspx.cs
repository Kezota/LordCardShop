using LordCardShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views.Admin
{
    public partial class ViewTransactions : Page
    {
        // Filter untuk status transaksi (All, Handled, Unhandled)
        public string Filter { get; set; } = "All";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Filter = Request.QueryString["statusFilter"] ?? "All"; // Ambil status filter dari query string atau default "All"
                RenderTransactions(); // Render data transaksi berdasarkan filter
            }
        }

        private void RenderTransactions()
        {
            List<Model.TransactionHeader> filteredTransactions;
            var (isTrue, message, transactions) = TransactionController.GetAllTransactionHistory(); // Ambil semua transaksi

            // Filter berdasarkan status transaksi
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
                filteredTransactions = transactions; // Semua transaksi
            }

            gvTransactions.DataSource = filteredTransactions;
            gvTransactions.DataBind(); // Tampilkan transaksi yang sudah difilter
        }

        // Menangani perintah "View" untuk melihat detail transaksi
        protected void gvTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);

                // Redirect ke halaman TransactionDetail dengan TransactionID sebagai query string
                Response.Redirect($"TransactionDetail.aspx?TransactionID={transactionId}");
            }
        }
    }
}
