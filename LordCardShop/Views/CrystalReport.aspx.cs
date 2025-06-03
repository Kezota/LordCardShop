using LordCardShop.Dataset;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Controllers;
using LordCardShop.Handlers;

namespace LordCardShop.Views
{
    public partial class CrystalReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport report = new CrystalReport();
            CrystalReportViewer1.ReportSource = report;
            TransactionDataset data = new TransactionDataset();
            // Dataset data = getData(ReportingHandler.GetAllTransactions());/**/
        }

        /*private ModelDataset getData(List<TransactionDetail> transactions)
        {
            ModelDataset data = new ModelDataset();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;
            foreach (var transaction in transactions)
            {
                var headerRow = headerTable.NewTransactionHeaderRow();
                headerRow.TransactionID = transaction.TransactionID;
                headerRow.UserID = transaction.UserID;
                headerRow.TransactionDate = transaction.TransactionDate;
                headerRow.TotalAmount = transaction.TotalAmount;
                headerTable.AddTransactionHeaderRow(headerRow);

                foreach (var detail in transaction.TransactionDetails)
                {
                    var detailRow = detailTable.NewTransactionDetailRow();
                    detailRow.TransactionID = detail.TransactionID;
                    detailRow.CardID = detail.CardID;
                    detailRow.Quantity = detail.Quantity;
                    detailRow.Price = detail.Price;
                    detailTable.AddTransactionDetailRow(detailRow);
                }
            }
            
        }*/
    }
}