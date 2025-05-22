using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Model
{
    public class TransactionHistoryData
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public double Subtotal { get; set; }
    }

}