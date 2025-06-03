using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Helpers
{
    public static class SessionHelper
    {
        // Set session untuk user
        public static void SetSession(User user)
        {
            if (user != null)
            {
                HttpContext.Current.Session["User"] = user; // Simpan user di session
                HttpContext.Current.Session["Username"] = user.UserName; // Simpan user di session
                HttpContext.Current.Session["UserID"] = user.UserID; // Simpan ID user di session
                HttpContext.Current.Session["UserRole"] = user.UserRole; // Simpan role user di session
                HttpContext.Current.Session.Timeout = 60; // Set timeout session ke 60 menit
            }
        }

        // Ambil session user
        public static User GetSession(int userId)
        {
            var user = HttpContext.Current.Session["User"] as User;
            return user?.UserID == userId ? user : null; // Pastikan user ID cocok
        }

        // Ambil session user
        public static User GetCurrentUser()
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                return HttpContext.Current.Session["User"] as User;
            }
            return null; // Jika session tidak ada, kembalikan null
        }

        // Hapus session user
        public static void DestroySession(int userId)
        {
            var user = HttpContext.Current.Session["User"] as User;
            if (user?.UserID == userId)
            {
                HttpContext.Current.Session.Remove("User");
            }
        }
    }
}