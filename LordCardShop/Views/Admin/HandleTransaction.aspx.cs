using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views.Admin
{
    public partial class HandleTransaction : Page
    {
        private static List<(int ID, string Customer, string Status)> transactions = new List<(int, string, string)>
        {
            (1, "Alice", "Unhandled"),
            (2, "Bob", "Handled"),
            (3, "Charlie", "Unhandled"),
            (4, "David", "Handled")
        };

        public string Filter { get; set; } = "All";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Filter = Request.QueryString["statusFilter"] ?? "All";
                Page.DataBind(); // Untuk <%= Filter == ... %> agar bisa jalan
                RenderTransactions();
            }
        }

        private void RenderTransactions()
        {
            List<(int ID, string Customer, string Status)> filteredTransactions;

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

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table table-bordered table-hover'>");
            sb.Append("<thead class='table-light'><tr><th>ID</th><th>Customer</th><th>Status</th><th>Action</th></tr></thead>");
            sb.Append("<tbody>");

            foreach (var trx in filteredTransactions)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td><td>{1}</td><td>{2}</td>", trx.ID, trx.Customer, trx.Status);
                if (trx.Status == "Unhandled")
                {
                    sb.AppendFormat("<td><form method='post'><button name='handleBtn' value='{0}' class='btn btn-sm btn-success'>Handle</button></form></td>", trx.ID);
                }
                else
                {
                    sb.Append("<td><button class='btn btn-sm btn-secondary' disabled>Handled</button></td>");
                }
                sb.Append("</tr>");
            }

            sb.Append("</tbody></table>");
            LiteralTransactions.Text = sb.ToString();
        }
    }
}
