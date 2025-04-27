using System;
using System.Text;
using System.Web;

namespace LordCardShop.Helper
{
    public static class CookieHelper
    {
        private static readonly string CookieName = "RememberMeCookie";

        // Set cookie "Remember Me" with user ID and expiration date
        public static void SetRememberMeCookie(int userId)
        {
            var cookieValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(userId.ToString()));

            // Create a new cookie
            HttpCookie cookie = new HttpCookie(CookieName, cookieValue)
            {
                Expires = DateTime.Now.AddDays(1), // Cookie expires in 1 day
                HttpOnly = true, // Prevent access to the cookie via JavaScript
                Secure = HttpContext.Current.Request.IsSecureConnection // Only send over HTTPS
            };

            // Add the cookie to the response
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        // Get the "Remember Me" cookie to retrieve the user ID
        public static int? GetRememberMeCookie()
        {
            var cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                try
                {
                    var userIdString = Encoding.UTF8.GetString(Convert.FromBase64String(cookie.Value));
                    if (int.TryParse(userIdString, out var userId))
                    {
                        return userId;
                    }
                }
                catch
                {
                    // Handle invalid Base64 or parsing errors gracefully
                    return null;
                }
            }
            return null;
        }

        // Clear the "Remember Me" cookie
        public static void ClearRememberMeCookie()
        {
            if (HttpContext.Current.Request.Cookies[CookieName] != null)
            {
                // Create a cookie with the same name and set its expiration to the past
                HttpCookie cookie = new HttpCookie(CookieName)
                {
                    Expires = DateTime.Now.AddDays(-1) // Expire the cookie immediately
                };

                // Add the expired cookie to the response to overwrite the existing one
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}
