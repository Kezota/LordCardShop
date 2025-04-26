using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Repositories
{
    public class UserRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public static User GetUserById(int userId)
        {
            return db.Users.FirstOrDefault(u => u.UserID == userId);
        }

        public static void UpdateUser(User updatedUser)
        {
            User existingUser = db.Users.FirstOrDefault(u => u.UserID == updatedUser.UserID);
            if (existingUser != null)
            {
                existingUser.UserName = updatedUser.UserName;
                existingUser.UserEmail = updatedUser.UserEmail;
                existingUser.UserPassword = updatedUser.UserPassword;
                existingUser.UserGender = updatedUser.UserGender;
                existingUser.UserDOB = updatedUser.UserDOB;
                existingUser.UserRole = updatedUser.UserRole;

                db.SaveChanges();
            }
        }

        public static void DeleteUser(int userId)
        {
            User user = db.Users.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}