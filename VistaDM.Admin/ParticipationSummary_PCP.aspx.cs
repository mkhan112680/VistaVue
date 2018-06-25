using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Domain;
using VistaDM.Repository;

namespace VistaDM.Admin
{
    public partial class ParticipationSummary_PCP : System.Web.UI.Page
    {

        int physicianID = -1;
        bool isPCP = false;
        InviteeRepository invRepos = new InviteeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["PhysicianID"] != null)
            {
                physicianID = Int32.Parse(Request["PhysicianID"].ToString());
            }

            if (Request["PhysicianType"] != null)
            {
                isPCP = Request["PhysicianType"].ToString().ToLower() == "pcp".ToLower();
            }

            HideShowPanels();

            if (isPCP && !Page.IsPostBack)
            {
                LoadData_PCP();
            }

            ClearLabels();
        }

        #region Methods

        private void ClearLabels()
        {
            lbl_PS_Result.Text = string.Empty;
        }

        private void LoadData_PCP()
        {
            Load_ActionItems_PCP();

            LoadPS_PCP();
        }

        private void LoadPS_PCP()
        {
            Remuneration_PS ps = invRepos.Get_PS(physicianID);
            if (ps.Received != null)
            {
                this.chkGiftCard.Checked = ps.GiftCard;
                txt_PS_Date.Text = ps.Date.ToString("dd/MM/yyyy");
                txt_PS_Receievd.Text = ps.Received;
            }
        }

        private void Load_ActionItems_PCP()
        {
            Domain.ParticipationSummary_PCP summary = invRepos.GetParticipantSummary_PCP(physicianID);

            lbl_MOU_PCP.Text = summary.MOU == Domain.Status.COMPLETED ? "COMPLETED" : "NOT COMPLETED";
            lbl_Payee_PCP.Text = summary.Payee == Domain.Status.COMPLETED ? "COMPLETED" : "NOT COMPLETED";
            lbl_Needs_PCP.Text = summary.NeedsAssesment == Domain.Status.COMPLETED ? "COMPLETED" : "NOT COMPLETED";
            remun_Asses.Status = summary.NeedsAsses_Remuneration == 1 ? "Remitted" : string.Empty;

            lbl_PAF1_PCP.Text = summary.PAF1 == 0 ? "NOT COMPLETED" : summary.PAF1.ToString();
            remun_PAF1.Status = summary.PAF1_Renum == 1 ? "Remitted" : string.Empty;

            lblPatientSurvey.Text = summary.PatientSurvey == 1 ? "COMPLETED" : "NOT COMPLETED";
        }

        private void HideShowPanels()
        {
            this.pnlPCP.Visible = isPCP;
            this.pnlCS.Visible = !isPCP;

        }

        private void Clear_PS_Fields()
        {
            txt_PS_Date.Text = string.Empty;
            this.chkGiftCard.Checked = false;
            txt_PS_Receievd.Text = string.Empty;
        }

        #endregion

        #region Event Handlers

        protected void imgPS_clicked(object sender, System.EventArgs e)
        {
            string[] formats = { "dd/MM/yyyy" };
            DateTime dummy;
            if (
                  !DateTime.TryParseExact(

                                       txt_PS_Date.Text,
                                       formats,
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out dummy
                                   )
                )
            {
                this.lbl_PS_Result.Text = "Invalid Date Format";
                return;
            }

            DateTime date = DateTime.ParseExact(txt_PS_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            bool checkGC = this.chkGiftCard.Checked;
            string received = txt_PS_Receievd.Text;

            Remuneration_PS newRen = new Remuneration_PS()
            {
                InviteeID = physicianID,
                Date = date,
                GiftCard = checkGC,
                Received = received
            };

            //save data//
            invRepos.Set_PS(newRen);

            //Clear_PS_Fields();

        }

        #endregion
    }
}