using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LordCardShop.Middleware;

namespace LordCardShop.Views.Customer
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleMiddleware.RedirectIfUnauthorized(this, new[] { "User", "Admin" });
            if (!IsPostBack)
            {
                var dt = new DataTable();
                dt.Columns.Add("CardName");
                dt.Columns.Add("CardPrice", typeof(double));
                dt.Columns.Add("CardType");
                dt.Columns.Add("IsFoil", typeof(bool));
                dt.Columns.Add("Quantity", typeof(int));

                dt.Rows.Add("Dark Magician", 10.99, "Spellcaster", false, 2);
                dt.Rows.Add("Blue-Eyes White Dragon", 15.50, "Dragon", true, 1);

                rptCheckout.DataSource = dt;
                rptCheckout.DataBind();

                double total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    total += (double)row["CardPrice"] * (int)row["Quantity"];
                }

                lblTotal.Text = total.ToString("F2");
            }
        }

        protected void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            // Simulate transaction
            Response.Redirect("~/Views/TransactionSuccess.aspx");
        }
    }
}