using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Factories
{
    public class UserFactory
    {
        public static User CreateUser(string userName, string userEmail, string userPassword, string userGender, DateTime userDOB, string userRole, int? userID = null)
        {
            var user = new User
            {
                UserName = userName,
                UserEmail = userEmail,
                UserPassword = userPassword,
                UserGender = userGender,
                UserDOB = userDOB,
                UserRole = userRole
            };

            if (userID.HasValue)
            {
                user.UserID = userID.Value;
            }

            return user;
        }
    }
}