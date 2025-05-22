using System;
using System.Collections.Generic;
using LordCardShop.Handlers;
using LordCardShop.Model;

namespace LordCardShop.Controllers
{
    public class TransactionController
    {
        public static (bool isTrue, string message, List<TransactionHeader> transactionHeader) GetTransactionHistoryByUserId(int userId) {
            try
            {
                var transactionHistory = TransactionHandler.GetTransactionHistoryByUser(userId);
                return (true, "Berhasil mengambil riwayat transaksi", transactionHistory);
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil riwayat transaksi", null);
            }
        }
        
        public static (bool isTrue, string message, List<TransactionHeader> transactionHeader) GetAllTransactionHistory() {
            try
            {
                var transactionHistory = TransactionHandler.GetAllTransactions();
                return (true, "Berhasil mengambil semua riwayat transaksi", transactionHistory);
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil semua riwayat transaksi", null);
            }
        }

        public static TransactionHeader GetTransactionHeaderById(int transactionId) {
            try
            {
                var transactionHeader = TransactionHandler.GetTransactionHeaderById(transactionId);
                return transactionHeader;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static (bool isTrue, string message, TransactionDetail result) GetTransactionDetail(int transactionId, int cardId) {
            try
            {
                var transactionDetail = TransactionHandler.GetTransactionDetail(transactionId, cardId);
                return (true, "Berhasil mengambil detail transaksi", transactionDetail);
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil detail transaksi", null);
            }
        }
        
        public static (bool isTrue, string message, List<TransactionDetail> transactionDetails) GetTransactionDetailsByTransactionId(int transactionId) {
            try
            {
                var transactionDetails = TransactionHandler.GetTransactionDetailsByTransactionId(transactionId);
                return (true, "Berhasil mengambil detail transaksi", transactionDetails);
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil detail transaksi", null);
            }
        }

        public static (bool isTrue, string message) HandleTransaction(int transactionId)
        {
            try
            {
                var result = TransactionHandler.HandleTransaction(transactionId);
                return result;
            }
            catch (Exception)
            {
                return (false, "Gagal menangani transaksi");
            }
        }

        public static (bool isTrue, string message, List<TransactionHeader>) GetReports()
        {
            try {
                var reports = TransactionHandler.GetAllTransactionsForReport();
                return (true, "Berhasil mengambil laporan transaksi", reports);
            }
            catch (Exception) {
                return (false, "Gagal mengambil laporan transaksi", null);
            }
        }
    }
}