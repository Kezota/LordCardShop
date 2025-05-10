using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views.Admin
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTransactionDetail();
            }
        }

        private void LoadTransactionDetail()
        {
            int transactionId = int.Parse(Request.QueryString["TransactionID"]);
            // Use transactionId to fetch details (for now using dummy data)
            lblTransactionID.Text = transactionId.ToString();
            lblStatus.Text = "Completed"; // Simulated status
            lblTransactionDate.Text = "2025-04-01"; // Simulated date
        }
    }
}