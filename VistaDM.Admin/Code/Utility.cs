using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Net.Mail;
using System.Configuration;
using System.Text;

using VistaDM.Code;

namespace VistaDM.Admin.Code
{
    public class Utility
    {

        public static void SendMail(System.Net.Mail.MailMessage Message)
        {
            using (SmtpClient client = new SmtpClient())
            {
                try
                {

                    client.Host = ConfigurationManager.AppSettings[Constants.SMTPSERVER];

                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    
                    NetworkCred.UserName = ConfigurationManager.AppSettings[Constants.SMTPUSER];
                    NetworkCred.Password = ConfigurationManager.AppSettings[Constants.SMTPPASSWORD];
                    client.UseDefaultCredentials = false;
                    client.Credentials = NetworkCred;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    // client.Port = 25;
                    client.Port = Convert.ToInt32(ConfigurationManager.AppSettings[Constants.SMTPPORT]);
                    
                    client.Timeout = 20000;
                    client.Send(Message);

                }
                catch (Exception exec )
                {
                    string error = exec.ToString();
                    //client = null;
                    //Utility.WriteToLog("SendMail Error: " + Error);
                }
            }

        }



        public static void SendPasswordEmail(string userName, string pwd, string templatePath)
        {

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();


            mailMessage.From = new MailAddress(Constants.EMAILGENERAL);

            mailMessage.To.Add(new MailAddress(userName));

            mailMessage.Subject = "VISTA DM Password Reminder";

            mailMessage.IsBodyHtml = true;

            //mailMessage.Body = string.Format("Dear {0}, Your password for Vista DM Portal is {1}" , userName,pwd );

            var myFile = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath(templatePath));

            string myString = myFile.ReadToEnd();

            myString = myString.Replace("USERNAME ", userName);
            myString = myString.Replace("PASSWORD", pwd);

            mailMessage.Body = myString;

            SendMail(mailMessage);


        }


        public static string GetHTMLSalutation(string salutation)
        {
            string retStr = string.Empty;
            if (!string.IsNullOrEmpty(salutation))
            {
                if (salutation.Contains(Constants.SALUTATION_STR))
                    retStr = salutation.Replace(Constants.SALUTATION_STR, "<sup>(e).</sup>");
                else
                    retStr = salutation;
            }
            return retStr;
        }

        public static string GetStrippedSalutation(string salutation)
        {
            string retStr = string.Empty;
            if (!string.IsNullOrEmpty(salutation))
            {
                if (salutation.Contains(Constants.SALUTATION_STR))
                    retStr = salutation.Replace(Constants.SALUTATION_STR, string.Empty);
                else
                    retStr = salutation;
            }
            return retStr;
        }

        public static bool HasDigits(string str)
        {

            bool retVal = false;

            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    retVal = true;
                    break;
                }
            }

            return retVal;
        }

        public static void SetFocus(Page page, Control control)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\r\n<script language='JavaScript'>\r\n");
            sb.Append("<!--\r\n");
            sb.Append("function SetFocus()\r\n");
            sb.Append("{\r\n");
            sb.Append("\tdocument.");

            Control p = control.Parent;
            while (!(p is System.Web.UI.HtmlControls.HtmlForm)) p = p.Parent;

            sb.Append(p.ClientID);
            sb.Append("['");
            sb.Append(control.UniqueID);
            sb.Append("'].focus();\r\n");
            sb.Append("}\r\n");
            sb.Append("window.onload = SetFocus;\r\n");
            sb.Append("// -->\r\n");
            sb.Append("</script>");


            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), "SETFOCUS", sb.ToString(), true);
        }

        //        public static string FocusControlOnPageLoad(string ClientID, System.Web.UI.Page page)
        //        {


        ////            string script = @"function ScrollView()
        ////                                      {
        ////                                         var el = document.getElementById('" + ClientID + @"')
        ////                                         if (el != null)
        ////                                         {        
        ////                                            el.scrollIntoView();
        ////                                            el.focus();
        ////                                         }
        ////                                      }
        ////
        ////                                      window.onload = ScrollView;";

        //            string script = @"function ScrollView()
        //                                      {
        //                                        alert('hi');
        //                                      }
        //
        //                                      window.onload = ScrollView;";


        //            return script;


        //        }



        public static void FocusControlOnPageLoad(string ClientID,
                                            System.Web.UI.Page page)
        {

            //            string script = @"function ScrollView()
            //
            //                                      {
            //                                         var el = document.getElementById('" + ClientID + @"')
            //                                         if (el != null)
            //                                         {        
            //                                            el.scrollIntoView();
            //                                            el.focus();
            //                                         }
            //                                      }
            //
            //                                       ScrollView()  ;";

            string script = string.Format("cntrlToFocus = '{0}'", ClientID);

            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), "ClearControlScript", script, true);
        }

    }
}