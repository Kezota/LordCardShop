using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LordCardShop.Helper
{
    public static class PasswordHelper
    {
        // Hashing password menggunakan SHA256
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Verifikasi password
        public static bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            var hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword == storedPasswordHash;
        }
    }
}