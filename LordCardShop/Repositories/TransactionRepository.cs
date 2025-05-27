using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Repositories
{
    public class TransactionRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static List<TransactionReportData> GetTransactionReport()
        {
            var transactionReports = (from th in db.TransactionHeaders
                                      join td in db.TransactionDetails on th.TransactionID equals td.TransactionID
                                      join c in db.Cards on td.CardID equals c.CardID
                                      join u in db.Users on th.CustomerID equals u.UserID 
                                      select new TransactionReportData
                                      {
                                          TransactionHeader = th,  // Ambil seluruh data header transaksi
                                          TransactionDetails = db.TransactionDetails.Where(d => d.TransactionID == th.TransactionID).ToList(),  // Ambil detail transaksi berdasarkan TransactionID
                                          Customer = u,  // Ambil data User Customer
                                          Subtotal = td.Quantity * c.CardPrice // Hitung subtotal berdasarkan quantity dan harga kartu
                                      }).ToList();

            return transactionReports;
        }
    }
}