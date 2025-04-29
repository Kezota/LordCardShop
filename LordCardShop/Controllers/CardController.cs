using System;
using System.Collections.Generic;
using LordCardShop.Handlers;
using LordCardShop.Model;

namespace LordCardShop.Controllers
{
    public class CardController
    {
        public static (bool isTrue , string message, Card cardDetail) ViewCard(int cardId) {
            try
            {
                return (true, "Card info berhasil diambil", CardHandler.GetCardDetail(cardId));
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil info Card", null);
            }
        }

        public static (bool isTrue, string message , List<Card> cardLists) GetAllCards()
        {
            try
            {
                return (true, "Cards Info List berhasil diambil", CardHandler.GetAllCardsForCustomer());
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil List Cards", null);
            }
        }

        public static (bool isTrue, string message) UpdateCard(Card card)
        {
            try
            {
                CardHandler.UpdateCard(card);
                return (true, "Card berhasil diupdate");
            }
            catch (Exception)
            {
                return (false, "Gagal mengupdate Card");
            }
        }

        public static (bool isTrue, string message) DeleteCard(int  idCard)
        {
            try
            {
                CardHandler.DeleteCard(idCard);
                return (true, "Card berhasil dihapus");
            }
            catch (Exception)
            {
                return (false, "Gagal menghapus Card");
            }
        }
    }
}