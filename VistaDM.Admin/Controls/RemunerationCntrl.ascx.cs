using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Domain;
using VistaDM.Repository;

namespace VistaDM.Admin.Controls
{
    public partial class RemunerationCntrl : System.Web.UI.UserControl
    {

        public enum Type
        {
            PAF1                = 0,
            PAF1_ReAssessment   = 1,
            PAF2                = 2,
            PAF2_ReAssessmentA  = 3,
            PAF2_ReAssessmentB  = 4,
            Evaluation          = 5,
            Asses               = 6
        }

        int physicianID = -1;
        bool isPCP = false;
        public string ValidationGroup
        {
            get
            {
                return this.imgBtn.ValidationGroup;
            }
            set
            {
                imgBtn.ValidationGroup = value;

                req1.ValidationGroup = value;
                req2.ValidationGroup = value;
                req3.ValidationGroup = value;
                compPAF1.ValidationGroup = value;
                valSummary.ValidationGroup = value;
                img.ValidationGroup = value;
            }
        }
        InviteeRepository invRepos = new InviteeRepository();
        public Type RemunerationType { get; set; }

        public string Status
        {
            get
            {
                return renStatus.Text;
            }

            set
            {

                renStatus.Text = value;

            }
        }

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


            ClearLabels();

            if (!Page.IsPostBack)
            {
                if (RemunerationType == Type.PAF1)
                {
                    Load_PAF1_Data();
                }

                if (RemunerationType == Type.Asses)
                {
                    Load_Asses_Data();
                }
            }
        }

        #region Methods

        private void ClearFields()
        {
            this.txt_PAF1_Date.Text = string.Empty;
            this.txt_PAF1_chk.Text = string.Empty;
            this.txt_PAF_amount.Text = string.Empty;
            this.txt_PAF_Comments.Text = string.Empty;

        }

        private void ClearLabels()
        {
            this.lbl_PAF_Result.Text = string.Empty;
        }

        private void Load_PAF1_Data()
        {
            this.gvPAF1.DataSource = invRepos.Get_PAF_Remuneration(physicianID);
            this.gvPAF1.DataBind();

        }

        private void Load_Asses_Data()    
        {
            this.gvPAF1.DataSource = invRepos.Get_Assesment_Remuneration(physicianID);
            this.gvPAF1.DataBind();
         }

        #endregion

        #region Event Handlers

        protected void img_clicked(object sender, System.EventArgs e)
        {
            string[] formats = { "dd/MM/yyyy" };
            DateTime dummy;
            if (
                  !DateTime.TryParseExact(
                                       txt_PAF1_Date.Text,
                                       formats,
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out dummy
                                   )
                )
            {
                this.lbl_PAF_Result.Text = "Invalid Date Format";
                return;
            }

            if (RemunerationType == Type.PAF1)
            {

                DateTime date = DateTime.ParseExact(txt_PAF1_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string checkNum = this.txt_PAF1_chk.Text;
                decimal amount = decimal.Parse(txt_PAF_amount.Text);
                string comments = this.txt_PAF_Comments.Text;

                Remuneration newRen = new Remuneration()
                {
                    Date = date,
                    Cheque = checkNum,
                    Amount = amount,
                    Comments = comments,
                    InviteeID = physicianID
                };

                //save data//
                invRepos.Set_PAF_Remuneration(newRen);

                //realod the gid
                Load_PAF1_Data();
            }
            else
                if (RemunerationType == Type.Asses)
                {

                    DateTime date = DateTime.ParseExact(txt_PAF1_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string checkNum = this.txt_PAF1_chk.Text;
                    decimal amount = decimal.Parse(txt_PAF_amount.Text);
                    string comments = this.txt_PAF_Comments.Text;

                    Remuneration newRen = new Remuneration()
                    {
                        Date = date,
                        Cheque = checkNum,
                        Amount = amount,
                        Comments = comments,
                        InviteeID = physicianID
                    };

                    //save data//
                    invRepos.Set_Assesment_Remuneration(newRen);

                    //realod the gid
                    Load_Asses_Data();
                }

            ClearFields();
        }

        #endregion
    }
}