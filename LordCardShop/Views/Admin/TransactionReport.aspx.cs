using System;
using System.Linq;
using System.Text;
using System.Web.UI;
using LordCardShop.Controllers;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views.Admin
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        private string _grandTotal = "0";
        public string GrandTotal => _grandTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "Admin" });
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            // Memanggil controller untuk mengambil data transaksi
            var (isSuccess, message, transactions) = TransactionController.GetTransactionReportData();

            if (isSuccess)
            {
                double grandTotal = 0;

                // Kelompokkan transaksi berdasarkan TransactionID dan jumlahkan subtotalnya
                var groupedTransactions = transactions
                    .GroupBy(t => t.TransactionHeader.TransactionID) // Kelompokkan berdasarkan TransactionID
                    .Select(group => new
                    {
                        TransactionID = group.Key,
                        TransactionDate = group.First().TransactionHeader.TransactionDate,
                        CustomerName = group.First().Customer.UserName,
                        Status = group.First().TransactionHeader.Status,
                        Subtotal = group.Sum(t => t.Subtotal) // Jumlahkan subtotal untuk setiap TransactionID
                    }).ToList();

                StringBuilder sb = new StringBuilder();
                sb.Append("<table class='table table-bordered mt-4'>");
                sb.Append("<thead class='thead-dark'><tr><th>ID</th><th>Date</th><th>Customer</th><th>Status</th><th>Subtotal</th></tr></thead>");
                sb.Append("<tbody>");

                // Tampilkan data yang sudah dikelompokkan
                foreach (var transaction in groupedTransactions)
                {
                    sb.AppendFormat("<tr><td>{0}</td><td>{1:yyyy-MM-dd}</td><td>{2}</td><td>{3}</td><td>{4:N2}</td></tr>",
                        transaction.TransactionID,
                        transaction.TransactionDate,
                        transaction.CustomerName,  // Ambil UserName sebagai nama customer
                        transaction.Status,
                        transaction.Subtotal);

                    grandTotal += transaction.Subtotal;
                }
                sb.Append("</tbody></table>");

                LiteralReport.Text = sb.ToString();
                _grandTotal = grandTotal.ToString("N2"); // Format grand total dengan dua desimal
            }
            else
            {
                // Menampilkan pesan jika data tidak ditemukan
                LiteralReport.Text = $"<p class='alert alert-danger'>{message}</p>";
            }
        }
    }
}
