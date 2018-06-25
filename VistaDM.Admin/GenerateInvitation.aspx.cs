using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Code;
using VistaDM.Repository;
using VistaDM.Domain;
using VistaDM.Admin.Code;

namespace VistaDM.Admin
{
    public partial class GenerateInvitation : System.Web.UI.Page
    {
        private string formname;

        private bool isfrench = false;

        //private const string PATH = "~/Templates/";
        private const string PATH = "~/PDF/";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {

            if (Request.QueryString[Constants.ISFRENCH] != null)
                isfrench = Request.QueryString[Constants.ISFRENCH].ToString() == "1";

            formname = isfrench ? "VISTA DM_Invitation_PCP_FR.pdf" : "VISTA DM_Invitation_PCP.pdf";

            //formname = "vista invite template.pdf";


            byte[] bytes = getPracticePdf();

            if (bytes == null)
            {
                UIHelper.Alert(this, "Could not generate Pdf");
                return;
            }
            if (bytes.Length == 0)
            {
                UIHelper.Alert(this, "Could not generate Pdf");
                return;
            }

            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(bytes);

            }
            catch
            {
                UIHelper.Alert(this, "Could not display Pdf");
            }

        }

        public byte[] getPracticePdf()
        {

            List<Invitee> lstInvitee = new List<Invitee>();

            InviteeRepository invRepos = new InviteeRepository();

            GenPdf genpdf = new GenPdf(Server.MapPath(PATH));

            List<Invitee> invList = new List<Invitee>();

            List<int> lstIDInt = new List<int>();

            foreach (string id in Request.QueryString["physlst"].Split(",".ToCharArray()).ToList())
            {
                lstIDInt.Add(Int32.Parse(id));
            }


            invList = invRepos.GetInviteeData(lstIDInt);

            genpdf.Create();

            foreach (Invitee inv in invList)  //loop by physician
            {   //f1
                genpdf.AddForm(formname);
                //string nameA = doc.LastName + ", ";

                string fullName = inv.FirstName + " " + inv.LastName;

                //if (inv.Salutation != null)
                //    fullName = Utility.GetStrippedSalutation(inv.Salutation) + " " + inv.FirstName + " " + inv.LastName;
                //else
                //    fullName = inv.FirstName + " " + inv.LastName;


                genpdf.AddField("Unique ID", inv.RegistrationCode, 0);
                genpdf.AddField("LName", inv.LastName, 0);
                //genpdf.AddField("Salutation FNAME LNAME", fullName, 0);

                // genpdf.Save();
                genpdf.FinalizeForm(true);
            }
            return genpdf.Close();

        }
    }
}