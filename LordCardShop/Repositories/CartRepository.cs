using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Repositories
{
    public class CartRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static void AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static List<Cart> GetAllCarts()
        {
            return db.Carts.ToList();
        }

        public static Cart GetCartById(int cartId)
        {
            return db.Carts.FirstOrDefault(c => c.CartID == cartId);
        }

        public static Cart GetCartByUserAndCard(int userId, int cardId)
        {
            return db.Carts.FirstOrDefault(c => c.UserID == userId && c.CardID == cardId);
        }

        public static List<Cart> GetCartByUserId(int userId)
        {
            return db.Carts.Where(c => c.UserID == userId).ToList();
        }

        public static void UpdateCart(Cart updatedCart)
        {
            Cart existingCart = db.Carts.FirstOrDefault(c => c.CartID == updatedCart.CartID);
            if (existingCart != null)
            {
                existingCart.CardID = updatedCart.CardID;
                existingCart.UserID = updatedCart.UserID;
                existingCart.Quantity = updatedCart.Quantity;

                db.SaveChanges();
            }
        }

        public static void UpdateCartQuantity(int cartId, int cardId, int quantity)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.CartID == cartId && c.CardID == cardId);
            if (cart != null)
            {
                cart.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public static void DeleteCart(int cartId)
        {
            Cart cart = db.Carts.FirstOrDefault(c => c.CartID == cartId);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }

        public static bool ClearCartByUserId(int userId)
        {
            try
            {
                List<Cart> carts = db.Carts.Where(c => c.UserID == userId).ToList();
                db.Carts.RemoveRange(carts);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}