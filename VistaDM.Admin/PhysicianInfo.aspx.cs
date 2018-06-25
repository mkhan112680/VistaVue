using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Repository;
using VistaDM.Admin.Code;
using VistaDM.Domain;
using VistaDM.Code;

namespace VistaDM.Admin
{
    public partial class PhysicianInfo : System.Web.UI.Page
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

                //squaredThree.Checked = inv.OptInEmail;

                if (inv.Province.ID.HasValue)
                {
                    ddProvince.SelectedValue = inv.Province.ID.Value.ToString();
                }
                else
                {
                    ddProvince.SelectedValue = Constants.NOID.ToString();
                }
            }

        }


        #endregion

        #region Event Handlers


        protected void btnSubmit_clicked(object sender, ImageClickEventArgs e)
        {

        }

        
        //protected void btnUpdatePhysician_Click(object sender, System.EventArgs e)
        //{
        //    bool errored = false;

        //    Invitee updatedInv = new Invitee();

        //    updatedInv.InvitationTier = this.txtInvRank.Text;
        //    updatedInv.FirstName = txtFirstName.Text;
        //    updatedInv.LastName = txtLastName.Text;
        //    updatedInv.Address = this.txtAddress.Text;
        //    updatedInv.Clinic = this.txtClinic.Text;
        //    updatedInv.City = this.txtCity.Text;
        //    updatedInv.Province = new Province()
        //    {
        //        ID = Int32.Parse(this.ddProvince.SelectedValue)
        //    };

        //    updatedInv.PostalCode = this.txtPostal.Text;
        //    updatedInv.Phone = this.txtTelephone.Text;
        //    // updatedInv.CellPhone = this.txtCellPhone.Text;
        //    updatedInv.Fax = this.txtFax.Text;
        //    updatedInv.Email = this.txtEmail.Text;
        //    updatedInv.ID = this.physicianID;
        //    updatedInv.Comments = this.txtComments.Text;

        //    try
        //    {
        //        invRepos.UpdateInvitee(updatedInv);

        //    }
        //    catch (Exception exc)
        //    {

        //        lblMsg.Text = exc.InnerException.Message;

        //        errored = true;

        //        //throw;
        //    }

        //    if (!errored)
        //        ScriptManager.RegisterStartupScript(this, GetType(), "", "window.alert('Physician Record updated successfully'); parent.location.reload(true); parent.jQuery.fancybox.close();", true);
        //    //else
        //    //    ScriptManager.RegisterStartupScript(this, GetType(), "", "window.alert('Physician Record CANNOT be updated, please try again later'); parent.location.reload(true); parent.jQuery.fancybox.close();", true);

        //}

        //protected void btnInvite_clicked(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(this.txtEmailInvitation.Text))
        //            return;

        //        string email = this.txtEmailInvitation.Text;
        //        string lastName = string.Empty;
        //        byte[] dataArray = GetPdf();

        //        MemoryStream s = new MemoryStream(dataArray);
        //        s.Seek(0, SeekOrigin.Begin);
        //        Attachment a = new Attachment(s, "Invitation.pdf");

        //        if (ViewState[Constants.LASTNAME] != null)
        //            lastName = ViewState[Constants.LASTNAME].ToString();

        //        SendEmail(email, lastName, a);

        //        invRepos.UpdateInviteDate(physicianID, true, this.chkFrench.Checked, true);

        //        ScriptManager.RegisterStartupScript(this, GetType(), "", "window.alert('Physician invitation sent'); parent.location.reload(true); parent.jQuery.fancybox.close();", true);

        //        lblInvResult.Text = "Invitation/s successfully sent";

        //    }
        //    catch (Exception exception)
        //    {

        //        lblInvResult.Text = "Following Error occurred " + Environment.NewLine + exception.ToString();
        //    }

        //}

        #endregion
    }
}