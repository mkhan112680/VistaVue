using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace VistaDM.Admin.Code
{
    public class UIHelper
    {

        #region Static Alert()
        public static void Alert(System.Web.UI.Page pageCurrent, string strMsg)
        {

            //Replace \n
            strMsg = strMsg.Replace("\n", "\\n");
            //Replace \r
            strMsg = strMsg.Replace("\r", "\\r");
            //Replace "
            strMsg = strMsg.Replace("\"", "\\\"");
            //Replace '
            strMsg = strMsg.Replace("\'", "\\\'");

            pageCurrent.ClientScript.RegisterStartupScript(pageCurrent.GetType(),
                System.Guid.NewGuid().ToString(),
                "<script>window.alert('" + strMsg + "')</script>"
                );
        }

        #endregion

        #region Static UpdatePanelClientScript()
        //  UpdatePanelClientScript(UpdatePanelIPV, "window.open('GenerateInvitation.aspx');" );
        public static void UpdatePanelClientScript(UpdatePanel panel, string script)
        {
            ScriptManager.RegisterStartupScript(panel, typeof(Page), System.Guid.NewGuid().ToString(), script, true);
        }
        #endregion

        #region RegularScript()
        //RegularClientScript(this.page, "window.location.href='test.html';" );
        public static void RegularClientScript(System.Web.UI.Page pageCurrent, string strMsg)
        {
            pageCurrent.ClientScript.RegisterClientScriptBlock(pageCurrent.GetType(),
                System.Guid.NewGuid().ToString(), strMsg, true);

        }
        #endregion

    }
}