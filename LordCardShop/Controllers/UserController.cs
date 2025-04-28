using LordCardShop.Handlers;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Controllers
{
    public static class UserController
    {
        public static (bool, string, User) ShowProfile(string username)
        {
            try
            {
                return UserHandler.GetProfile(username);
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil profil pengguna.", null);
            }
        }

        public static (bool, string) UpdateProfile(int userId, string newName, string newEmail, string newPassword, string oldPassword, string gender, DateTime dob)
        {
            try
            {
                return UserHandler.ProfileHandler(userId, newName, newEmail, newPassword, oldPassword, gender, dob);
            }
            catch (Exception)
            {
                return (false, "Gagal memperbarui profil.");
            }
        }
    }

}