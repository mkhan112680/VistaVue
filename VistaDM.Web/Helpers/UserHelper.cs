using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.SessionState;
using VistaDM.Web.Controllers;
using VistaDM.Web.Models;

namespace VistaDM.Web.Helpers
{
     
    public class UserHelper
    {

        public static UserModel GetLoggedInUser()
        {
            if (HttpContext.Current.Session[Constants.USER] == null)

                LoadDataIntoSession();

            return HttpContext.Current.Session[Constants.USER] as UserModel;

        }

        private static void SetLoggedInUser(UserModel user)
        {

            HttpContext.Current.Session[Constants.USER] = user;

        }

        public static void ReloadUser()
        {
            LoadDataIntoSession();
        }

        private static void LoadDataIntoSession()
        {
            PhysicianController usrControler = new PhysicianController();

            Models.UserModel user = usrControler.GetUserDetails();

            if (user != null)
            {
                HttpContext.Current.Session[Constants.USER] = user;
            }

        }

        public static string GetUserName()
        {
            string retStr = string.Empty;

            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.Name);

                if (userIdClaim != null)
                {
                    retStr = userIdClaim.Value;
                }
            }

            return retStr;
        }

        public static int GetUserID()
        {
            string retStr = string.Empty;

            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    retStr = userIdClaim.Value;
                }
            }

            return Int32.Parse(retStr);
        }

        public static string GetUserFullName()
        {

            var user = GetLoggedInUser();
            
            string fullName = user.FirstName + " " + user.LastName;

            return fullName;
        }
    }
}