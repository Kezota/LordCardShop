using LordCardShop.Dataset;
using LordCardShop.Model;
using LordCardShop.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class CrystalReport : System.Web.UI.Page
    {
        DatabaseEntities db = new DatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            ModelDataset ds = GetAllData();
            report.SetDataSource(ds);
        }

        public ModelDataset GetAllData()
        {
            ModelDataset dataset = new ModelDataset();
            var headertable = dataset.TransactionHeader;
            var detailtable = dataset.TransactionDetail;

            List<TransactionHeader> transaction;
            transaction = db.TransactionHeaders.ToList();

            foreach (TransactionHeader mst in transaction)
            {
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = mst.TransactionID;
                hrow["TransactionDate"] = mst.TransactionDate;
                hrow["CustomerID"] = mst.CustomerID;
                hrow["Status"] = mst.Status;
                headertable.Rows.Add(hrow);

                foreach (TransactionDetail mstd in mst.TransactionDetails)
                {
                    var drow = detailtable.NewRow();
                    drow["TransactionID"] = mstd.TransactionID;
                    drow["CardID"] = mstd.CardID;
                    drow["Quantity"] = mstd.Quantity;
                    detailtable.Rows.Add(drow);
                }
            }

            return dataset;
        }
    }
}