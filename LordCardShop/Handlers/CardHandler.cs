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
    }
}