using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using VistaDM.Code;
using VistaDM.Domain;
using VistaDM.Admin.Code;

namespace VistaDM.Admin
{
    public partial class AdminLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UserHelper.SetLoggedInUser(new SponserUser(), HttpContext.Current.Session);
            
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

            

            //Response.Redirect("~/AdminLogin.aspx");
            
            //if (!Request.UrlReferrer.LocalPath.Contains(Constants.LOG_IN_PAGE))
            //{
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();

            //    UserHelper.SetLoggedInUser(new SponserUser(), HttpContext.Current.Session);

            //    Response.Redirect("~/AdminLogin.aspx");

            //}
            //else
            //    Response.Redirect("~/AdminDefault.aspx");
        }
    }
}