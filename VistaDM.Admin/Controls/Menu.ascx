<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="VistaDM.Admin.Controls.Menu" %>
<asp:Panel runat="server" ID="pnl">
    <table width="50%" border="0" style="float: right" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <img src="images/logo_boehringer.png" width="120" style="padding-right: 20px" /><img
                    src="images/logo_lilly.png" width="120" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <img src="images/button_home_active.png" /><a href="#" onmouseout="MM_swapImgRestore()"
                    onmouseover="MM_swapImage('Image25','','images/button_steeringcommittee_active.png',1)"><img
                        src="images/button_steeringcommittee.png" name="Image25" width="97" height="88"
                        border="0" id="Image25" /></a><a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image26','','images/button_contact_active.png',1)"><img
                            src="images/button_contact.png" name="Image26" width="97" height="88" border="0"
                            id="Image26" /></a><a href="Logout.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image27','','images/button_logout_active.png',1)"><img
                                src="images/button_logout.png" name="Image27" width="97" height="88" border="0"
                                id="Image27" /></a><a onmouseover="MM_swapImage('Image31','','images/button_toolbox_active.png',1)"
                                    onmouseout="MM_swapImgRestore()" href="Logout.aspx"><%--<img border="0" name="Image31" id="Image31" src="images/button_toolbox.png" width="97"
                                            height="88" /></a>--%>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="pnlLogin">
    <table width="50%" border="0" style="float: right" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <img src="images/logo_boehringer.png" width="120" style="padding-right: 20px" /><img
                    src="images/logo_lilly.png" width="120" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="pnlAdmin" Visible="false">
    <table width="50%" border="0" style="float: right" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <a href="AdminLogout.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image27','','images/button_logout_active.png',1)">
                    <img src="images/button_logout.png" name="Image27" width="97" height="88" border="0"
                        id="Img1" /></a><img src="images/logo_chrc.png" width="120" style="padding-right: 20px"
                            height="88" />
            </td>
        </tr>
    </table>
</asp:Panel>
