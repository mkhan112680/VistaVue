using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Repository;
using VistaDM.Code;
using VistaDM.Domain;
using System.IO;
using System.Net.Mail;
using VistaDM.Admin.Code;
using System.Configuration;

namespace VistaDM.Admin
{
    public partial class DocInfo : System.Web.UI.Page
    {
        int physicianID = -1;

        InviteeRepository invRepos = new InviteeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ID"] != null)
            {
                physicianID = Int32.Parse(Request["ID"].ToString());
            }

            if (!Page.IsPostBack)
            {
                LoadProvinces();
                LoadData();
            }

            this.lblResult.Text = string.Empty;
            this.trUserName.Visible = UserHelper.GetLoggedInUser(HttpContext.Current.Session).IsAdmin;
            
            //this.btnSave.Visible = !UserHelper.GetLoggedInUser(HttpContext.Current.Session).Roles.Contains(Helper.Constants.VALIENT_ROLE);
            //pnlEmailInvittaion.Visible = !UserHelper.GetLoggedInUser(HttpContext.Current.Session).Roles.Contains(Helper.Constants.VALIENT_ROLE);
        }

        #region Methods

        private void LoadProvinces()
        {
            ProvinceRepository provRepos = new ProvinceRepository();

            this.ddProvince.Items.Add(new ListItem("--", Constants.NOID.ToString()));

            foreach (Province prov in provRepos.GetProvinces())
            {
                this.ddProvince.Items.Add(new ListItem(prov.FullName, prov.ID.ToString()));
            }

            ddProvince.DataBind();

        }

        private void LoadData()
        {
            SponserUser user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);

            Invitee inv = invRepos.GetDetail(physicianID);
            if (inv != null)
            {

                this.txtFirstName.Text = inv.FirstName;
                this.txtLastName.Text = inv.LastName;
                this.txtClinic.Text = inv.PrimaryWorkplace;
                this.txtAddress.Text = inv.Address;
                this.txtCity.Text = inv.City;
                this.txtPostalCode.Text = inv.PostalCode;
                this.txtPhone.Text = inv.Phone;
                this.txtFax.Text = inv.Fax;
                this.txtEmail.Text = inv.OptInEmail;
                this.txtComments.Text = inv.Comments;
                this.txtUnique.Text = inv.RegistrationCode;

                lblFN.Text = inv.YourFirstName;
                lblLN.Text = inv.YourLastName;
                lblAdderEmail.Text = inv.YourEmail;

                if (inv.BITerritoryID.HasValue)
                    this.txtBI.Text = inv.BITerritoryID.Value.ToString();

                this.txtLilly.Text = inv.LillyID;
                lblType.Text = inv.PhysicianType == Enums.PhysicianType.PCP ? "PCP" : "CS";
                this.lblUserName.Text = inv.UserName;

                //squaredThree.Checked = inv.OptInEmail;

                if (inv.Province.ID.HasValue)
                {
                    ddProvince.SelectedValue = inv.Province.ID.Value.ToString();
                }
                else
                {
                    ddProvince.SelectedValue = Constants.NOID.ToString();
                }

                if (!user.IsAdmin)
                {
                    if (inv.PhysicianType == Enums.PhysicianType.PCP)
                    {
                        pnlEmail.Visible = inv.Invited;
                    }
                    else
                    {
                        pnlEmail.Visible = false;
                    }
                }
                
            }

        }

        public byte[] GetPdf()
        {

            //  List<Invitee> lstInvitee = new List<Invitee>();
            //   InviteeRepository invRepos = new InviteeRepository();
            List<Invitee> invList = new List<Invitee>();
            List<int> lstIDInt = new List<int>();

            const string PATH = "~/PDF/";

            GenPdf genpdf = new GenPdf(Server.MapPath(PATH));

            string formname = chkFrench.Checked ? "VISTA DM_Invitation_PCP_FR.pdf" : "VISTA DM_Invitation_PCP.pdf";

            //string formname = "vista invite template.pdf";

            //foreach (string id in Request.QueryString["physlst"].Split(",".ToCharArray()).ToList())
            //{
            //    lstIDInt.Add(Int32.Parse(physicianID));
            //}

            lstIDInt.Add(physicianID);

            invList = invRepos.GetInviteeData(lstIDInt);

            genpdf.Create();

            foreach (Invitee inv in invList)  //loop by physician
            {   //f1

                genpdf.AddForm(formname);
                //string nameA = doc.LastName + ", ";

                string fullName = string.Empty;


                fullName = inv.FirstName + " " + inv.LastName;


                genpdf.AddField("Unique ID", inv.RegistrationCode, 0);
                genpdf.AddField("LName", inv.LastName, 0);

                //genpdf.AddField("UNIQUEID", inv.RegistrationCode, 0);
                //genpdf.AddField("Salutation FNAME LNAME", fullName, 0);
                //genpdf.AddField("Salutation FNAME LNAME", fullName, 0);

                // genpdf.Save();
                genpdf.FinalizeForm(true);
            }

            return genpdf.Close();

        }

        private string GetEmailBody(string lastName)
        {
            string html = string.Empty;


            html = @" <style>
                        .redLabel
                        {
                            color: Red;
                        }
                        .bolded
                        {
                            font-weight: bold;
                        }
                        .unbolded
                        {
                            font-weight: normal;
                        }
                        .emailBodyWrapper
                        {
                            padding: 5px;
                            font-family: Candara;
                             font-size:14px;
                        }
                     li
                            {
                              padding-top:28px;   
                            }
                    </style>
                    <div class='emailBodyWrapper'>
                         <p>
                            Dear Dr. {LastName},
                        </p>
                        <p>
                            On behalf of the Canadian Heart Research Centre (CHRC: <a href='http://www.chrc.net' >www.chrc.net</a> ), we are pleased to invite you to participate in the Vista DM.
                        </p>
                        <p>
                            Please see the appended document with registration instructions and the program details.
                             </p>
                        <p>
                            Should you have any questions, please do not hesitate to contact the CHRC at 416-977-8010 ext. 296 
                        </p>
                        <p>
                           Thank you for taking the time to review this invitation and we hope to have the opportunity to collaborate with you. 
                        </p>
                        <p>
                            Best Regards,
                        </p>
                        <p>
                            The CHRC
                        </p>
                    </div>";



            html = html.Replace("{LastName}", lastName);

            return html;

        }

        protected bool SendEmail(string frmEmail, string toEmail, string lastName, Attachment attachment, string body, bool isFrench)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();

                //mailMessage.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings[Constants.EMAILGENERAL]);
                mailMessage.From = new System.Net.Mail.MailAddress(frmEmail);
                mailMessage.To.Add(new System.Net.Mail.MailAddress(toEmail));
                mailMessage.Subject = isFrench ? "Invitation à participer Programme DM Vista" : "Invitation to participate Vista DM Program";

                mailMessage.IsBodyHtml = false;
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(GetRegistrationEmailBody(string.Empty, string.Empty, string.Empty, string.Empty), null, "text/html");
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body , null, "text/html");

                mailMessage.Body = body;

                mailMessage.Attachments.Add(attachment);

                //mailMessage.AlternateViews.Add(htmlView);

                Utility.SendMail(mailMessage);

                return true;


            }

            catch (Exception e)
            {
                Response.Write("Failed to send invitation via email in PhysicianInfo.aspx " + e.Message.ToString());

                return false;
            }
        }

        #endregion

        #region Event Handlers

        protected void btnSubmit_clicked(object sender, ImageClickEventArgs e)
        {
            bool errored = false;

            Invitee newInvitee = new Invitee();

            try
            {
                newInvitee.PhysicianID = physicianID;
                newInvitee.FirstName = txtFirstName.Text;
                newInvitee.LastName = txtLastName.Text;
                newInvitee.PrimaryWorkplace = txtClinic.Text;
                newInvitee.Address = txtAddress.Text;
                newInvitee.City = txtCity.Text;
                newInvitee.ProvinceID = Int32.Parse(ddProvince.SelectedValue.ToString());
                newInvitee.PostalCode = txtPostalCode.Text;
                newInvitee.Phone = txtPhone.Text;
                newInvitee.Fax = txtFax.Text;
                newInvitee.OptInEmail = txtEmail.Text;
                newInvitee.Comments = txtComments.Text;

                if (!string.IsNullOrEmpty(txtBI.Text))
                    newInvitee.BITerritoryID = Int32.Parse(this.txtBI.Text);

                newInvitee.LillyID = this.txtLilly.Text;


                invRepos.UpdateInvitee(newInvitee);
            }
            catch (Exception exc)
            {
                errored = true;
            }

            if (!errored)
                ScriptManager.RegisterStartupScript(this, GetType(), "", "window.alert('Physician Record updated successfully'); parent.location.reload(true); parent.jQuery.fancybox.close();", true);
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "", "window.alert('Physician Record CANNOT be updated, please try again later'); parent.location.reload(true); parent.jQuery.fancybox.close();", true);
        }

        protected void lbtnSendEmail_clicked(object sender, EventArgs e)
        {
            try
            {
                //if (
                //        string.IsNullOrEmpty(this.txtEmailFrom_Send.Text) ||
                //        string.IsNullOrEmpty(this.txtEmailTo_Send.Text)
                //    )
                //    return;

                if (
                        string.IsNullOrEmpty(this.txtEmailTo_Send.Text)
                    )
                {
                    this.lblResult.Text = "Please enter email";
                    return;

                }

                if ( 
                        !this.chkEnglish.Checked &&
                        !this.chkFrench.Checked 
                    )
                {
                    this.lblResult.Text = "Please select english or french";
                    return;
                }
                
                
                //string frmEmail = this.txtEmailFrom_Send.Text;
                string toEmail = this.txtEmailTo_Send.Text;
                string lastName = string.Empty;
                byte[] dataArray = GetPdf();

                MemoryStream s = new MemoryStream(dataArray);
                s.Seek(0, SeekOrigin.Begin);

                Attachment a = new Attachment(s,  "VISTA_DM_Invitation_PCP.pdf" );

                if (ViewState[Constants.LASTNAME] != null)
                    lastName = ViewState[Constants.LASTNAME].ToString();

                SendEmail(Constants.EMAILGENERAL, toEmail, lastName, a, txtEmailMssg_Send.Text, this.chkFrench.Checked);

                invRepos.UpdateInviteDate(physicianID, true, this.chkFrench.Checked, true);

               // ScriptManager.RegisterStartupScript(this, GetType(), "", "window.alert('Physician invitation sent'); parent.location.reload(true); parent.jQuery.fancybox.close();", true);

                lblResult.Text = "Invitation/s successfully sent";

            }
            catch (Exception exception)
            {

                lblResult.Text = "Following Error occurred " + Environment.NewLine + exception.ToString();
            }
        }

      

        #endregion
    }
}