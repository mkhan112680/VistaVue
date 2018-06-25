using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using VistaDM.Code;
using VistaDM.Admin.Code;
using VistaDM.Domain;

namespace VistaDM.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UserHelper.SetLoggedInUser(new SponserUser(), HttpContext.Current.Session);
            
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

            
            
            //if (!Request.UrlReferrer.LocalPath.Contains(Constants.LOG_IN_PAGE))
            //{
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();
                
            //    UserHelper.SetLoggedInUser(new SponserUser() , HttpContext.Current.Session);
            //}
            //else
            //    Response.Redirect("~/default.aspx");
        }
    }
}