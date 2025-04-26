using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Factories
{
    public class CartFactory
    {
        public static Cart CreateCart(int userID, int cardID, int quantity, int? cartID = null)
        {
            var cart = new Cart
            {
                UserID = userID,
                CardID = cardID,
                Quantity = quantity
            };

            if (cartID.HasValue)
            {
                cart.CartID = cartID.Value;
            }

            return cart;
        }
    }
}