using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(DateTime transactionDate, int customerID, string status, int? transactionID = null)
        {
            var transactionHeader = new TransactionHeader
            {
                TransactionDate = transactionDate,
                CustomerID = customerID,
                Status = status
            };

            if (transactionID.HasValue)
            {
                transactionHeader.TransactionID = transactionID.Value;
            }

            return transactionHeader;
        }
    }
}