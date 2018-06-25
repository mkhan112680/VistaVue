using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;


namespace VistaDM.Web.Helpers
{
    public class Emailer
    {
        public static void SendHTMLEmail(
                                           string toEmail,
                                           string firstName,
                                           string lastName ,
                                           string pwd,
                                           string attachmentFilePath,
                                           string templatePath
                                       )
        {

            MailMessage mailMessage = new MailMessage();

            if (!string.IsNullOrEmpty(attachmentFilePath))
            {
                mailMessage.Attachments.Add(new Attachment(HttpContext.Current.Server.MapPath(attachmentFilePath)));
            }

            mailMessage.From = new MailAddress(Constants.EMAILGENERAL);

            mailMessage.To.Add(new MailAddress(toEmail));

            mailMessage.Subject = "VISTA DM Portal – " + Resources.Resource.REGISTRATION;

            mailMessage.IsBodyHtml = true;

            //var myFile = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email_Template.htm"));
            var myFile = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath(templatePath));

            string myString = myFile.ReadToEnd();

            //myString = myString.Replace("{FirstName}", name);
            //myString = myString.Replace("{EMAIL}", email);
            //myString = myString.Replace("{PASSWORD}", pwd);

            myString = myString.Replace("LName", lastName);
            myString = myString.Replace("USERNAME ", toEmail);
            myString = myString.Replace("PASSWORD", pwd);
            

            mailMessage.Body = myString;

            SendMail(mailMessage);

            #region Commented Out

            #endregion
        }


        public static void SendPasswordEmail(
                                                  string userName,
                                                  string pwd ,
                                                  string templatePath
                                      )
        {

            MailMessage mailMessage = new MailMessage();

            
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

            #region Commented Out

            #endregion
        }

        private static void SendMail(System.Net.Mail.MailMessage Message)
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
                catch (Exception exec)
                {
                    string error = exec.ToString();

                }
            }

        }
    }
}