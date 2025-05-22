using LordCardShop.Factories;
using LordCardShop.Model;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handlers
{
    public class TransactionHandler
    {
        public static (bool isSuccess, string errorMessage) CreateTransaction(int userId)
        {
            var cartItems = CartRepository.GetCartByUserId(userId);

            if (cartItems == null || cartItems.Count == 0)
            {
                return (false, "Your cart is empty!");
            }

            try
            {
                // Create Transaction Header
                TransactionHeader transactionHeader = TransactionHeaderFactory.CreateTransactionHeader(DateTime.Now, userId, "Unhandled");
                TransactionHeaderRepository.AddTransactionHeader(transactionHeader);

                foreach (var cartItem in cartItems)
                {
                    TransactionDetail transactionDetail = TransactionDetailFactory.CreateTransactionDetail(transactionHeader.TransactionID, cartItem.CardID, cartItem.Quantity);
                    TransactionDetailRepository.AddTransactionDetail(transactionDetail);
                }

                // Clear cart
                CartRepository.ClearCartByUserId(userId);

                return (true, "Transaction successful!");
            }
            catch (Exception ex)
            {
                return (false, $"Transaction failed: {ex.Message}");
            }
        }

        public static List<TransactionHistoryData> GetTransactionHistoryByUser(int userId)
        {
            // Ambil data transaksi berdasarkan UserID
            var transactions = TransactionHeaderRepository.GetTransactionByCustomerId(userId);

            // Kelompokkan transaksi berdasarkan TransactionID dan jumlahkan subtotalnya
            var groupedTransactions = transactions
                .GroupBy(t => t.TransactionID) // Kelompokkan berdasarkan TransactionID
                .Select(group => new TransactionHistoryData
                {
                    TransactionID = group.Key,
                    TransactionDate = group.First().TransactionDate,
                    Status = group.First().Status,
                    Subtotal = group.Sum(t => t.Subtotal) // Jumlahkan subtotal untuk setiap TransactionID
                }).ToList();

            return groupedTransactions;
        }

        public static List<TransactionHeader> GetAllTransactions()
        {
            return TransactionHeaderRepository.GetAllTransactionHeaders();
        }

        public static TransactionHeader GetTransactionHeaderById(int transactionId) 
        {
            return TransactionHeaderRepository.GetTransactionHeaderById(transactionId);
        }

        public static TransactionDetail GetTransactionDetail(int transactionId, int cardId)
        {
            return TransactionDetailRepository.GetTransactionDetail(transactionId, cardId);
        }

        public static List<TransactionDetail> GetTransactionDetailsByTransactionId(int transactionId)
        {
            return TransactionDetailRepository.GetTransactionDetailsById(transactionId);
        }

        public static (bool, string) HandleTransaction(int transactionId)
        {
            var transaction = TransactionHeaderRepository.GetTransactionHeaderById(transactionId);
            if (transaction == null)
            {
                return (false, "Transaction not found!");
            }

            if (transaction.Status == "Handled")
            {
                return (false, "Transaction already handled!");
            }

            try
            {
                transaction.Status = "Handled";
                TransactionHeaderRepository.UpdateTransactionHeader(transaction);
                return (true, "Transaction handled successfully!");
            }
            catch (Exception ex)
            {
                return (false, $"Failed to handle transaction: {ex.Message}");
            }
        }

        public static (bool isSuccess, string message, List<TransactionReportData> transactions) GetTransactionReport()
        {
            try
            {
                var transactions = TransactionRepository.GetTransactionReport();
                if (transactions.Count > 0)
                {
                    return (true, "Data retrieved successfully.", transactions);
                }
                else
                {
                    return (false, "No transactions found.", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred: {ex.Message}", null);
            }
        }
    }
}