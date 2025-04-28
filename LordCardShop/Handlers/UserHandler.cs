using LordCardShop.Helper;
using LordCardShop.Model;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handlers
{
    public static class UserHandler
    {
        public static (bool success, string errorMessage) ProfileHandler(int userId, string username, string email, string password, string oldPassword, string gender, DateTime dob)
        {
            var user = UserRepository.GetUserById(userId);
            if (user == null)
            {
                return (false, "User not found.");
            }

            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 30)
                return (false, "Username must be between 5 and 30 characters.");
            if (!email.Contains("@"))
                return (false, "Email must be valid.");
            if (password.Length < 8 || !password.Any(char.IsLetterOrDigit))
                return (false, "Password must be at least 8 characters long and alphanumeric.");
            if (string.IsNullOrEmpty(gender))
                return (false, "Gender must be chosen.");

            if (!string.IsNullOrEmpty(password) && !PasswordHelper.VerifyPassword(oldPassword, user.UserPassword))
            {
                return (false, "Old password is incorrect.");
            }

            user.UserName = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = dob;
            if (!string.IsNullOrEmpty(password))
            {
                user.UserPassword = PasswordHelper.HashPassword(password);
            }

            UserRepository.UpdateUser(user);

            return (true, string.Empty);
        }
    
        public static (bool success, string errorMessage, User user) GetProfileById(int userId)
        {
            var user = UserRepository.GetUserById(userId);
            if (user == null)
            {
                return (false, "User not found.", user);
            }

            return (true, string.Empty, user);
        }

        public static (bool success, string errorMessage, User user) GetProfile(string username)
        {
            var user = UserRepository.GetUserByUsername(username);
            if (user == null)
            {
                return (false, "User not found.", user);
            }

            return (true, string.Empty, user);
        }
    }
}