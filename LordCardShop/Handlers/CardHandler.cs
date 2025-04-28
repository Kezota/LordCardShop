using LordCardShop.Factories;
using LordCardShop.Model;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handlers
{
    public static class CardHandler
    {
        public static List<Card> GetAllCardsForCustomer()
        {
            return CardRepository.GetAllCards();
        }

        public static Card GetCardDetail(int cardId)
        {
            return CardRepository.GetCardById(cardId);
        }

        public static void UpdateCard(Card card)
        {
            var cardToUpdate = CardFactory.CreateCard(card.CardName, card.CardPrice, card.CardType, card.CardDesc, card.IsFoil, card.CardID);
            var cardInDb = CardRepository.GetCardById(card.CardID);
            if (cardInDb != null)
            {
                cardInDb.CardName = cardToUpdate.CardName;
                cardInDb.CardPrice = cardToUpdate.CardPrice;
                cardInDb.CardType = cardToUpdate.CardType;
                cardInDb.CardDesc = cardToUpdate.CardDesc;
                cardInDb.IsFoil = cardToUpdate.IsFoil;

                CardRepository.UpdateCard(cardInDb);
            }
            else
            {
                throw new Exception("Card not found");
            }
        }
        
        public static void AddCard(Card card) {
            var newCard = CardFactory.CreateCard(card.CardName, card.CardPrice, card.CardType, card.CardDesc, card.IsFoil);
            CardRepository.AddCard(newCard);
        }
        
        public static void DeleteCard(int cardId) {
            var card = CardRepository.GetCardById(cardId);
            if (card != null)
            {
                CardRepository.DeleteCard(card);
            }
            else
            {
                throw new Exception("Card not found");
            }
        }
    }
}