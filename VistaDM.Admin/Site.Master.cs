using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Domain;

namespace VistaDM.Admin
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public Panel FooterPanel
        {

            get
            {

                return pnlfooter;
            }
        }

        public Controls.Menu Menu
        {

            get
            {

                return this.Registration1;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            SponserUser user = VistaDM.Admin.Code.UserHelper.GetLoggedInUser(HttpContext.Current.Session);
            if (! string.IsNullOrEmpty( user.Username))
            {

                pnlUsername.Visible = true;
                
                if (user.FirstName.ToLower() == "admin".ToLower() )
                    lblUserName.Text = "CHRC";
                else
                    lblUserName.Text = user.FirstName ;
            }
        }


    }
}
