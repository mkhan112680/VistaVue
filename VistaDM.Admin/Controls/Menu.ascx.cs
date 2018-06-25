using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace VistaDM.Admin.Controls
{
    public partial class Menu : System.Web.UI.UserControl
    {


        public void GoInAdminMode(bool isAdminMode)
        {
            if (isAdminMode)
            {
                pnlAdmin.Visible = true;
                pnl.Visible = false;
                pnlLogin.Visible = false;
            }

            else
            {

                this.pnl.Visible = Context.User.Identity.IsAuthenticated;
                pnlLogin.Visible = !Context.User.Identity.IsAuthenticated;
                pnlAdmin.Visible = false;
            }

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            //imgLogOut.Attributes.Add("onmouseover", "MM_swapImage('Image27','','../images/button_logout_active.png',1)");
            //imgLogOut.Attributes.Add("onmouseout", "MM_swapImgRestore()");

            Domain.SponserUser user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);

            if (user.IsAdmin)
            {
                pnlAdmin.Visible = true;
                pnl.Visible = false;
                pnlLogin.Visible = false;
            }

            else
            {

                this.pnl.Visible = Context.User.Identity.IsAuthenticated;
                pnlLogin.Visible = !Context.User.Identity.IsAuthenticated;
                pnlAdmin.Visible = false;
            }

        }


        #region Events

        protected void imgLogOut_clicked(object sender, System.EventArgs e)
        {

            //FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
        }

        #endregion 
    }
}