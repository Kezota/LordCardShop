using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Repositories
{
    public class TransactionHeaderRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static int AddTransactionHeader(TransactionHeader header)
        {
            try
            {
                db.TransactionHeaders.Add(header);
                db.SaveChanges();

                return header.TransactionID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding transaction header: " + ex.Message);
            }
        }

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static TransactionHeader GetTransactionHeaderById(int transactionId)
        {
            return db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
        }

        public static List<TransactionHistoryData> GetTransactionByCustomerId(int customerId)
        {
            var transactions = (from th in db.TransactionHeaders
                                join td in db.TransactionDetails on th.TransactionID equals td.TransactionID
                                join c in db.Cards on td.CardID equals c.CardID
                                where th.CustomerID == customerId // Filter berdasarkan UserID yang terkait dengan Card
                                select new TransactionHistoryData
                                {
                                    TransactionID = th.TransactionID,
                                    TransactionDate = th.TransactionDate,
                                    Status = th.Status,
                                    // Menghitung Subtotal berdasarkan Quantity dan CardPrice
                                    Subtotal = td.Quantity * c.CardPrice
                                }).ToList();

            return transactions;
        }

        public static void UpdateTransactionHeader(TransactionHeader updatedHeader)
        {
            TransactionHeader existingHeader = db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == updatedHeader.TransactionID);
            if (existingHeader != null)
            {
                existingHeader.TransactionDate = updatedHeader.TransactionDate;
                existingHeader.CustomerID = updatedHeader.CustomerID;
                existingHeader.Status = updatedHeader.Status;

                db.SaveChanges();
            }
        }

        public static void DeleteTransactionHeader(int transactionId)
        {
            TransactionHeader header = db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
            if (header != null)
            {
                db.TransactionHeaders.Remove(header);
                db.SaveChanges();
            }
        }
    }
}