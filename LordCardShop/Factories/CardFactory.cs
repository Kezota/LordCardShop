using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Factories
{
    public class CardFactory
    {
        public static Card CreateCard(string cardName, float cardPrice, string cardType, string cardDesc, byte[] isFoil, int? cardID = null)
        {
            var card = new Card
            {
                CardName = cardName,
                CardPrice = cardPrice,
                CardType = cardType,
                CardDesc = cardDesc,
                IsFoil = isFoil
            };

            if (cardID.HasValue)
            {
                card.CardID = cardID.Value;
            }

            return card;
        }
    }
}