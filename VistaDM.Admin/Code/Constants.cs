using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Web.Configuration;
using System.Configuration;

namespace VistaDM.Code
{
    public static class Constants
    {

      

        public static readonly int NOID = -1;
        public static readonly string SITECOOKIE = "VISTAMD";
        public static readonly string ID = "ID";
        public static readonly string USERID = "USERID";
        public static readonly string USER = "USER";
        public static readonly string SCREENID = "SCREENID";
        public static readonly string REGISTARTION_CODE = "REGISTARTION_CODE";
        public static readonly string SALUTATION_STR = "(e)";

        public static readonly string NOVALUESELECTED = "---";

        public static readonly string PHYSICIAN_ROLE = "Physician";
        public static readonly string SPONSER_ROLE = "Sponser";
        public static readonly string VALIENT_ROLE = "Valeant";
        public static readonly string ADMIN_ROLE = "Admin";

        public static readonly string CHRC_STR = "chrc";
        public static readonly string SUPER_STR = "super";
        public static readonly string ALLIANCE_STR = "alliance";
        public static readonly string ADMIN_LOGINPAGE = "AdminLogin.aspx";
        public static readonly string SPONSER_LOGINPAGE = "Login.aspx";
        

     
        public static readonly string NOTIFIEDOFREGISTRANT = "NOTIFIEDOFREGISTRANT";
        public static readonly string SMTPSERVER = "SMTPSERVER";
        public static readonly string SMTPUSER = "SMTPUSER";
        public static readonly string SMTPPASSWORD = "SMTPPASSWORD";
        public static readonly string SMTPPORT = "SMTPPORT";
        public static readonly string PORTAL_OPEN = "PORTAL_OPEN";

        public static readonly string PROVINCEID = "RPID";
        public static readonly string PROGRAM    = "PROGRAM";
        public static readonly string IS_PCP = "NOSP";

        public static readonly string ISFRENCH = "ISFRENCH";
        public static readonly string PATIENTID = "PATIENTID";
        public static readonly string READONLY = "READONLY";
        public static readonly string PATIENTNUM = "PATIENTNUM";
        public static readonly string UPDATESCREENNUM = "UPDATESCREENNUM";
        public static readonly string MODE = "MODE";
        public static readonly string VALEANT = "VALEANT";
        public static readonly string ADMIN = "ADMIN";
        public static readonly string LASTNAME = "LASTNAME";
        public static readonly string CULTUREINFO = "CULTUREINFO";
        public static readonly string FRENCH_CULTURE = "fr-CA";
        public static readonly string ENGLISH_CULTURE = "en-CA";
        public static readonly string FRANÇAIS_URL = "~/images/french.png";
        public static readonly string ENGLISH_URL = "~/images/english.png";
        public static readonly string FRANÇAIS = "FRANÇAIS";
        public static readonly string ENGLISH = "ENGLISH";

        public static readonly string LOG_IN_PAGE = "Login.aspx";
        public static readonly string LOG_OUT_PAGE = "Logout.aspx";

        public static readonly string FORGOTPWD_SPONSER_HTML = "~/ForgotPassword_Sponser.html";

        public static readonly string EMAILGENERAL = ConfigurationSettings.AppSettings["EMAILGENERAL"].ToString();  
        public static readonly string ADMIN_USER = ConfigurationSettings.AppSettings["ADMIN_USER"].ToString();
        public static readonly string ADMIN_PWD = ConfigurationSettings.AppSettings["ADMIN_PWD"].ToString();
        
        public static readonly string ELMAH_CONN_STR = WebConfigurationManager.ConnectionStrings["ErrorLog"].ConnectionString;
        public static readonly string SUPERPASSWORD = ConfigurationSettings.AppSettings["superPassword"].ToString();

        public static readonly int Visit2StartGap = Int32.Parse(ConfigurationSettings.AppSettings["Visit2StartGap"].ToString());
        public static readonly int Visit2EndGap = Int32.Parse(ConfigurationSettings.AppSettings["Visit2EndGap"].ToString());
        public static readonly int Visit3StartGap = Int32.Parse(ConfigurationSettings.AppSettings["Visit3StartGap"].ToString());
        public static readonly int Visit3EndGap = Int32.Parse(ConfigurationSettings.AppSettings["Visit3EndGap"].ToString());

        public static readonly bool IsPortalOpen = ConfigurationSettings.AppSettings["PORTAL_OPEN"].ToString() == "1";

        public static string GetCorrectPortalURL()
        {
            string returl = string.Empty;

            if (IsPortalOpen)
                returl = "~/Portal/Patients.aspx";
            else
                returl = "~/Portal/ComingSoon.aspx";

            return returl;
        }

        public static string GetPortalURLForPhysician(string url)
        {
            string returl = string.Empty;

            if (
                    url.ToLower().Contains(Constants.ADMIN.ToLower()) ||
                    url.ToLower().Contains(Constants.VALEANT.ToLower())
                )
                returl = GetCorrectPortalURL();
            else
                returl = url;

            return returl;
        }


        public static readonly List<string> ColeseumDosage = new List<string>() 
        { 
        
                "1875 mg (3 tablets)"   ,
                "2500 mg (4 tablets)"	,
                "3125 mg (5 tablets)"	,
                "3750 mg (6 tablets)"	,
                "3750 mg (Sachet) OD",
                "4375 mg (7 tablets)"   
        };

        public static readonly List<string> ColeseumDosageFR = new List<string>() 
        { 
        
                "1875 mg (3 comprimés)"	,
                "2500 mg (4 comprimés)"	, 
                "3125 mg (5 comprimés)"	, 
                "3750 mg (6 comprimés)" ,
                "3750 mg (Sachet) OD",
                "4375 mg (7 comprimés)"
        };


        public enum LoginType
        {
            Physician = 0,
            Sponser = 1,
            Admin = 2
        }

    }
}