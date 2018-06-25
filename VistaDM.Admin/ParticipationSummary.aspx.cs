using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Repository;

namespace VistaDM.Admin
{
    public partial class ParticipationSummary : System.Web.UI.Page
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
        }

        private void HideShowPanels()
        {
            this.pnlPCP.Visible = isPCP;
            this.pnlCS.Visible = !isPCP;
            lblNotImplemented.Visible = !isPCP;

            if (isPCP)
            {
                LoadDataPCP();
            }
            else
            {
                LoadDataCS();

            }
        }

        private void LoadDataPCP()
        {
            Domain.ParticipationSummary_PCP summary = invRepos.GetParticipantSummary_PCP(physicianID);

            lbl_MOU_PCP.Text = summary.MOU == Domain.Status.COMPLETED ? "COMPLETED" : "NOT COMPLETED";
            lbl_Payee_PCP.Text = summary.Payee == Domain.Status.COMPLETED ? "COMPLETED" : "NOT COMPLETED";
            lbl_Needs_PCP.Text = summary.NeedsAssesment == Domain.Status.COMPLETED ? "COMPLETED" : "NOT COMPLETED";
            lblNeedsAsses_Renum.Text = summary.NeedsAsses_Remuneration == 1 ? "Remitted" : "NOT COMPLETED";

            lbl_PAF1_PCP.Text = summary.PAF1 == 0 ? "NOT COMPLETED" : summary.PAF1.ToString();
            remun_PAF1.Text = summary.PAF1_Renum == 1 ? "Remitted" : string.Empty;

            //lblPatientSurvey.Text = summary.PatientSurvey == 1 ? "COMPLETED" : "NOT COMPLETED";
            lblPatientSurvey_Renum.Text = summary.PS_Received > 0 ? summary.PS_Received.ToString() : "NOT COMPLETED";
        }

        private void LoadDataCS()
        {

        }

    }
}