using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistaDM.Code;

namespace VistaDM.Admin.Code
{
    public class CookieHelper
    {
        public static void WriteCookie(string userName , bool rememberMe)
        {
            if (rememberMe)
            {
                HttpCookie cookie = new HttpCookie(Constants.SITECOOKIE);
                cookie.Value = userName;
                //cookie.Expires.AddDays(10);
                cookie.Expires =  DateTime.Now.AddDays(100);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static  string GetCookieVal( string cookieName)
        {
            string retVal = string.Empty;

            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            if (cookie != null)
            {
                retVal = cookie.Value;
            }

            return retVal;
        }
    }
}