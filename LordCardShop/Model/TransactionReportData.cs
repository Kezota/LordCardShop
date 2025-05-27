using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Model
{
    public class TransactionReportData
    {
        public TransactionHeader TransactionHeader { get; set; }
        public List<TransactionDetail> TransactionDetails { get; set; }
        public User Customer { get; set; }
        public double Subtotal { get; set; }
    }

}