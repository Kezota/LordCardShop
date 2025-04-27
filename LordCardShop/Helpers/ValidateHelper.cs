using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Helpers
{
    public static class ValidateHelper
    {
        public static string ValidateCard(string name, float price, string description, string type, string foil)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 50 || !IsAlphabetWithSpace(name))
            {
                return "Name must be 5-50 characters and alphabet with spaces only.";
            }

            if (price < 10000)
            {
                return "Price must be greater or equal to 10000.";
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                return "Description must not be empty.";
            }

            if (type.ToLower() != "spell" && type.ToLower() != "monster")
            {
                return "Type must be Spell or Monster.";
            }

            if (foil.ToLower() != "yes" && foil.ToLower() != "no")
            {
                return "Foil must be Yes or No.";
            }

            return "";
        }

        public static bool IsAlphabetWithSpace(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public static int convertByteToInt(byte[] bytes)
        {
            int result = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                result += bytes[i] * (int)Math.Pow(256, i);
            }
            return result;
        }
    }
}