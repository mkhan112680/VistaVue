using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using VistaDM.Code;
using VistaDM.Repository;
using System.Security.Principal;
using VistaDM.Domain;

namespace VistaDM.Admin.Code
{
    public class UserHelper
    {


        public static HttpCookie GetAuthorizationCookie(string userName, string userData)
        {
            HttpCookie httpCookie = FormsAuthentication.GetAuthCookie(userName, true);
            FormsAuthenticationTicket currentTicket = FormsAuthentication.Decrypt(httpCookie.Value);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(currentTicket.Version, currentTicket.Name, currentTicket.IssueDate, currentTicket.Expiration, currentTicket.IsPersistent, userData);
            httpCookie.Value = FormsAuthentication.Encrypt(ticket);
            return httpCookie;
        }

        public static Domain.SponserUser GetLoggedInUser(System.Web.SessionState.HttpSessionState session)
        {
            if (session[Constants.USER] == null)

                LoadDataIntoSession(session);

            return session[Constants.USER] as Domain.SponserUser;

        }

        public static void SetLoggedInUser(Domain.SponserUser user, System.Web.SessionState.HttpSessionState session)
        {

            session[Constants.USER] = user;

        }

        public static void ReloadUser(System.Web.SessionState.HttpSessionState session)
        {
            LoadDataIntoSession(session);
        }

        private static void LoadDataIntoSession(System.Web.SessionState.HttpSessionState session)
        {
            SponserRepository userRepo = new SponserRepository();
            Domain.SponserUser loggedUser = userRepo.GetDetailsByUsername(HttpContext.Current.User.Identity.Name);
            if (loggedUser != null)
            {
                //loggedUser.Roles.AddRange(userRepo.GetRolesAsArray(loggedUser.Username));

                session[Constants.USER] = loggedUser;
            }

        }

        public static Domain.SponserUser SetupUserOnLogin(string userName, string pass)
        {
                SponserRepository sponserRepo  = new SponserRepository();
            
                Domain.SponserUser loggedUser = sponserRepo.GetDetailsByUsername(userName);

                UserHelper.SetLoggedInUser(loggedUser, HttpContext.Current.Session);

                return loggedUser;
        }

        public static Domain.SponserUser SetupAdminOnLogin(string userName)
        {
                SponserRepository sponserRepo  = new SponserRepository();
            
                Domain.SponserUser loggedUser = sponserRepo.GetAdminDetails(userName);

                UserHelper.SetLoggedInUser(loggedUser, HttpContext.Current.Session);

                return loggedUser;
        }

        public static string GetURLByRole(SponserUser usr)
        {
            //1	Speciality Representative
            //2	Primary Care Representative
            //3	Hybrid Sales Representative 
            //4	Sales Manager 
            //5	Head Office

            string retURL = string.Empty;
            switch (usr.Role.ID)
            {

                case 1:


                    if ( usr.HasMoreThanOneProvince())
                    {
                        retURL = "~/SelectRegion.aspx";
                    }
                    else
                    {
                        retURL = string.Format("~/default.aspx?{0}={1}", Constants.PROVINCEID ,  usr.GetSelectedProvince());
                    }
                    
                    break;

                case 2:


                    if (usr.HasMoreThanOneProvince())
                    {
                        retURL = "~/SelectRegion.aspx";
                    }
                    else
                    {
                        retURL = string.Format("~/default.aspx?{0}={1}", Constants.PROVINCEID, usr.GetSelectedProvince());
                    }

                    break;

                case 3:

                    if (usr.HasMoreThanOneProvince())
                    {
                        retURL = "~/SelectProgram.aspx";
                    }
                    else
                    {
                        retURL = string.Format("~/SelectProgram.aspx?{0}={1}", Constants.PROVINCEID, usr.GetSelectedProvince());
                    }
                    
                   
                    break;

                case 4:

                    if (usr.HasMoreThanOneProvince())
                    {
                        retURL = "~/SelectProgram.aspx";
                    }
                    else
                    {
                        retURL = string.Format("~/SelectProgram.aspx?{0}={1}", Constants.PROVINCEID, usr.GetSelectedProvince());
                    }

                    break;

                case 5:

                    if (usr.HasMoreThanOneProvince())
                    {
                        retURL = "~/SelectProgram.aspx";
                    }
                    else
                    {
                        if (usr.TerritoryCovergae_All.HasValue && usr.TerritoryCovergae_All.Value)
                            retURL = string.Format("~/SelectProgram.aspx?{0}={1}", Constants.PROVINCEID, 0 );
                        else
                            retURL = string.Format("~/SelectProgram.aspx?{0}={1}", Constants.PROVINCEID, usr.GetSelectedProvince());
                    }
                    
                    break;


            }

            return retURL;

        }

        public static bool CanSelectProgram(SponserUser usr)
        {
            //1	Speciality Representative
            //2	Primary Care Representative
            //3	Hybrid Sales Representative 
            //4	Sales Manager 
            //5	Head Office

            bool retVal = false;
            switch (usr.Role.ID)
            {

                case 1:

                    retVal = false;
                    break;

                case 2:

                    retVal = false;
                    break;

                case 3:

                    retVal = true;
                    break;

                case 4:

                    retVal = true;
                    break;

                case 5:

                    retVal = true;
                    break;


            }

            return retVal;

        }

        public static string CanSelectRegion(SponserUser usr)
        {
            //1	Speciality Representative
            //2	Primary Care Representative
            //3	Hybrid Sales Representative 
            //4	Sales Manager 
            //5	Head Office

            string retURL = string.Empty;
            switch (usr.Role.ID)
            {

                case 1:

                    retURL = "~/SelectRegion.aspx";
                    break;

                case 2:

                    retURL = "~/SelectRegion.aspx";
                    break;

                case 3:

                    retURL = "~/SelectProgram.aspx";
                    break;

                case 4:
                    retURL = "~/SelectProgram.aspx";
                    break;

                case 5:

                    retURL = "~/SelectProgram.aspx";
                    break;


            }

            return retURL;

        }

    }
}