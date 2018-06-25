using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Repository;
using VistaDM.Domain;
using VistaDM.Code;
using VistaDM.Admin.Code;
using System.Web.Security;
using System.Security.Principal;
using System.Net.Mail;

namespace VistaDM.Admin
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCompany();
                LoadRole();
            }

            HideControls();
        }

        #region Methods

        private void HideControls()
        {
            lblProReq.Visible = false;
        }

        private void LoadCompany()
        {
            CompanyRepository cmpRepo = new CompanyRepository();

            this.ddCompany.Items.Add(new ListItem("--", Constants.NOID.ToString()));

            foreach (Company comp in cmpRepo.GetCompanies())
            {
                this.ddCompany.Items.Add(new ListItem(comp.Name, comp.ID.ToString()));
            }

            ddCompany.DataBind();

        }

        private void LoadRole()
        {

            RoleRepository roleRepo = new RoleRepository();

            this.ddRole.Items.Add(new ListItem("--", Constants.NOID.ToString()));

            foreach (Role role in roleRepo.GetRoles())
            {
                this.ddRole.Items.Add(new ListItem(role.Name, role.ID.ToString()));
            }

            ddRole.DataBind();
        }

        private static void SendHTMLEmail(string toEmail , string name , string email, string pwd)
        {

            MailMessage mailMessage = new MailMessage();

            string PathToAttachment = HttpContext.Current.Server.MapPath("~/Guide to Enabling Cookies in Your Browser.pdf");

            mailMessage.From = new MailAddress(Constants.EMAILGENERAL);

            mailMessage.To.Add(new MailAddress(toEmail));

            mailMessage.Attachments.Add(new Attachment(PathToAttachment));

            mailMessage.Subject = "VISTA DM Alliance Portal – Registration ";

            mailMessage.IsBodyHtml = true;

            //var myFile = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email_Template.htm"));
            var myFile = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate2.html"));

            string myString = myFile.ReadToEnd();

            //myString = myString.Replace("{FirstName}", name);
            //myString = myString.Replace("{EMAIL}", email);
            //myString = myString.Replace("{PASSWORD}", pwd);

            myString = myString.Replace("First Name", name);
            myString = myString.Replace("USERNAME ", toEmail);
            myString = myString.Replace("PASSWORD", pwd);


            mailMessage.Body = myString;

            Utility.SendMail(mailMessage);

            #region Commented Out

            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(myString, null, "text/html");

            //LinkedResource imagelink = new LinkedResource(HttpContext.Current.Server.MapPath("~/images/regEmailImage.jpg"), "image/jpg");

            //imagelink.ContentId = "imageId";

            //imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

            //htmlView.LinkedResources.Add(imagelink);

            //mailMessage.AlternateViews.Add(htmlView);

            #endregion 
        }

        #endregion

        #region Events 

        protected void customVal_OnServerValidate(object source, ServerValidateEventArgs args)
        {

            bool isValid = true;

            if (
                    !chkAll.Checked &&
                    !chkMB.Checked &&
                    !chkNB.Checked &&
                    !chkBC.Checked &&
                    !chkON.Checked &&
                    !chkNL.Checked &&
                    !chkAB.Checked &&
                    !chkQC.Checked &&
                    !chkPEI.Checked &&
                    !chkSK.Checked &&
                    !chkNS.Checked
                )
            {
                isValid = false;
                lblProReq.Visible = true;
            }

            args.IsValid = isValid;
        }

        protected void imgSubmit_clicked(object sender, System.EventArgs e)
        {


            if (!Page.IsValid)
                return;

            if ( !this.txtUsername.Text.Contains("@"))
            {

                lblResult.Text = "Please eneter valid email";
                return;
            }

            bool success = false;
            SponserUser usr = null;

            SponserRepository sponRepos = new SponserRepository();

            try
            {
                SponserUser newUser = new SponserUser();

                newUser.Username = this.txtUsername.Text;
                newUser.Password =  Encryptor.Encrypt( this.txtPass.Text );
                newUser.FirstName = this.txtFirst.Text;
                newUser.LastName = this.txtLastname.Text;
                newUser.Company = new Company() { ID = Int32.Parse(this.ddCompany.SelectedValue) };
                newUser.Role = new Role() { ID = Int32.Parse(this.ddRole.SelectedValue) };
                newUser.TerritoryCovergae_All = chkAll.Checked;

                if (newUser.TerritoryCovergae_All.Value)
                {
                    newUser.TerritoryCovergae_BC = true;
                    newUser.TerritoryCovergae_AB = true;
                    newUser.TerritoryCovergae_SK = true;
                    newUser.TerritoryCovergae_MB = true;
                    newUser.TerritoryCovergae_ON = true;
                    newUser.TerritoryCovergae_QC = true;
                    newUser.TerritoryCovergae_NS = true;
                    newUser.TerritoryCovergae_NB = true;
                    newUser.TerritoryCovergae_NL = true;
                    newUser.TerritoryCovergae_PEI = true;
                }
                else
                {
                    newUser.TerritoryCovergae_BC = chkBC.Checked;
                    newUser.TerritoryCovergae_AB = chkAB.Checked;
                    newUser.TerritoryCovergae_SK = chkSK.Checked;
                    newUser.TerritoryCovergae_MB = chkMB.Checked;
                    newUser.TerritoryCovergae_ON = chkON.Checked;
                    newUser.TerritoryCovergae_QC = chkQC.Checked;
                    newUser.TerritoryCovergae_NS = chkNS.Checked;
                    newUser.TerritoryCovergae_NB = chkNB.Checked;
                    newUser.TerritoryCovergae_NL = chkNL.Checked;
                    newUser.TerritoryCovergae_PEI = chkPEI.Checked;
                }

                sponRepos.Register(newUser);

                if (sponRepos.Authenticate(newUser.Username, newUser.Password))
                {

                    //SendHTMLEmail(newUser.Username);

                    SendHTMLEmail(newUser.Username , newUser.FirstName, newUser.Username, Encryptor.Decrypt(newUser.Password));
                    
                    //SendHTMLEmail("khanm@chrc.net", newUser.FirstName, newUser.Username , Encryptor.Decrypt(newUser.Password) );
                    
                    usr = UserHelper.SetupUserOnLogin(newUser.Username, newUser.Password);

                    HttpContext.Current.User = new GenericPrincipal(User.Identity, null);

                    FormsAuthentication.SetAuthCookie(newUser.Username, false);

                    success = true;

                    //FormsAuthentication.RedirectFromLoginPage(newUser.Username, true);
                }

                lblResult.Text = "Registered Successfully";
            }
            catch (Exception exc)
            {
                success = false;

                lblResult.Text = "Could not register : " + exc.InnerException.Message;
            }

            if (success)

                Response.Redirect(UserHelper.GetURLByRole(usr));
        }

        #endregion 
    }
}