using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Repository;
using VistaDM.Domain;
using VistaDM.Code;

namespace VistaDM.Admin
{
    public partial class NewPhysician : System.Web.UI.Page
    {
        InviteeRepository invRepos = new InviteeRepository();
        int physicianID = -1; 
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request["ID"] != null)
            //{
            //    physicianID = Int32.Parse(Request["ID"].ToString());
            //}

            if (!Page.IsPostBack)
            {
                LoadProvinces();
            }

            HideControls();
        }

        #region Methods

        private void HideControls()
        {

            lblTypeReq.Visible = false;

        }

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
 

        #endregion

        #region Event Handlers

        protected void imgSubmit_clicked(object sender, System.EventArgs e)
        {

            if (string.IsNullOrEmpty(this.rdoType.SelectedValue))
            {
                lblTypeReq.Visible = true;
                return;
            }
            
            bool errored = false;
            RegCode regCode = new RegCode();
            RegCodeRepository regRepos = new RegCodeRepository();
            Invitee newInvitee = new Invitee();

            try
            {
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
                
                newInvitee.YourFirstName = txtYourFirstName.Text;
                newInvitee.YourLastName  = txtYourLastName.Text;
                newInvitee.YourEmail     = txtYourEmail.Text;

                if (!string.IsNullOrEmpty(txtBI.Text))
                    newInvitee.BITerritoryID = Int32.Parse(this.txtBI.Text);
                
                newInvitee.LillyID = this.txtLilly.Text;

                
                if( this.rdoType.SelectedValue == "1" )
                    newInvitee.PhysicianType =  Enums.PhysicianType.PCP;
                else
                    if( this.rdoType.SelectedValue == "2" )
                        newInvitee.PhysicianType =  Enums.PhysicianType.CS;

                regCode = regRepos.GetNewCode();
                newInvitee.RegistrationCode = regCode.Code;
                
                SponserUser user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);

                newInvitee.IsAdminApproved = user.IsAdmin;

                invRepos.AddInvitee(newInvitee);
                
                regRepos.UpdateRegCode(regCode.ID);
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

        #endregion 
    }
}