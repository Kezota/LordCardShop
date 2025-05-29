using System;
using System.Collections.Generic;
using LordCardShop.Handlers;
using LordCardShop.Model;

namespace LordCardShop.Controllers
{
    public class TransactionController
    {
        public static (bool isTrue, string message, List<TransactionHistoryData> transactionHeader) GetTransactionHistoryByUserId(int userId) {
            try
            {
                if (userId <= 0)
                {
                    return (false, "ID User tidak valid", null);
                }
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
                if (transactionId <= 0)
                {
                    return null;
                }
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
                if (transactionId <= 0 || cardId <= 0)
                {
                    return (false, "ID transaksi atau ID kartu tidak valid", null);
                }
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
                if (transactionId <= 0)
                {
                    return (false, "ID transaksi tidak valid", null);
                }
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
                if (transactionId <= 0)
                {
                    return (false, "ID transaksi tidak valid");
                }
                var result = TransactionHandler.HandleTransaction(transactionId);
                return result;
            }
            catch (Exception)
            {
                return (false, "Gagal menangani transaksi");
            }
        }

        public static (bool isTrue, string message, List<TransactionReportData>) GetTransactionReportData()
        {
            try {
                var (isSuccess, message, transactions) = TransactionHandler.GetTransactionReport();
                return (true, "Berhasil mengambil laporan transaksi", transactions);
            }
            catch (Exception) {
                return (false, "Gagal mengambil laporan transaksi", null);
            }
        }
    }
}