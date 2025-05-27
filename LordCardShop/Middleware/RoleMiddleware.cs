using System.Linq;
using System.Web.SessionState;
using System.Web.UI;

namespace LordCardShop.Middleware
{
    public static class RoleMiddleware
    {
        public static bool IsLoggedIn(HttpSessionState session)
        {
            return session["User"] != null && session["UserRole"] != null;
        }

        public static bool IsInRole(HttpSessionState session, params string[] roles)
        {
            if (!IsLoggedIn(session)) return false;
            string role = session["UserRole"].ToString();
            return roles.Contains(role);
        }

        public static void RedirectIfUnauthorized(Page page, string[] allowedRoles)
        {
            var session = page.Session;

            if (!IsLoggedIn(session) || !IsInRole(session, allowedRoles))
            {
                page.Response.Redirect("~/Views/Login.aspx");
            }
        }
    }
}