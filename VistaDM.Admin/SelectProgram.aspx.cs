using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Code;
using VistaDM.Domain;

namespace VistaDM.Admin
{
    public partial class SelectProgram : System.Web.UI.Page
    {
        int provinceID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            SponserUser user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);

            if (Request.QueryString[Constants.PROVINCEID] != null)
                provinceID = Int32.Parse(Request.QueryString[Constants.PROVINCEID].ToString());

            if (user.IsAdmin)
            {
                hlPCP.NavigateUrl = string.Format("~/SelectRegion.aspx?{0}=1", Constants.IS_PCP);
                hlCS.NavigateUrl = string.Format("~/SelectRegion.aspx?{0}=0", Constants.IS_PCP);
            }
            else
            {
                if (user.HasMoreThanOneProvince() || provinceID == 0)
                {
                    hlPCP.NavigateUrl = string.Format("~/SelectRegion.aspx?{0}=1", Constants.IS_PCP);
                    hlCS.NavigateUrl = string.Format("~/SelectRegion.aspx?{0}=0", Constants.IS_PCP);
                }
                else
                {
                    if (provinceID != -1)
                    {
                        hlPCP.NavigateUrl = string.Format("~/Default.aspx?{0}=1&{1}={2}", Constants.IS_PCP, Constants.PROVINCEID, provinceID.ToString());
                        hlCS.NavigateUrl = string.Format("~/Default.aspx?{0}=0&{1}={2}", Constants.IS_PCP, Constants.PROVINCEID, provinceID.ToString());
                    }
                    else
                    {
                        hlPCP.NavigateUrl = string.Format("~/Default.aspx?{0}=1", Constants.IS_PCP);
                        hlCS.NavigateUrl = string.Format("~/Default.aspx?{0}=0", Constants.IS_PCP);
                    }
                }
            }
        }
    }
}