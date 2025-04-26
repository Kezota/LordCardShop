using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Repositories
{
    public class CardRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static void AddCard(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
        }

        public static List<Card> GetAllCards()
        {
            return db.Cards.ToList();
        }

        public static Card GetCardById(int cardId)
        {
            return db.Cards.FirstOrDefault(c => c.CardID == cardId);
        }

        public static void UpdateCard(Card updatedCard)
        {
            Card existingCard = db.Cards.FirstOrDefault(c => c.CardID == updatedCard.CardID);
            if (existingCard != null)
            {
                existingCard.CardName = updatedCard.CardName;
                existingCard.CardPrice = updatedCard.CardPrice;
                existingCard.CardType = updatedCard.CardType;
                existingCard.IsFoil = updatedCard.IsFoil;

                db.SaveChanges();
            }
        }

        public static void DeleteCard(int cardId)
        {
            Card card = db.Cards.FirstOrDefault(c => c.CardID == cardId);
            if (card != null)
            {
                db.Cards.Remove(card);
                db.SaveChanges();
            }
        }
    }
}