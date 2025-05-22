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