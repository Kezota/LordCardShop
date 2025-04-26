using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int transactionID, int cardID, int quantity)
        {
            var transactionDetail = new TransactionDetail
            {
                TransactionID = transactionID,
                CardID = cardID,
                Quantity = quantity
            };

            return transactionDetail;
        }
    }
}