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

        public static void AddTransactionHeader(TransactionHeader header)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static TransactionHeader GetTransactionHeaderById(int transactionId)
        {
            return db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
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