using LordCardShop.Factories;
using LordCardShop.Helpers;
using LordCardShop.Model;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handlers
{
    public static class ManageCardHandler
    {
        public static List<Card> GetAllCardsForAdmin()
        {
            return CardRepository.GetAllCards();
        }

        public static (Card, string) InsertNewCard(string name, float price, string description, string type, string foil)
        {
            // Validation
            string error = ValidateHelper.ValidateCard(name, price, description, type, foil);
            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            byte[] isFoil = foil.ToLower() == "yes" ? new byte[] { 1 } : new byte[] { 0 };

            Card newCard = CardFactory.CreateCard(name, price, type, description, isFoil);
            CardRepository.AddCard(newCard);

            return (newCard, "");
        }

        public static (Card, string) UpdateCard(int cardId, string name, float price, string description, string type, string foil)
        {
            // Validation
            string error = ValidateHelper.ValidateCard(name, price, description, type, foil);
            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            Card existingCard = CardRepository.GetCardById(cardId);
            if (existingCard == null)
            {
                return (null, "Card not found.");
            }

            byte[] isFoil = foil.ToLower() == "yes" ? new byte[] { 1 } : new byte[] { 0 };

            existingCard.CardName = name;
            existingCard.CardPrice = price;
            existingCard.CardDesc = description;
            existingCard.CardType = type;
            existingCard.IsFoil = isFoil;

            CardRepository.UpdateCard(existingCard);

            return (existingCard, "");
        }

        public static string DeleteCard(int cardId)
        {
            Card card = CardRepository.GetCardById(cardId);
            if (card == null)
            {
                return "Card not found.";
            }

            CardRepository.DeleteCard(card);
            return "";
        }
    }

}