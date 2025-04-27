using LordCardShop.Factories;
using LordCardShop.Model;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handlers
{
    public class CartHandler
    {
        public static (bool isSuccess, string errorMessage) AddCardToCart(int userId, int cardId, int quantity)
        {
            if (quantity <= 0)
            {
                return (false, "Quantity must be greater than 0.");
            }

            Card card = CardRepository.GetCardById(cardId);
            if (card == null)
            {
                return (false, "Card not found.");
            }

            Cart existingCart = CartRepository.GetCartByUserAndCard(userId, cardId);
            if (existingCart != null)
            {
                // Update quantity if already in cart
                int newQuantity = existingCart.Quantity + quantity;
                CartRepository.UpdateCartQuantity(existingCart.CartID, cardId, newQuantity);
            }
            else
            {
                Cart newCart = CartFactory.CreateCart(userId, cardId, quantity);
                CartRepository.AddCart(newCart);
            }

            return (true, "");
        }

        public static List<Cart> ViewCart(int userId)
        {
            return CartRepository.GetCartByUserId(userId);
        }

        public static (bool isSuccess, string errorMessage) ClearCart(int userId)
        {
            bool clearResult = CartRepository.ClearCartByUserId(userId);
            if (!clearResult)
            {
                return (false, "Failed to clear cart.");
            }
            return (true, "");
        }

        public static (bool isSuccess, string errorMessage) CheckoutCart(int userId)
        {
            List<Cart> carts = CartRepository.GetCartByUserId(userId);
            if (carts == null || carts.Count == 0)
            {
                return (false, "Cart is empty.");
            }

            TransactionHeader newTransaction = TransactionHeaderFactory.CreateTransactionHeader(DateTime.Now, userId, "Pending");
            var transactionId = TransactionHeaderRepository.AddTransactionHeader(newTransaction);

            if (transactionId == null || transactionId <= 0)
            {
                return (false, "Failed to create transaction header.");
            }

            foreach (var cart in carts)
            {
                TransactionDetail detail = TransactionDetailFactory.CreateTransactionDetail(transactionId, cart.CardID, cart.Quantity);
                TransactionDetailRepository.AddTransactionDetail(detail);
            }

            bool clearCartResult = CartRepository.ClearCartByUserId(userId);
            if (!clearCartResult)
            {
                return (false, "Failed to clear cart after checkout.");
            }

            return (true, "");
        }
    }
}