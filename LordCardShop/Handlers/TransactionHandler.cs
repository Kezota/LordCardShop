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

        public static List<TransactionHeader> GetTransactionHistoryByUser(int userId)
        {
            return TransactionHeaderRepository.GetTransactionByCustomerId(userId);
        }

        public static List<TransactionHeader> GetAllTransactions()
        {
            return TransactionHeaderRepository.GetAllTransactionHeaders();
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

        // Note: Untuk View Transaction Report pake CrystalReport, biasanya dari Controller/View, bukan di handler.
        // Tapi Handler bisa disiapin method buat fetch all transactions untuk report.
        public static List<TransactionHeader> GetAllTransactionsForReport()
        {
            return TransactionHeaderRepository.GetAllTransactionHeaders();
        }
    }
}