using LordCardShop.Handlers;
using LordCardShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Controllers
{
    public static class AuthController
    {
        public static (bool, string) Login(string username, string password)
        {
            try
            {
                return AuthHandler.Login(username, password, true);
            }
            catch (Exception)
            {
                return (false, "Login gagal.");
            }
        }

        public static (bool, string) Register(string username, string email, string password, string gender, DateTime dob, string role)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 30)
                    return (false, "Username must be between 5 and 30 characters.");
                if (!email.Contains("@"))
                    return (false, "Email must be valid.");
                if (password.Length < 8 || !password.Any(char.IsLetterOrDigit))
                    return (false, "Password must be at least 8 characters long and alphanumeric.");
                if (string.IsNullOrEmpty(gender))
                    return (false, "Gender must be chosen.");
                return AuthHandler.Register(username, email, password, gender, dob, role);
            }
            catch (Exception)
            {
                return (false, "Registrasi gagal.");
            }
        }

        public static void Logout()
        {
            var user = SessionHelper.GetCurrentUser();
            SessionHandler.Logout(user.UserID);
        }
    }
}