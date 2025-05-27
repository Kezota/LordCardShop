using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LordCardShop.Repositories
{
    public class TransactionDetailRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static void AddTransactionDetail(TransactionDetail detail)
        {
            //db.TransactionDetails.Add(detail);
            //db.SaveChanges();

            // Menyusun query SQL
            string sql = "INSERT INTO TransactionDetail (TransactionID, CardID, Quantity) " +
                         "VALUES (@TransactionID, @CardID, @Quantity)";

            // Parameter yang dibutuhkan untuk query
            var parameters = new[]
            {
                new SqlParameter("@TransactionID", detail.TransactionID),
                new SqlParameter("@CardID", detail.CardID),
                new SqlParameter("@Quantity", detail.Quantity),
            };

            // Menjalankan raw SQL query menggunakan ExecuteSqlCommand
            db.Database.ExecuteSqlCommand(sql, parameters);
        }

        public static List<TransactionDetail> GetAllTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }

        public static TransactionDetail GetTransactionDetail(int transactionId, int cardId)
        {
            return db.TransactionDetails.FirstOrDefault(td => td.TransactionID == transactionId && td.CardID == cardId);
        }

        public static List<TransactionDetail> GetTransactionDetailsById(int transactionId)
        {
            return db.TransactionDetails.Where(td => td.TransactionID == transactionId).ToList();
        }

        public static void UpdateTransactionDetail(TransactionDetail updatedDetail)
        {
            TransactionDetail existingDetail = db.TransactionDetails.FirstOrDefault(td => td.TransactionID == updatedDetail.TransactionID && td.CardID == updatedDetail.CardID);
            if (existingDetail != null)
            {
                existingDetail.Quantity = updatedDetail.Quantity;

                db.SaveChanges();
            }
        }

        public static void DeleteTransactionDetail(int transactionId, int cardId)
        {
            TransactionDetail detail = db.TransactionDetails.FirstOrDefault(td => td.TransactionID == transactionId && td.CardID == cardId);
            if (detail != null)
            {
                db.TransactionDetails.Remove(detail);
                db.SaveChanges();
            }
        }
    }
}