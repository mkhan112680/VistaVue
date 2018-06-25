using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using VistaDM.Repository;
using VistaDM.Admin.Code;
using System.Security.Principal;
using VistaDM.Code;
using VistaDM.Domain;

namespace VistaDM.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Master.FooterPanel.Visible = false; 

            //if (Request.Url.ToString().ToLower().Contains(Constants.SUPER_STR))
            //{
            //    Response.Redirect(Constants.ADMIN_LOGINPAGE);
            //} 

            //if (Request.Url.ToString().ToLower().Contains(Constants.ALLIANCE_STR))
            //{
            //    Response.Redirect(Constants.SPONSER_LOGINPAGE);
            //}

            if (!Page.IsPostBack)
            {
                CheckRememberMe();
                HideControls();
            }
        }

        #region Methods

        

        private void CheckRememberMe()
        {
            string val = CookieHelper.GetCookieVal(Constants.SITECOOKIE);
            if (!string.IsNullOrEmpty(val))
            {
                this.txtUsername.Text = val;
                this.chkRemember.Checked = true;
            }
        }

        private void HideControls()
        {
            lblResult.Visible = false;
        }

        #endregion 

        #region Events 

        protected void imgLogin_clicked(object sender, System.EventArgs e)
        {
            
            SponserRepository sponserRepo = new SponserRepository();

            string userName = txtUsername.Text;
            string pass = this.txtPass.Text;

            pass = Encryptor.Encrypt(pass);

            if (sponserRepo.Authenticate(userName, pass))
            {
                CookieHelper.WriteCookie(this.txtUsername.Text, chkRemember.Checked);

                SponserUser usr = UserHelper.SetupUserOnLogin(userName, pass);

                HttpContext.Current.User = new GenericPrincipal(User.Identity, null);

                FormsAuthentication.SetAuthCookie(userName, false);

                Response.Redirect(UserHelper.GetURLByRole(usr) );
 
            }
            else
            {

                lblResult.Visible = true;
            }


        }


        protected void lbtnForgot_clicked(object sender, System.EventArgs e )
        {


        }

        #endregion 
    }
}