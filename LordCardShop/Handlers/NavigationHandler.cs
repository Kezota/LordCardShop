using LordCardShop.Helpers;
using LordCardShop.Model;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handlers
{
    public class NavigationHandler
    {
        public static List<string> LoadNavigationMenu(string userRole)
        {
            List<string> menuItems = new List<string>();

            if (string.IsNullOrEmpty(userRole))
            {
                // Guest
                menuItems.Add("Home");
            }
            else if (userRole == "Customer")
            {
                menuItems.Add("Home");
                menuItems.Add("Order Card");
                menuItems.Add("Profile");
                menuItems.Add("History");
                menuItems.Add("Cart");
                menuItems.Add("Logout");
            }
            else if (userRole == "Admin")
            {
                menuItems.Add("Home");
                menuItems.Add("Manage Card");
                menuItems.Add("View Transaction");
                menuItems.Add("Transaction Report");
                menuItems.Add("Order Queue");
                menuItems.Add("Logout");
            }

            return menuItems;
        }

        public static string GetCurrentUserName()
        {
            var user = SessionHelper.GetCurrentUser(); // Pastikan ada SessionHelper class
            if (user == null)
            {
                return "Guest";
            }
            return user.UserName;
        }

        public static (List<Card>, string) SearchCardByName(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return (new List<Card>(), "Search query cannot be empty.");
            }

            var filteredCards = CardRepository.GetCardByName(searchQuery);

            if (filteredCards == null || filteredCards.Count == 0)
            {
                return (new List<Card>(), "No cards found matching your search.");
            }

            return (filteredCards, "");
        }
    }
}