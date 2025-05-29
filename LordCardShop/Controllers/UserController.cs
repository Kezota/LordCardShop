using LordCardShop.Handlers;
using LordCardShop.Helpers;
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
                if (string.IsNullOrEmpty(username))
                {
                    return (false, "Username tidak boleh kosong.", null);
                }
                return UserHandler.GetProfile(username);
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil profil pengguna.", null);
            }
        }

        public static (bool, string) UpdateProfile(string newName, string newEmail, string newPassword, string oldPassword, string gender, DateTime dob)
        {
            try
            {
                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newEmail) || string.IsNullOrEmpty(oldPassword))
                {
                    return (false, "Data tidak lengkap.");
                }
                return UserHandler.ProfileHandler(newName, newEmail, newPassword, oldPassword, gender, dob);
            }
            catch (Exception)
            {
                return (false, "Gagal memperbarui profil.");
            }
        }

        public static (bool, string, User) GetCurrentUser()
        {
            try
            {
                if (SessionHelper.GetCurrentUser() == null)
                {
                    return (false, "Pengguna tidak ditemukan dalam sesi.", null);
                }
                var user = SessionHelper.GetCurrentUser();
                return (true, string.Empty, user);
            }
            catch (Exception)
            {
                return (false, "Gagal mengambil pengguna saat ini.", null);
            }
        }
    }

}