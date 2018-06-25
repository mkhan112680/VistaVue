using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Code;
using VistaDM.Domain;
using VistaDM.Repository;

namespace VistaDM.Admin
{
    public partial class Reports : System.Web.UI.Page
    {

        SponserUser user;
        int provinceID = -1;
        bool? isPCP = null;
        bool returnToAdmin = false;

        CSV_Helper csvHelper = new CSV_Helper();
        ReportRepository repRepo = new ReportRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

            user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);

            if (Request.QueryString[Constants.PROVINCEID] != null)
                provinceID = Int32.Parse(Request.QueryString[Constants.PROVINCEID].ToString());

            if (Request.QueryString[Constants.IS_PCP] != null && Request.QueryString[Constants.IS_PCP].ToString() != "-1")
                isPCP = Request.QueryString[Constants.IS_PCP].ToString() == "1";

            if (Request.QueryString["ADMIN"] != null)
                returnToAdmin = Int32.Parse(Request.QueryString["ADMIN"].ToString()) == 1;

            if (!Page.IsPostBack)
            {
                LoadSearchModes();

                DisplayPanels();
            }
        }
 
        #region Methods

        private void LoadSearchModes()
        {
            LoadFSA();

            LoadBI();

            LoadLilly();
        }

        private void DisplayPanels()
        {
            if (user.IsAdmin)
            {
                //this.pnlPCP.Visible = true;
                //this.pnlCS.Visible = true;
                //pnlProgram.Visible = false;
                //pnlReports.Visible = true;

                //LoadReport_PCP();
                //LoadReport_CS();
                pnlAdmin.Visible = true;
                this.pnlPCP.Visible = false;
                this.pnlCS.Visible = false;
                pnlProgram.Visible = true;
                pnlReports.Visible = false;
            }
            else
                if (user.Role.ID == 2) //is pcp
                {
                    this.pnlPCP.Visible = true;
                    this.pnlCS.Visible = false;
                    pnlProgram.Visible = false;
                    pnlReports.Visible = true;

                    trPCP.Visible = true;
                    trCS.Visible = false;

                    ViewState["ISPCP"] = "1";

                    pnlAdmin.Visible = false;

                    LoadReport_PCP();
                }
                else if (user.Role.ID == 1) //is cs
                {
                    this.pnlPCP.Visible = false;
                    this.pnlCS.Visible = true;
                    pnlProgram.Visible = false;
                    pnlReports.Visible = true;

                    trPCP.Visible = false;
                    trCS.Visible = true;

                    ViewState["ISPCP"] = "0";

                    pnlAdmin.Visible = false;

                    LoadReport_CS();
                }
                else
                {
                    this.pnlPCP.Visible = false;
                    this.pnlCS.Visible = false;
                    pnlProgram.Visible = true;
                    pnlReports.Visible = false;
                }

        }

        private void LoadFSA()
        {
            //user.TerritoryCovergae_AB
            FSA_Repository fsa_Repos = new FSA_Repository();

            lboxFSA.DataSource = fsa_Repos.GetFSAList(user); ;
            lboxFSA.DataValueField = "Name";
            lboxFSA.DataTextField = "Name";
            lboxFSA.DataBind();
        }

        private void LoadBI()
        {
            BI_Repository bi_Repos = new BI_Repository();

            lboxBI.DataSource = bi_Repos.Get_BI_List(user); ;
            lboxBI.DataValueField = "Name";
            lboxBI.DataTextField = "Name";
            lboxBI.DataBind();
        }

        private void LoadLilly()
        {
            Lilly_Repository lilly_Repos = new Lilly_Repository();

            lboxLilly.DataSource = lilly_Repos.Get_Lilly_List(user); ;
            lboxLilly.DataValueField = "Name";
            lboxLilly.DataTextField = "Name";
            lboxLilly.DataBind();
        }

        private void LoadReport_PCP()
        {
            ProvinceReport report = repRepo.GetCount_PCP();

            this.lbl_AB_Invited.Text = report.AB_Invited.Value.ToString();
            this.lbl_AB_Reg.Text = report.AB_Registered.Value.ToString();
            this.lbl_AB_ePAF.Text = report.AB_ePAF.HasValue ? report.AB_ePAF.Value.ToString() : string.Empty;
            this.lbl_AB_eMAF.Text = report.AB_eMAF.HasValue ? report.AB_eMAF.Value.ToString() : string.Empty;


            this.lbl_BC_Invited.Text = report.BC_Invited.Value.ToString();
            this.lbl_BC_Reg.Text = report.BC_Registered.Value.ToString();
            this.lbl_BC_ePAF.Text = report.BC_ePAF.HasValue ? report.BC_ePAF.Value.ToString() : string.Empty;
            this.lbl_BC_eMAF.Text = report.BC_eMAF.HasValue ? report.BC_eMAF.Value.ToString() : string.Empty;


            this.lbl_SK_Invited.Text = report.SK_Invited.Value.ToString();
            this.lbl_SK_Reg.Text = report.SK_Registered.Value.ToString();
            this.lbl_SK_ePAF.Text = report.SK_ePAF.HasValue ? report.SK_ePAF.Value.ToString() : string.Empty;
            this.lbl_SK_eMAF.Text = report.SK_eMAF.HasValue ? report.SK_eMAF.Value.ToString() : string.Empty;


            this.lbl_MB_Invited.Text = report.MB_Invited.Value.ToString();
            this.lbl_MB_Reg.Text = report.MB_Registered.Value.ToString();
            this.lbl_MB_ePAF.Text = report.MB_ePAF.HasValue ? report.MB_ePAF.Value.ToString() : string.Empty;
            this.lbl_MB_eMAF.Text = report.MB_eMAF.HasValue ? report.MB_eMAF.Value.ToString() : string.Empty;


            this.lbl_ON_Invited.Text = report.ON_Invited.Value.ToString();
            this.lbl_ON_Reg.Text = report.ON_Registered.Value.ToString();
            this.lbl_ON_ePAF.Text = report.ON_ePAF.HasValue ? report.ON_ePAF.Value.ToString() : string.Empty;
            this.lbl_ON_eMAF.Text = report.ON_eMAF.HasValue ? report.ON_eMAF.Value.ToString() : string.Empty;


            this.lbl_QC_Invited.Text = report.QC_Invited.Value.ToString();
            this.lbl_QC_Reg.Text = report.QC_Registered.Value.ToString();
            this.lbl_QC_ePAF.Text = report.QC_ePAF.HasValue ? report.QC_ePAF.Value.ToString() : string.Empty;
            this.lbl_QC_eMAF.Text = report.QC_eMAF.HasValue ? report.QC_eMAF.Value.ToString() : string.Empty;


            this.lbl_NB_Invited.Text = report.NB_Invited.Value.ToString();
            this.lbl_NB_Reg.Text = report.NB_Registered.Value.ToString();
            this.lbl_NB_ePAF.Text = report.NB_ePAF.HasValue ? report.NB_ePAF.Value.ToString() : string.Empty;
            this.lbl_NB_eMAF.Text = report.NB_eMAF.HasValue ? report.NB_eMAF.Value.ToString() : string.Empty;


            this.lbl_NS_Invited.Text = report.NS_Invited.Value.ToString();
            this.lbl_NS_Reg.Text = report.NS_Registered.Value.ToString();
            this.lbl_NS_ePAF.Text = report.NS_ePAF.HasValue ? report.NS_ePAF.Value.ToString() : string.Empty;
            this.lbl_NS_eMAF.Text = report.NS_eMAF.HasValue ? report.NS_eMAF.Value.ToString() : string.Empty;


            this.lbl_NL_Invited.Text = report.NL_Invited.Value.ToString();
            this.lbl_NL_Reg.Text = report.NL_Registered.Value.ToString();
            this.lbl_NL_ePAF.Text = report.NL_ePAF.HasValue ? report.NL_ePAF.Value.ToString() : string.Empty;
            this.lbl_NL_eMAF.Text = report.NL_eMAF.HasValue ? report.NL_eMAF.Value.ToString() : string.Empty;


            this.lbl_PEI_Invited.Text = report.PEI_Invited.Value.ToString();
            this.lbl_PEI_Reg.Text = report.PEI_Registered.Value.ToString();
            this.lbl_PEI_ePAF.Text = report.PEI_ePAF.HasValue ? report.PEI_ePAF.Value.ToString() : string.Empty;
            this.lbl_PEI_eMAF.Text = report.PEI_eMAF.HasValue ? report.PEI_eMAF.Value.ToString() : string.Empty;



            this.lblInvitedTotal.Text =
            (
                report.AB_Invited.Value +
                report.BC_Invited.Value +
                report.SK_Invited.Value +
                report.MB_Invited.Value +
                report.ON_Invited.Value +
                report.QC_Invited.Value +
                report.NB_Invited.Value +
                report.NS_Invited.Value +
                report.NL_Invited.Value +
                report.PEI_Invited.Value

                ).ToString();


            this.lblRegsiteredTotal.Text = (
                                            report.AB_Registered.Value +
                                            report.BC_Registered.Value +
                                            report.SK_Registered.Value +
                                            report.MB_Registered.Value +
                                            report.ON_Registered.Value +
                                            report.QC_Registered.Value +
                                            report.NB_Registered.Value +
                                            report.NS_Registered.Value +
                                            report.NL_Registered.Value +
                                            report.PEI_Registered.Value

                                        ).ToString();


            lblePAF.Text =
                        (
                                report.AB_ePAF.Value +
                                report.BC_ePAF.Value +
                                report.SK_ePAF.Value +
                                report.MB_ePAF.Value +
                                report.ON_ePAF.Value +
                                report.QC_ePAF.Value +
                                report.NB_ePAF.Value +
                                report.NS_ePAF.Value +
                                report.NL_ePAF.Value +
                                report.PEI_ePAF.Value

                                ).ToString();

            this.lbleMAF.Text =

                (
                     report.AB_eMAF.Value +
                     report.BC_eMAF.Value +
                     report.SK_eMAF.Value +
                     report.MB_eMAF.Value +
                     report.ON_eMAF.Value +
                     report.QC_eMAF.Value +
                     report.NB_eMAF.Value +
                     report.NS_eMAF.Value +
                     report.NL_eMAF.Value +
                     report.PEI_eMAF.Value

                     ).ToString();

        }

        private void LoadReport_CS()
        {
            ProvinceReport report = repRepo.GetCount_CS();

            this.lbl_AB_Invited_CS.Text = report.AB_Invited.Value.ToString();
            this.lbl_AB_Reg_CS.Text = report.AB_Registered.Value.ToString();

            this.lbl_BC_Invited_CS.Text = report.BC_Invited.Value.ToString();
            this.lbl_BC_Reg_CS.Text = report.BC_Registered.Value.ToString();

            this.lbl_SK_Invited_CS.Text = report.SK_Invited.Value.ToString();
            this.lbl_SK_Reg_CS.Text = report.SK_Registered.Value.ToString();

            this.lbl_MB_Invited_CS.Text = report.MB_Invited.Value.ToString();
            this.lbl_MB_Reg_CS.Text = report.MB_Registered.Value.ToString();

            this.lbl_ON_Invited_CS.Text = report.ON_Invited.Value.ToString();
            this.lbl_ON_Reg_CS.Text = report.ON_Registered.Value.ToString();

            this.lbl_QC_Invited_CS.Text = report.QC_Invited.Value.ToString();
            this.lbl_QC_Reg_CS.Text = report.QC_Registered.Value.ToString();

            this.lbl_NB_Invited_CS.Text = report.NB_Invited.Value.ToString();
            this.lbl_NB_Reg_CS.Text = report.NB_Registered.Value.ToString();

            this.lbl_NS_Invited_CS.Text = report.NS_Invited.Value.ToString();
            this.lbl_NS_Reg_CS.Text = report.NS_Registered.Value.ToString();

            this.lbl_NL_Invited_CS.Text = report.NL_Invited.Value.ToString();
            this.lbl_NL_Reg_CS.Text = report.NL_Registered.Value.ToString();

            this.lbl_PEI_Invited_CS.Text = report.PEI_Invited.Value.ToString();
            this.lbl_PEI_Reg_CS.Text = report.PEI_Registered.Value.ToString();

            this.lblInvitedTotal_2.Text =
            (
                report.AB_Invited.Value +
                report.BC_Invited.Value +
                report.SK_Invited.Value +
                report.MB_Invited.Value +
                report.ON_Invited.Value +
                report.QC_Invited.Value +
                report.NB_Invited.Value +
                report.NS_Invited.Value +
                report.NL_Invited.Value +
                report.PEI_Invited.Value

                ).ToString();

            this.lblRegTotal_2.Text = (
                                            report.AB_Registered.Value +
                                            report.BC_Registered.Value +
                                            report.SK_Registered.Value +
                                            report.MB_Registered.Value +
                                            report.ON_Registered.Value +
                                            report.QC_Registered.Value +
                                            report.NB_Registered.Value +
                                            report.NS_Registered.Value +
                                            report.NL_Registered.Value +
                                            report.PEI_Registered.Value

                                        ).ToString();
        }

        internal void DisplayLogFile(string csvExportContents)
        {
            byte[] data = new ASCIIEncoding().GetBytes(csvExportContents);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=Export.csv");
            HttpContext.Current.Response.OutputStream.Write(data, 0, data.Length);
            HttpContext.Current.Response.End();
        }

        private bool IsPCP()
        {
            return ViewState["ISPCP"].ToString() == "1";
        }


        public enum SearchMode
        {
            FSA = 1,
            BI = 2,
            Lilly = 3
        }

        public void HideShowSearchBoxes(SearchMode mode)
        {

            switch (mode)
            {
                case SearchMode.FSA:

                    this.pnlFSA.Enabled = true;
                    this.lboxFSA.Visible = true;

                    this.pnlBI.Enabled = false;
                    this.lboxBI.Visible = false;

                    pnlLilly.Enabled = false;
                    lboxLilly.Visible = false;

                    break;

                case SearchMode.BI:

                    this.pnlFSA.Enabled = false;
                    this.lboxFSA.Visible = false;

                    this.pnlBI.Enabled = true;
                    this.lboxBI.Visible = true;

                    pnlLilly.Enabled = false;
                    lboxLilly.Visible = false;

                    break;

                case SearchMode.Lilly:

                    this.pnlFSA.Enabled = false;
                    this.lboxFSA.Visible = false;

                    this.pnlBI.Enabled = false;
                    this.lboxBI.Visible = false;

                    pnlLilly.Enabled = true;
                    lboxLilly.Visible = true;

                    break;

                default:
                    break;
            }



            lboxBI.SelectedIndex = -1;
            lboxFSA.SelectedIndex = -1;
            lboxLilly.SelectedIndex = -1;

            lboxBI.DataBind();
            lboxFSA.DataBind();
            lboxLilly.DataBind();

        }

        #endregion

        #region Event Handlers

        protected void btnAll_clicked(object sender, EventArgs e)
        {
            foreach (ListItem item in this.lboxFSA.Items)
            {
                item.Selected = true;
            }
        }

        protected void btn_BI_All_clicked(object sender, EventArgs e)
        {
            foreach (ListItem item in this.lboxBI.Items)
            {
                item.Selected = true;
            }

        }

        protected void btn_Lilly_All_clicked(object sender, EventArgs e)
        {
            foreach (ListItem item in this.lboxLilly.Items)
            {
                item.Selected = true;
            }
        }

        protected void imgProgramGlancePCP_clicked(object sender, EventArgs e)
        {
            DisplayLogFile(csvHelper.GetCsv<GlanceReport>(repRepo.GetGlanceReport_PCP()));
        }

        protected void imgProgramGlanceCS_clicked(object sender, EventArgs e)
        {
            DisplayLogFile(csvHelper.GetCsv<GlanceReport>(repRepo.GetGlanceReport_CS()));

        }

        protected void btnProgram_clicked(object sender, EventArgs e)
        {
            if (this.lboxProgram.SelectedItem == null)
                return;


            bool isPCP = this.lboxProgram.SelectedItem.Value == "1";

            ViewState["ISPCP"] = isPCP ? "1" : "0";

            if (isPCP) //is pcp
            {
                this.pnlPCP.Visible = true;
                this.pnlCS.Visible = false;
                pnlProgram.Visible = false;
                pnlReports.Visible = true;

                LoadReport_PCP();

                trPCP.Visible = true;
                trCS.Visible = false;
            }
            else  //is cs
            {
                this.pnlPCP.Visible = false;
                this.pnlCS.Visible = true;
                pnlProgram.Visible = false;
                pnlReports.Visible = true;

                LoadReport_CS();

                trPCP.Visible = false;
                trCS.Visible = true;
            }

        }

        protected void btnBack_clicked(object sender, EventArgs e)
        {

            string correct_url = returnToAdmin ? "AdminDefault.aspx" : "Default.aspx";

            string url = string.Format("~/{4}?{0}={1}&{2}={3}", Constants.IS_PCP, (isPCP.HasValue ? isPCP.Value ? "1" : "0" : "-1"), Constants.PROVINCEID, provinceID.ToString(), correct_url);

            Response.Redirect(url);
        }

        protected void imgMaster_clicked(object sender, EventArgs e)
        {
            if (this.lboxFSA.Visible)
            {

                if (lboxFSA.GetSelectedIndices().Count() == 0)
                    return;

                string fsaLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxFSA.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                }

                fsaLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetMasterReport(fsaLst, IsPCP())));

            }
            else if (this.lboxBI.Visible)
            {
                if (this.lboxBI.GetSelectedIndices().Count() == 0)
                    return;

                string biLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxBI.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                }

                biLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetMasterReport_BI(biLst, IsPCP())));

            }
            else if (this.lboxLilly.Visible)
            {
                if (this.lboxLilly.GetSelectedIndices().Count() == 0)
                    return;

                string lillyLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxLilly.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                }

                lillyLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetMasterReport_Lilly(lillyLst, IsPCP())));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a Filter Mode')", true);
            }

        }

        protected void imgInvitedPar_clicked(object sender, EventArgs e)
        {

            if (this.lboxFSA.Visible)
            {

                if (lboxFSA.GetSelectedIndices().Count() == 0)
                    return;

                string fsaLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxFSA.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                fsaLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetInvitedReport(fsaLst, IsPCP())));
            }
            else if (this.lboxBI.Visible)
            {

                if (this.lboxBI.GetSelectedIndices().Count() == 0)
                    return;

                string biLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxBI.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                biLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetInvitedReport_BI(biLst, IsPCP())));

            }
            else if (this.lboxLilly.Visible)
            {
                if (this.lboxLilly.GetSelectedIndices().Count() == 0)
                    return;

                string lillyLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxLilly.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                }

                lillyLst = sb.ToString().TrimEnd(",".ToCharArray());

                 DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetInvitedReport_Lilly(lillyLst, IsPCP())));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a Filter Mode')", true);
            }
        }

        protected void imgRegPar_clicked(object sender, EventArgs e)
        {
            if (this.lboxFSA.Visible)
            {

                if (lboxFSA.GetSelectedIndices().Count() == 0)
                    return;

                string fsaLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxFSA.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                fsaLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetRegisteredReport(fsaLst, IsPCP())));
            }
            else if (this.lboxBI.Visible)
            {

                if (this.lboxBI.GetSelectedIndices().Count() == 0)
                    return;

                string biLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxBI.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                biLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetRegisteredReport_BI(biLst, IsPCP())));

            }
            else if (this.lboxLilly.Visible)
            {
                if (this.lboxLilly.GetSelectedIndices().Count() == 0)
                    return;

                string lillyLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxLilly.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                }

                lillyLst = sb.ToString().TrimEnd(",".ToCharArray());

               DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetRegisteredReport_Lilly(lillyLst, IsPCP())));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a Filter Mode')", true);
            }
        }

        protected void imgNoResp_clicked(object sender, EventArgs e)
        {
            if (this.lboxFSA.Visible)
            {

                if (lboxFSA.GetSelectedIndices().Count() == 0)
                    return;

                string fsaLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxFSA.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                fsaLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetNoResponseReport(fsaLst, IsPCP())));
            }
            else if (this.lboxBI.Visible)
            {
                if (this.lboxBI.GetSelectedIndices().Count() == 0)
                    return;

                string biLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxBI.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                biLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetNoResponseReport_BI(biLst, IsPCP())));

            }
            else if (this.lboxLilly.Visible)
            {
                if (this.lboxLilly.GetSelectedIndices().Count() == 0)
                    return;

                string lillyLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxLilly.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                }

                lillyLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetNoResponseReport_Lilly(lillyLst, IsPCP())));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a Filter Mode')", true);
            }
        }

        protected void imgNotInvited_clicked(object sender, EventArgs e)
        {
            if (this.lboxFSA.Visible)
            {

                if (lboxFSA.GetSelectedIndices().Count() == 0)
                    return;

                string fsaLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxFSA.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                fsaLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetNotInvitedReport(fsaLst, IsPCP())));
            }
            else if (this.lboxBI.Visible)
            {
                if (this.lboxBI.GetSelectedIndices().Count() == 0)
                    return;

                string biLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxBI.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                    //sb.Append("@").Append(item.Text).Append("@,");
                }

                biLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetNotInvitedReport_BI(biLst, IsPCP())));

            }
            else if (this.lboxLilly.Visible)
            {
                if (this.lboxLilly.GetSelectedIndices().Count() == 0)
                    return;

                string lillyLst = string.Empty;

                StringBuilder sb = new StringBuilder();

                foreach (ListItem item in this.lboxLilly.Items)
                {
                    if (item.Selected)
                        sb.Append(item.Text).Append(",");
                }

                lillyLst = sb.ToString().TrimEnd(",".ToCharArray());

                DisplayLogFile(csvHelper.GetCsv<MasterReport>(repRepo.GetNotInvitedReport_Lilly(lillyLst, IsPCP())));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a Filter Mode')", true);
            }
        }

        protected void imgAlliance_clicked(object sender, EventArgs e)
        {

            DisplayLogFile(csvHelper.GetCsv<AllianceReport>(repRepo.GetAllianceReport()));
        }

        protected void imgPCPRegItems_clicked(object sender, EventArgs e)
        {

            DisplayLogFile(csvHelper.GetCsv<PCP_ActionItem>(repRepo.GetPCP_ActionItemReport()));
        }

        protected void lboxFSA_SelectedIndexChanged(object sender, EventArgs e)
        {

            //lboxBI.SelectedIndex = -1;
        }

        protected void lboxBI_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lboxFSA.SelectedIndex = -1;
        }

        protected void lboxLilly_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rdoSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.rdoSearchMode.SelectedValue == "1") //FSA
            {
                HideShowSearchBoxes(SearchMode.FSA);
            }
            else
                if (this.rdoSearchMode.SelectedValue == "2") //BI
                {
                    HideShowSearchBoxes(SearchMode.BI);
                }
                else
                {
                    HideShowSearchBoxes(SearchMode.Lilly); //LILLY
                }
        }

       



        #endregion


    }
}