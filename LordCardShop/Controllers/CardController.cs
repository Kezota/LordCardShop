using System;
using System.Collections.Generic;
using LordCardShop.Handlers;
using LordCardShop.Model;

namespace LordCardShop.Controllers
{
    public class CardController
    {
        public static (bool isTrue, string message, Card cardDetail) ViewCard(int cardId)
        {
            try
            {
                if (cardId <= 0)
                {
                    return (false, "ID Card tidak valid", null);
                }
                return (true, "Card info berhasil diambil", CardHandler.GetCardDetail(cardId));
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil info Card", null);
            }
        }

        public static (bool isTrue, string message, List<Card> cardLists) GetAllCards()
        {
            try
            {
                if (CardHandler.GetAllCardsForCustomer() == null || CardHandler.GetAllCardsForCustomer().Count == 0)
                {
                    return (false, "Tidak ada Card yang tersedia", null);
                }
                return (true, "Cards Info List berhasil diambil", CardHandler.GetAllCardsForCustomer());
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil List Cards", null);
            }
        }

        public static (bool isTrue, string message) UpdateCard(int cardId, string name, float price, string description, string type, string foil)
        {
            try
            {
                if (cardId <= 0)
                {
                    return (false, "ID Card tidak valid");
                }
                if (string.IsNullOrEmpty(name) || price <= 0 || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(type))
                {
                    return (false, "Data Card tidak lengkap");
                }
                if (foil != "Yes" && foil != "No")
                {
                    return (false, "Data Foil tidak valid");
                }
                if (foil == "Yes")
                {
                    foil = "True";
                }
                else
                {
                    foil = "False";
                }
                ManageCardHandler.UpdateCard(cardId, name, price, description, type, foil);
                return (true, "Card berhasil diupdate");
            }
            catch (Exception)
            {
                return (false, "Gagal mengupdate Card");
            }
        }

        public static (bool isTrue, string message) DeleteCard(int idCard)
        {
            try
            {
                if (idCard <= 0)
                {
                    return (false, "ID Card tidak valid");
                }
                CardHandler.DeleteCard(idCard);
                return (true, "Card berhasil dihapus");
            }
            catch (Exception)
            {
                return (false, "Gagal menghapus Card");
            }
        }

        public static (bool isTrue, string message) AddCard(string name, float price, string description, string type, string foil)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || price <= 0 || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(type))
                {
                    return (false, "Data Card tidak lengkap");
                }
                ManageCardHandler.InsertNewCard(name, price, description, type, foil);
                return (true, "Berhasil menambahkan Card");
            }
            catch (Exception)
            {
                return (false, "Gagal menambahkan Card");
            }
        }
    }
}