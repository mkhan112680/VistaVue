using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Helpers
{
    public static class Constants
    {
        
         static Constants()
        {

        }
        
        public static readonly string USER          = "USER";

        public static readonly string INVITEE       = "INVITEE";

        public static readonly string EMAILGENERAL  = ConfigurationSettings.AppSettings["EMAILGENERAL"].ToString();

        public static readonly string SMTPSERVER    = "SMTPSERVER";
        public static readonly string SMTPUSER      = "SMTPUSER";
        public static readonly string SMTPPASSWORD  = "SMTPPASSWORD";
        public static readonly string SMTPPORT      = "SMTPPORT";
        public static readonly string CULTURE       = "CULTURE";

        public static readonly string ENABLECOOKIES_PDF  = "~/Email_Templates/Guide to Enabling Cookies in Your Browser.pdf";
        public static readonly string USER_REGISTRATION_MESSAGE_HTML  =  "~/Email_Templates/UserRegistered.html";

        public static readonly string FORGOTPWD_HTML = "~/Email_Templates/ForgotPassword.html";
        public static readonly string FORGOTPWD_SPONSER_HTML = "~/Email_Templates/ForgotPassword_Sponser.html";

        public static readonly string ENGLISH = "en-CA";
        public static readonly string FRENCH  = "fr-CA";

        public static readonly string ENGLISH_STR = "English";
        public static readonly string FRENCH_STR = "French";

        public static readonly string PatientID = "PatientID";
        public static readonly string PatientNum = "PatientNum";
        public static readonly string IsReadOnly = "IsReadOnly";
         

        public static string GetCurrentLanguage()
        {
            string retVal = string.Empty;

            if (HttpContext.Current.Session[Constants.CULTURE] == null)
                HttpContext.Current.Session[Constants.CULTURE] = Constants.ENGLISH;
            else
                if ( (string)HttpContext.Current.Session[Constants.CULTURE]  == Constants.ENGLISH)
                    retVal = FRENCH_STR;
                else
                    retVal = ENGLISH_STR;
             

            return retVal;
        }
        
    }
}