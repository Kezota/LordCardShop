using LordCardShop.Helper;
using LordCardShop.Helpers;
using LordCardShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handlers
{
    public static class SessionHandler
    {
        public static bool IsUserLoggedIn(int userId)
        {
            var user = SessionHelper.GetSession(userId);
            return user != null;
        }

        public static bool IsUserRoleCorrect(int userId, string role)
        {
            var user = UserRepository.GetUserById(userId);
            return user?.UserRole == role;
        }

        public static void Logout(int userId)
        {
            SessionHelper.DestroySession(userId);
            CookieHelper.ClearRememberMeCookie();
        }
    }
}