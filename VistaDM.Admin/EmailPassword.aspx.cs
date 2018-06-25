using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaDM.Admin.Code;
using VistaDM.Code;
using VistaDM.Repository;

namespace VistaDM.Admin
{
    public partial class EmailPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void imgBtn_clicked(object sender, EventArgs e)
        {
            bool errored = false;
            try 
	        {
                UserRepository repo = new UserRepository();
	            
                string userName = this.txtusername.Text;

                string pwd = repo.GetSponserPassword(userName);

                if (!string.IsNullOrEmpty(pwd))
                {
                    pwd = Encryptor.Decrypt(pwd);

                    Utility.SendPasswordEmail(userName, pwd, Constants.FORGOTPWD_SPONSER_HTML);
                }
                else
                {
                    lblResult.Text = "User Not found";
                    errored = true;
                }
               
            }
	        catch (Exception exce)
	        {
		            lblResult.Text = exce.ToString();

                    errored = true;
	        }

            if(  ! errored )
            {
                pnlEmailed.Visible = true;
                pnlMain.Visible = false;
            }
        }

    }
}