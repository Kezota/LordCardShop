using System;
using System.Collections.Generic;
using LordCardShop.Handlers;
using LordCardShop.Model;
namespace LordCardShop.Controllers
{
    public class CartController
    {
        public static (bool isTrue, string message) AddCardToCart(int userId, int cardId, int quantity)
        {
            if (userId <= 0 || cardId <= 0 || quantity <= 0)
            {
                return (false, "Invalid user ID, card ID, or quantity.");
            }
            var (isSuccess, errorMessage) = CartHandler.AddCardToCart(userId, cardId, quantity);
            if (isSuccess)
            {
                return (true, "Card successfully added to cart.");
            }
            return (false, errorMessage);
        }

        public static (bool isTrue, string message, List<CartItemData> cartItems) ViewCart(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    return (false, "Invalid user ID.", null);
                }
                var cartItems = CartHandler.ViewCart(userId);
                return (true, "Cart items retrieved successfully.", cartItems);
            }
            catch (Exception)
            {
                return (false, "Failed to retrieve cart items.", null);
            }
        }

        public static (bool isTrue, string message) ClearCart(int userId)
        {
            if (userId <= 0)
            {
                return (false, "Invalid user ID.");
            }
            var (isSuccess, errorMessage) = CartHandler.ClearCart(userId);
            if (isSuccess)
            {
                return (true, "Cart cleared successfully.");
            }
            return (false, errorMessage);
        }

        public static (bool isTrue, string message) CheckoutCart(int userId)
        {
            if (userId <= 0)
            {
                return (false, "Invalid user ID.");
            }
            var (isSuccess, errorMessage) = CartHandler.CheckoutCart(userId);
            if (isSuccess)
            {
                return (true, "Checkout completed successfully.");
            }
            return (false, errorMessage);
        }

        public static (bool isSuccess, string errorMessage) UpdateCart(int cartId, int cardId, int quantity)
        {
            if (cartId <= 0 || cardId <= 0 || quantity <= 0)
            {
                return (false, "Invalid cart ID, card ID, or quantity.");
            }
            return CartHandler.UpdateCart(cartId, cardId, quantity);
        }

        public static (bool isSuccess, string errorMessage) DeleteCardFromCart(int cartId, int cardId)
        {
            if (cartId <= 0 || cardId <= 0)
            {
                return (false, "Invalid cart ID or card ID.");
            }
            return CartHandler.DeleteCardFromCart(cartId, cardId);
        }
    }
}
