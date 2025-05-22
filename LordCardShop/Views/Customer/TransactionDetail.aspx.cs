using LordCardShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views.Customer
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ambil TransactionID dari query string
                if (int.TryParse(Request.QueryString["TransactionID"], out int transactionId))
                {
                    // Ambil detail transaksi berdasarkan TransactionID
                    var (isTrue, message, transactionDetails) = TransactionController.GetTransactionDetailsByTransactionId(transactionId);

                    if (isTrue)
                    {
                        // Menampilkan informasi transaksi utama
                        var transactionHeader = TransactionController.GetTransactionHeaderById(transactionId);
                        lblTransactionID.Text = transactionHeader.TransactionID.ToString();
                        lblCustomerID.Text = transactionHeader.CustomerID.ToString();
                        lblStatus.Text = transactionHeader.Status;

                        // Menampilkan detail transaksi terkait
                        gvTransactionDetails.DataSource = transactionDetails;
                        gvTransactionDetails.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = message;
                        lblMessage.CssClass = "alert alert-danger";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid Transaction ID.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
            }
        }

        // Fungsi untuk tombol "Back to Transaction History"
        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Kembali ke halaman TransactionHistory.aspx
            Response.Redirect("TransactionHistory.aspx");
        }
    }
}