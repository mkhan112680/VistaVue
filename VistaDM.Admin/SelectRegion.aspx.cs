using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Domain;
using VistaDM.Code;

namespace VistaDM.Admin
{

    public partial class SelectRegion : System.Web.UI.Page
    {
        public SponserUser user = null;
        public int isPCP = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);

            //if (  VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session).HasMoreThanOneProvince())
            //{
            //    Response.Redirect("~/default.aspx");
            //}

            if (Request.QueryString[Constants.IS_PCP] != null)
                isPCP = Int32.Parse(Request.QueryString[Constants.IS_PCP].ToString());
            else
                isPCP = -1;

            InitializeImages();

            InitializeHyperLinks();

            Page.DataBind();

        }

        private void InitializeHyperLinks()
        {

            if (user.IsAdmin)
            {
                hlAll.NavigateUrl = hlAll.NavigateUrl.Replace("Default", "AdminDefault");
                hlPEI.NavigateUrl = hlPEI.NavigateUrl.Replace("Default", "AdminDefault");
                hlNL.NavigateUrl  = hlNL.NavigateUrl.Replace("Default", "AdminDefault");
                hlNB.NavigateUrl  = hlNB.NavigateUrl.Replace("Default", "AdminDefault");
                hlNS.NavigateUrl  = hlNS.NavigateUrl.Replace("Default", "AdminDefault");
                hlQC.NavigateUrl  = hlQC.NavigateUrl.Replace("Default", "AdminDefault");
                hlON.NavigateUrl  = hlON.NavigateUrl.Replace("Default", "AdminDefault");
                hlSK.NavigateUrl  = hlSK.NavigateUrl.Replace("Default", "AdminDefault");
                hlMB.NavigateUrl  = hlMB.NavigateUrl.Replace("Default", "AdminDefault");
                hlBC.NavigateUrl  = hlBC.NavigateUrl.Replace("Default", "AdminDefault");
                hlAB.NavigateUrl  = hlAB.NavigateUrl.Replace("Default", "AdminDefault");
            }

            hlAll.NavigateUrl += "?" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlPEI.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlNL.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlNB.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlNS.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlQC.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlON.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlSK.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlMB.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlBC.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();
            hlAB.NavigateUrl += "&" + Constants.IS_PCP + "=" + isPCP.ToString();

        }

        private void InitializeImages()
        {

            imgALL.ImageUrl = user.TerritoryCovergae_All.Value
                ? "~/images/region_buttons_ALL.png"
                : "~/images/region_buttons_ALL_gray.png";


            imgBC.ImageUrl = user.TerritoryCovergae_BC.Value
              ? "~/images/region_buttons_BC.png"
              : "~/images/region_buttons_BC_gray.png";

            imgAB.ImageUrl = user.TerritoryCovergae_AB.Value
                 ? "~/images/region_buttons_AB.png"
                 : "~/images/region_buttons_AB_gray.png";

            imgSK.ImageUrl = user.TerritoryCovergae_SK.Value
            ? "~/images/region_buttons_SK.png"
            : "~/images/region_buttons_SK_gray.png";

            imgMB.ImageUrl = user.TerritoryCovergae_MB.Value
                ? "~/images/region_buttons_MB.png"
                : "~/images/region_buttons_MB_gray.png";

            imgON.ImageUrl = user.TerritoryCovergae_ON.Value
             ? "~/images/region_buttons_ON.png"
             : "~/images/region_buttons_ON_gray.png";

            imgQC.ImageUrl = user.TerritoryCovergae_QC.Value
            ? "~/images/region_buttons_QC.png"
            : "~/images/region_buttons_QC_gray.png";

            imgNS.ImageUrl = user.TerritoryCovergae_NS.Value
            ? "~/images/region_buttons_NS.png"
            : "~/images/region_buttons_NS_gray.png";

            imgNB.ImageUrl = user.TerritoryCovergae_NB.Value
           ? "~/images/region_buttons_NB.png"
           : "~/images/region_buttons_NB_gray.png";

            imgNL.ImageUrl = user.TerritoryCovergae_NL.Value
                      ? "~/images/region_buttons_NL.png"
                      : "~/images/region_buttons_NL_gray.png";

            imgPEI.ImageUrl = user.TerritoryCovergae_PEI.Value
                     ? "~/images/region_buttons_PEI.png"
                     : "~/images/region_buttons_PEI_gray.png";

            if (user.TerritoryCovergae_All.Value)
            {
                imgALL.ImageUrl = "~/images/region_buttons_ALL.png";
                imgBC.ImageUrl = "~/images/region_buttons_BC.png";
                imgAB.ImageUrl = "~/images/region_buttons_AB.png";
                imgSK.ImageUrl = "~/images/region_buttons_SK.png";
                imgMB.ImageUrl = "~/images/region_buttons_MB.png";
                imgON.ImageUrl = "~/images/region_buttons_ON.png";
                imgQC.ImageUrl = "~/images/region_buttons_QC.png";
                imgNS.ImageUrl = "~/images/region_buttons_NS.png";
                imgNB.ImageUrl = "~/images/region_buttons_NB.png";
                imgNL.ImageUrl = "~/images/region_buttons_NL.png";
                imgPEI.ImageUrl = "~/images/region_buttons_PEI.png";
            }


            if (imgALL.ImageUrl == "~/images/region_buttons_ALL_gray.png")
            {
                hlAll.Enabled = false;
            }

            if (imgBC.ImageUrl == "~/images/region_buttons_BC_gray.png")
            {
                hlBC.Enabled = false;
            }

            if (imgAB.ImageUrl == "~/images/region_buttons_AB_gray.png")
            {
                hlAB.Enabled = false;
            }

            if (imgSK.ImageUrl == "~/images/region_buttons_SK_gray.png")
            {
                hlSK.Enabled = false;
            }

            if (imgMB.ImageUrl == "~/images/region_buttons_MB_gray.png")
            {
                hlMB.Enabled = false;
            }

            if (imgON.ImageUrl == "~/images/region_buttons_ON_gray.png")
            {
                hlON.Enabled = false;
            }

            if (imgQC.ImageUrl == "~/images/region_buttons_QC_gray.png")
            {
                hlQC.Enabled = false;
            }

            if (imgNS.ImageUrl == "~/images/region_buttons_NS_gray.png")
            {
                hlNS.Enabled = false;
            }

            if (imgNB.ImageUrl == "~/images/region_buttons_NB_gray.png")
            {
                hlNB.Enabled = false;
            }

            if (imgNL.ImageUrl == "~/images/region_buttons_NL_gray.png")
            {
                hlNL.Enabled = false;
            }

            if (imgPEI.ImageUrl == "~/images/region_buttons_PEI_gray.png")
            {
                hlPEI.Enabled = false;
            }

        }
    }
}