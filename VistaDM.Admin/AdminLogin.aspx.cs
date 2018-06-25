using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Repository;
using VistaDM.Admin.Code;
using System.Web.Security;
using System.Security.Principal;
using VistaDM.Domain;
using VistaDM.Code;

namespace VistaDM.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            Master.Menu.GoInAdminMode(true);
        }

        protected void imgLogin_clicked(object sender, EventArgs e)
        {
            SponserRepository sponserRepo = new SponserRepository();

            string userName = txtUsername.Text;
            string pass = this.txtPass.Text;

            if (userName == Constants.ADMIN_USER && pass == Constants.ADMIN_PWD )
            {

                SponserUser usr = UserHelper.SetupAdminOnLogin(userName);

                HttpContext.Current.User = new GenericPrincipal(User.Identity, null);

                FormsAuthentication.SetAuthCookie(userName, false);

                Response.Redirect("~/SelectProgram.aspx");

            }
            else
            {

                lblResult.Visible = true;
            }
        }
    }
}