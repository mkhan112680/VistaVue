using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;


using VistaDM.Admin.Code;
using VistaDM.Code;
using VistaDM.Repository;
using VistaDM.Domain;

using System.Web.Services;
using System.Net.Mail;

namespace VistaDM.Admin
{
    public partial class UnApprovedUsers : System.Web.UI.Page
    {
        InviteeRepository invRepos = new InviteeRepository();

        List<RegistrationStatus> regList = null;
        SponserUser user = null;
        int provinceID = -1;
        bool? isPCP = null;

        #region Methods

        private void LoadRegistrationStatus()
        {
            regList = invRepos.GetRegistartionStatus();

        }

        private void AdjustColumns()
        {

            //Domain.User user = base.GetLoggedInUser() as Domain.User;

            //if (user.Roles.Contains(Helper.Constants.ADMIN_ROLE))
            //    this.gvCardiologists.Columns["colInvitedByCHRC"].Visible = true;

        }

        private void LoadData(bool? isPCP)
        {

            this.gvCardiologists.DataSource = invRepos.GetAllInviteesPending(isPCP);
            this.gvCardiologists.DataBind();
        }

        private void LoadData(int provID, bool? isPCP)
        {
            this.gvCardiologists.DataSource = invRepos.GetAllInviteesByProvincePending(provID, isPCP);
            this.gvCardiologists.DataBind();
        }

        protected void showscript(string link)
        {
            ScriptManager.RegisterStartupScript(UPCardiologists, typeof(Page), "newRF", link, true);
        }

        //private bool UpdatePhysicanRegistration(string physicianID, bool checkvalue)
        //{
        //    string Sql = string.Empty;
        //    if (checkvalue)
        //    {

        //        Sql = "update tblCardiologists set Registered=1 where UniqueID='" + physicianID + "'";
        //    }
        //    else
        //    {
        //        Sql = "update tblCardiologists set Registered=0 where UniqueID='" + physicianID + "'";
        //    }
        //    //return DBHandler.ExecuteQuery(Sql);
        //    return true;

        //}

        private void UpdateInvitationSentDate(int physicianID, bool isFrench, bool chrc)
        {
            invRepos.UpdateInviteDate(physicianID, true, isFrench, chrc);
        }

        private void LoadControlsForSponser()
        {

        }

        #endregion

        #region Events

        protected void Page_Init(object sender, EventArgs e)
        {



        }

        protected override void OnInitComplete(EventArgs e)
        {

            // have to put in Page_Init, Page_Load doesn't work, it interferes with InvitedCheckbox_CheckedChanged and possibly other postback functions 
            if (Request.QueryString[Constants.PROVINCEID] != null)
                provinceID = Int32.Parse(Request.QueryString[Constants.PROVINCEID].ToString());

            if (Request.QueryString[Constants.IS_PCP] != null && Request.QueryString[Constants.IS_PCP].ToString() != "-1")
                isPCP = Request.QueryString[Constants.IS_PCP].ToString() == "1";


            user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);

            LoadRegistrationStatus();

            if (provinceID == -1)
                LoadData(isPCP);
            else
                LoadData(provinceID, isPCP);


            //if (!UserHelper.CanSelectProgram(user))
            //{
            //    hlChangeProgram.Enabled = false;
            //    hlChangeProgram.ImageUrl = "~/images/button_changeprogram_gray.png";
            //}

            //if (!user.HasMoreThanOneProvince())
            //{
            //    hlChangeRegion.Enabled = false;
            //    hlChangeRegion.ImageUrl = "~/images/button_changeregion_gray.png";
            //}


            //LoadControlsForSponser();
            base.OnInitComplete(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
        }

        protected void gvCardiologists_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void gvCardiologists_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {


            Label lblStatus = gvCardiologists.FindRowCellTemplateControl(e.VisibleIndex, null, "lblStatus") as Label;

            if (lblStatus != null && !string.IsNullOrEmpty(lblStatus.Text))
            {
                ASPxComboBox cmboBox = gvCardiologists.FindRowCellTemplateControl(e.VisibleIndex, null, "cmbRegStatus") as ASPxComboBox;

                //DropDownList dd = gvCardiologists.FindRowCellTemplateControl(e.VisibleIndex, null, "dd") as DropDownList;

                foreach (ListEditItem item in cmboBox.Items)
                {
                    if (item.Value.ToString() == lblStatus.Text)
                    {
                        item.Selected = true;

                        break;
                    }
                }



                //foreach (ListItem item in dd.Items)
                //{
                //    if (item.Value.ToString() == lblStatus.Text)
                //    {
                //        item.Selected = true;

                //        break;
                //    }
                //}
                //dd.DataBind();

            }
        }

        protected void gvCardiologists_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {

            if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
            {

                ASPxCheckBox chkc = gvCardiologists.FindRowCellTemplateControl(e.VisibleIndex, null, "chkCHRC") as ASPxCheckBox;

                //if (user.Roles.Contains(Constants.VALIENT_ROLE))
                //{
                //    cmboBox1.ReadOnly = true;
                //    chkc.ReadOnly = true;
                //}
            }

        }


        protected void lbtn_clicked(object sender, EventArgs e)
        {

            //string t = ((sender as LinkButton).Parent.FindControl("lblID") as Label).Text;
        }
        //OnSelectedIndexChanged="cmbRegStatus_SelectedIndexChanged"
        protected void cmbRegStatus_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {


                if (Request.Params["__EVENTTARGET"].ToString().ToLower() != (sender as ASPxComboBox).UniqueID.ToLower())
                    return;



                Label lblStatus = (sender as ASPxComboBox).Parent.FindControl("lblStatus") as Label;

                int physicianID = Int32.Parse(((sender as ASPxComboBox).Parent.FindControl("lblID") as Label).Text);

                int statusID = Int32.Parse((sender as ASPxComboBox).SelectedItem.Value.ToString());


                invRepos.UpdateRegistartionStatus(physicianID, statusID);

                lblStatus.Text = statusID.ToString();

                if (provinceID == -1)
                    LoadData(isPCP);
                else
                    LoadData(provinceID, isPCP);

            }
            catch (Exception exc)
            {

                lblResult.Text = exc.Message;

                throw;
            }

        }

        //[WebMethod(EnableSession = false)]
        //public static  string ToggleInvitedCHRC(int physicianID, bool isChecked)
        //{

        //    bool errored = false;
        //    try
        //    {
        //        InviteeRepository invRepos = new InviteeRepository();
        //        invRepos.UpdateInvitedValue(physicianID, isChecked);
        //    }
        //    catch (Exception exc)
        //    {

        //        errored = true;
        //    }

        //    return errored ? "0" : "1";  
        //}

        //OnCheckedChanged="chkCHRC_OnCheckedChanged"
        protected void chkCHRC_OnCheckedChanged(object sender, EventArgs e)
        {


            try
            {

                if (Request.Params["__EVENTTARGET"].ToString().ToLower() != (sender as ASPxCheckBox).UniqueID.ToLower())
                    return;


                // int physicianID = Int32.Parse((sender as ASPxCheckBox).Attributes["PhysicianID"].ToString());

                int physicianID = Int32.Parse(((sender as ASPxCheckBox).Parent.FindControl("dummyInv2") as Button).CommandName);

                string fn = ((sender as ASPxCheckBox).Parent.FindControl("dummyFN") as Button).CommandName;
                string ln = ((sender as ASPxCheckBox).Parent.FindControl("dummyLN") as Button).CommandName;
                string email = ((sender as ASPxCheckBox).Parent.FindControl("dummyEmail") as Button).CommandName;

                invRepos.Approve(physicianID );

                try
                {

                    Invitee inv = invRepos.GetDetail(physicianID);

                    string phy_fn = inv.FirstName;
                    string phy_ln = inv.LastName;
                    
                    var mailMessage = new System.Net.Mail.MailMessage()
                    {
                        From = new MailAddress( Constants.EMAILGENERAL),
                        Subject = "VISTA DM – New Physician Request Approved",
                        Body = GetBody(fn, string.Empty, phy_fn, phy_ln )  
                                       
                    };

                    mailMessage.To.Add(new MailAddress(email));

                    mailMessage.IsBodyHtml = true;

                    Utility.SendMail(mailMessage);
                }
                catch (Exception)
                {
                    
                    
                }

              

                if (provinceID == -1)
                    LoadData(isPCP);
                else
                    LoadData(provinceID, isPCP);
            }
            catch (Exception exc)
            {

                lblResult.Text = exc.Message;

                throw;
            }
        }

        protected void imgGenMultipleFrench_clicked(object sender, EventArgs e)
        {
            //multiple invite (clicking on the Generate Multiple Invitations button)

            ArrayList prog = new ArrayList();

            //GridViewCommandColumn ShowSelectCheckbox="true" display a checkbox for selection
            // gvCardiologists.GetSelectedFieldValues("UniqueID") get all selected values
            //once you define a commandcolumn you must define KeyFieldName, so that a selection can be uniquely identified by KeyFieldName
            //Getting all selected values in Grid, they are identified by the physicianID as set in KeyFieldName
            List<object> keyValues = gvCardiologists.GetSelectedFieldValues("ID");

            if (keyValues.Count == 0)
            {
                //if 
                // MPENoSelection.Show();
                return;
            }

            string idlst = "";
            foreach (object key in keyValues)
            {
                idlst += key + ",";
            }
            idlst = idlst.Substring(0, idlst.Length - 1);

            foreach (object key in keyValues)
            {

                //UpdateInvitationSentDate(Int32.Parse(key.ToString()), true, user.Roles.Contains(Constants.ADMIN_ROLE));
                UpdateInvitationSentDate(Int32.Parse(key.ToString()), true, true);

            }

            //string link = "window.open('GenerateInvitation.aspx?physlst=" + idlst;
            //link += "');";

            string link = string.Format("window.open('GenerateInvitation.aspx?physlst={0}&{1}={2}');", idlst.ToString(), Constants.ISFRENCH, 1);


            showscript(link);


            gvCardiologists.Selection.UnselectAll();

            if (provinceID == -1)
                LoadData(isPCP);
            else
                LoadData(provinceID, isPCP);

        }

        protected void imgGenMultipleEnglish_Click(object sender, EventArgs e)
        {
            //multiple invite (clicking on the Generate Multiple Invitations button)

            ArrayList prog = new ArrayList();

            //GridViewCommandColumn ShowSelectCheckbox="true" display a checkbox for selection
            // gvCardiologists.GetSelectedFieldValues("UniqueID") get all selected values
            //once you define a commandcolumn you must define KeyFieldName, so that a selection can be uniquely identified by KeyFieldName
            //Getting all selected values in Grid, they are identified by the physicianID as set in KeyFieldName
            List<object> keyValues = gvCardiologists.GetSelectedFieldValues("PhysicianID");

            if (keyValues.Count == 0)
            {
                //if 
                // MPENoSelection.Show();
                return;
            }

            string idlst = "";
            foreach (object key in keyValues)
            {
                idlst += key + ",";
            }
            idlst = idlst.Substring(0, idlst.Length - 1);

            foreach (object key in keyValues)
            {
                //UpdateInvitationSentDate(Int32.Parse(key.ToString()), false, user.Roles.Contains(Constants.ADMIN_ROLE));
                UpdateInvitationSentDate(Int32.Parse(key.ToString()), false, true);

            }

            //string link = "window.open('GenerateInvitation.aspx?physlst=" + idlst;
            //link += "');";

            string link = string.Format("window.open('GenerateInvitation.aspx?physlst={0}&{1}={2}');", idlst.ToString(), Constants.ISFRENCH, 0);


            showscript(link);


            gvCardiologists.Selection.UnselectAll();

            if (provinceID == -1)
                LoadData(isPCP);
            else
                LoadData(provinceID, isPCP);

        }

        protected void imgEnglish_Click(object sender, EventArgs e)
        {
            //single invite
            Button dummy = ((ImageButton)sender).Parent.FindControl("dummyInv") as Button;

            Label lblSentDate = ((ImageButton)sender).Parent.FindControl("lblInvSentDate") as Label;

            int physID = Int32.Parse(dummy.CommandName);

            string link = string.Format("window.open('GenerateInvitation.aspx?physlst={0}&{1}={2}');", physID.ToString(), Constants.ISFRENCH, 0);

            showscript(link);

            //UpdateInvitationSentDate(physID, false, user.Roles.Contains(Constants.ADMIN_ROLE));
            UpdateInvitationSentDate(physID, false, true);

            //  ((Button)sender).CommandName = "";
            gvCardiologists.Selection.UnselectAll();

            if (provinceID == -1)
                LoadData(isPCP);
            else
                LoadData(provinceID, isPCP);

            // MakeInvitationPDF(idlst);
        }

        protected void imgFrench_Click(object sender, EventArgs e)
        {
            //single invite
            Button dummy = ((ImageButton)sender).Parent.FindControl("dummyInv") as Button;

            Label lblSentDate = ((ImageButton)sender).Parent.FindControl("lblInvSentDate") as Label;

            int physID = Int32.Parse(dummy.CommandName);


            string link = string.Format("window.open('GenerateInvitation.aspx?physlst={0}&{1}={2}');", physID.ToString(), Constants.ISFRENCH, 1);

            showscript(link);

            //UpdateInvitationSentDate(physID, true, user.Roles.Contains(Constants.ADMIN_ROLE));
            UpdateInvitationSentDate(physID, true, true);


            gvCardiologists.Selection.UnselectAll();

            if (provinceID == -1)
                LoadData(isPCP);
            else
                LoadData(provinceID, isPCP);


        }

        public string GetBody(string fn, string ln, string phy_FN, string phy_LN )
        {


            string html =  
                            string.Format(
                                             "<p>Dear {0},</p><p>Your new physician request for Dr. {1} {2} has been approved and an invitation has been sent.</p><p>You may also generate the invitation for this physician in the webtool.</p><p>With best regards,</p><p>The CHRC VISTA DM Team</p>",
                                    
                                        fn,
                                        phy_FN,
                                        phy_LN
                                                );

            return html;
        }

        #endregion
    }
}