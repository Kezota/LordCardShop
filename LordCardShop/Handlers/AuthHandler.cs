using LordCardShop.Factories;
using LordCardShop.Helper;
using LordCardShop.Helpers;
using LordCardShop.Model;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LordCardShop.Handlers
{
    public static class AuthHandler
    {
        public static (bool success, string errorMessage) Login(string username, string password, bool rememberMe)
        {
            var user = UserRepository.GetUserByUsername(username); 
            if (user == null || !PasswordHelper.VerifyPassword(password, user.UserPassword))
            {
                return (false, "Invalid username or password.");
            }

            // Set session
            SessionHelper.SetSession(user);

            // Handle "remember me" with cookie if needed
            if (rememberMe)
            {
                CookieHelper.SetRememberMeCookie(user.UserID);
            }

            return (true, string.Empty);
        }

        public static (bool success, string errorMessage) Register(string username, string email, string password, string gender, DateTime dob, string role)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 30)
                return (false, "Username must be between 5 and 30 characters.");
            if (!email.Contains("@"))
                return (false, "Email must be valid.");
            if (password.Length < 8 || !password.Any(char.IsLetterOrDigit))
                return (false, "Password must be at least 8 characters long and alphanumeric.");
            if (string.IsNullOrEmpty(gender))
                return (false, "Gender must be chosen.");

            var hashedPassword = PasswordHelper.HashPassword(password);
            var user = UserFactory.CreateUser(username, email, hashedPassword, gender, dob, role);

            UserRepository.AddUser(user);

            return (true, string.Empty);
        }
    }
}