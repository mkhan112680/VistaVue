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
    public partial class NewPhysicianPending : System.Web.UI.Page
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


        #endregion

        #region Event Handlers

        protected void imgSubmit_clicked(object sender, System.EventArgs e)
        {
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

                regCode = regRepos.GetNewCode();
                newInvitee.RegistrationCode = regCode.Code;

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