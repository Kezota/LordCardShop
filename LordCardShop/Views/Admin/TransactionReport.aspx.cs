using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views.Admin
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        private string _grandTotal = "0";
        public string GrandTotal => _grandTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            var transactions = new List<(int ID, DateTime Date, string Customer, string Status, int Subtotal)>
        {
            (1, DateTime.Now.AddDays(-2), "Alice", "Handled", 30000),
            (2, DateTime.Now.AddDays(-1), "Bob", "Unhandled", 45000),
            (3, DateTime.Now, "Charlie", "Handled", 15000)
        };

            int grandTotal = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table table-bordered mt-4'>");
            sb.Append("<thead class='thead-dark'><tr><th>ID</th><th>Date</th><th>Customer</th><th>Status</th><th>Subtotal</th></tr></thead>");
            sb.Append("<tbody>");
            foreach (var t in transactions)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1:yyyy-MM-dd}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>", t.ID, t.Date, t.Customer, t.Status, t.Subtotal);
                grandTotal += t.Subtotal;
            }
            sb.Append("</tbody></table>");

            LiteralReport.Text = sb.ToString();
            _grandTotal = grandTotal.ToString();
        }
    }
}