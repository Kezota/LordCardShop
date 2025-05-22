using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static List<CartItemData> GetCartByUserId(int userId)
        {
            var cartItems = (from c in db.Carts
                             join card in db.Cards on c.CardID equals card.CardID
                             where c.UserID == userId
                             select new CartItemData
                             {
                                 CartID = c.CartID,
                                 CardID = card.CardID,
                                 CardName = card.CardName,
                                 CardPrice = card.CardPrice,
                                 CardType = card.CardType,
                                 Quantity = c.Quantity
                             }).ToList();

            return cartItems;
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

            if (cart == null)
            {
               throw new Exception("Cart not found.");
            }

            if (quantity <= 0)
            {
                DeleteCardFromCart(cartId, cardId);
                db.SaveChanges();
            }

            cart.Quantity = quantity;
            db.SaveChanges();
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

        public static void DeleteCardFromCart(int cartId, int cardId)
        {
            // Cari cart item berdasarkan CartID dan CardID
            Cart cartItem = db.Carts.FirstOrDefault(c => c.CartID == cartId && c.CardID == cardId);

            if (cartItem != null)
            {
                // Jika item ditemukan, hapus dari database
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
            else
            {
                // Jika item tidak ditemukan, lemparkan exception atau kembalikan pesan kesalahan
                throw new Exception("The specified card is not found in the cart.");
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