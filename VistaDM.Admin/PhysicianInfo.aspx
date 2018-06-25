<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicianInfo.aspx.cs"
    Inherits="VistaDM.Admin.PhysicianInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Untitled Document</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,700,300italic'
        rel='stylesheet' type='text/css'>
    <style type="text/css">
        #wrapper
        {
            width: 609px;
            margin : 0 auto;
        }
        #header
        {
            background-image: url(../images/form_header.png);
            background-repeat: no-repeat;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #FFF;
            font-size: 24px;
            padding-top: 15px;
            padding-bottom: 10px;
            text-align: center;
            line-height: 25px;
        }
        #main
        {
            background-color: #DEDFE0;
            width: 602px;
        }
        #footer
        {
            background-image: url(../images/form_footer.png);
            background-repeat: no-repeat;
            height: 50px;
        }
        #center
        {
            text-align: center;
            width: 100%;
        }
        .italic
        {
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 19px;
            font-style: italic;
            color: #666;
        }
        .normal
        {
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 19px;
            font-weight: 700;
            color: #414042;
        }
        .redsmallitalic
        {
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 18px;
            color: #9B2346;
            font-style: italic;
        }
        textarea
        {
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
            width: 89%;
            height: 80px;
            padding-left: 20px;
            padding-right: 20px;
            padding-top: 10px;
        }
        input[type=text]
        {
            width: 96%;
            height: 32px;
            padding-left: 20px;
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }
        input[type=text]:focus
        {
            border-color: #333;
        }
        input[type=submit]
        {
            padding: 5px 15px;
            background: #ccc;
            border: 0 none;
            cursor: pointer;
            -webkit-border-radius: 5px;
            border-radius: 5px;
        }
        .grow img
        {
            transition: .5s ease;
        }
        .grow img:hover
        {
            -webkit-transform: scale(1.1);
            -ms-transform: scale(1.1);
            transform: scale(1.1);
            transition: .5s ease;
        }
        select
        {
            width: 100%;
            height: 32px;
            padding-left: 20px;
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }
        input[type=checkbox]
        {
            visibility: hidden;
        }
        /* SQUARED THREE */.squaredThree
        {
            width: 20px;
            margin: auto;
            position: relative;
        }
        .squaredThree label
        {
            cursor: pointer;
            position: absolute;
            width: 20px;
            height: 20px;
            top: 0;
            border-radius: 4px;
            -webkit-box-shadow: inset 0px 1px 1px rgba(0,0,0,0.5), 0px 1px 0px rgba(255,255,255,.4);
            -moz-box-shadow: inset 0px 1px 1px rgba(0,0,0,0.5), 0px 1px 0px rgba(255,255,255,.4);
            box-shadow: inset 0px 1px 1px rgba(0,0,0,0.5), 0px 1px 0px rgba(255,255,255,.4);
            background: -webkit-linear-gradient(top, #222 0%, #45484d 100%);
            background: -moz-linear-gradient(top, #222 0%, #45484d 100%);
            background: -o-linear-gradient(top, #222 0%, #45484d 100%);
            background: -ms-linear-gradient(top, #222 0%, #45484d 100%);
            background: linear-gradient(top, #222 0%, #45484d 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#222', endColorstr='#45484d',GradientType=0 );
        }
        .squaredThree label:after
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=0)";
            filter: alpha(opacity=0);
            opacity: 0;
            content: '';
            position: absolute;
            width: 9px;
            height: 5px;
            background: transparent;
            top: 4px;
            left: 4px;
            border: 3px solid #fcfff4;
            border-top: none;
            border-right: none;
            -webkit-transform: rotate(-45deg);
            -moz-transform: rotate(-45deg);
            -o-transform: rotate(-45deg);
            -ms-transform: rotate(-45deg);
            transform: rotate(-45deg);
        }
        .squaredThree label:hover::after
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=30)";
            filter: alpha(opacity=30);
            opacity: 0.3;
        }
        .squaredThree input[type=checkbox]:checked + label:after
        {
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
            filter: alpha(opacity=100);
            opacity: 1;
        }
        #invitationbox
        {
            width: 400px;
            height: 520px;
            border: 1px rgb(115, 115, 115) solid;
            background: #FCFCFC;
            -moz-box-shadow: 0px 0px 11px 5px rgb(128,128,128);
            -webkit-box-shadow: 0px 0px 11px 5px rgb(128,128,128);
            box-shadow: 0px 0px 11px 5px rgb(128,128,128);
            border-radius: 15px;
            margin-left: auto;
            margin-right: auto;
        }
        #invitationbox2
        {
            background: #EDEDED;
            -moz-box-shadow: inset 0px 0px 5px 0px rgb(128,128,128);
            -webkit-box-shadow: inset 0px 0px 5px 0px rgb(128,128,128);
            box-shadow: inset 0px 0px 5px 0px rgb(128,128,128);
            margin: 10px;
            border-radius: 14px;
            border: 1px #999 solid;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="Form" runat="server">
    <div id="wrapper">
        <div id="header">
            PHYSICIAN CONTACT
            <br />
            INFORMATION
        </div>
        <!--end of header-->
        <div id="main">
            <div id="center">
                <span class="normal">Please update any revelant field below and click the "Update" button.
                    <br />
                    <br />
                </span><span class="redsmallitalic">* PLEASE DO NOT UPDATE ANY OF THE CONTACT FIELDS
                    FOR PHYSICIANS MARKED AS REGISTERED *</span><br />
            </div>
            <!--end of center-->
            <br />
            <br />
            <table width="70%" border="0" cellspacing="0" cellpadding="0" style="margin-left: auto;
                margin-right: auto">
                <tr>
                    <td colspan="3" class="italic">
                        FIRST NAME <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtFirstName" />
                        <asp:RequiredFieldValidator ErrorMessage="First Name required" ControlToValidate="txtFirstName"
                            runat="server" ID="reqtxtFirstName" CssClass="ValText" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td width="78%">
                        &nbsp;
                    </td>
                    <td width="11%">
                        &nbsp;
                    </td>
                    <td width="11%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        LAST NAME <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtLastName" />
                        <asp:RequiredFieldValidator ErrorMessage="Last Name required" ControlToValidate="txtLastName"
                            runat="server" ID="reqtxtLastName" CssClass="ValText" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        CLINIC NAME
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtClinic" />
                        <asp:RequiredFieldValidator ErrorMessage="Clinic required" ControlToValidate="txtClinic"
                            runat="server" ID="reqtxtClinic" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        ADDRESS
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtAddress" />
                        <asp:RequiredFieldValidator ErrorMessage="Address required" ControlToValidate="txtAddress"
                            runat="server" ID="reqtxtAddress" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        CITY <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtCity" />
                        <asp:RequiredFieldValidator ErrorMessage="City required" ControlToValidate="txtCity"
                            runat="server" ID="reqtxtCity" CssClass="ValText" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        PROVINCE <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddProvince">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="cmpddProvince" runat="server" ControlToValidate="ddProvince"
                            ValueToCompare="-1" ErrorMessage="Province Required" Type="String" Operator="NotEqual"
                            Display="Dynamic" CssClass="ValText">
                        </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        POSTAL CODE
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtPostalCode" />
                        <asp:RequiredFieldValidator ErrorMessage="Postal Code required" ControlToValidate="txtPostalCode"
                            runat="server" ID="reqtxtPostalCode" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        PHONE
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtPhone" />
                        <asp:RequiredFieldValidator ErrorMessage="Phone required" ControlToValidate="txtPhone"
                            runat="server" ID="reqtxtPhone" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        FAX
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtFax" />
                        <asp:RequiredFieldValidator ErrorMessage="Fax required" ControlToValidate="txtFax"
                            runat="server" ID="reqtxtFax" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        EMAIL
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" />
                        <asp:RequiredFieldValidator ErrorMessage="Email required" ControlToValidate="txtEmail"
                            runat="server" ID="reqtxtEmail" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                    <td>
                        <div class="squaredThree">
                            <asp:CheckBox Text="" runat="server" ID="squaredThree" />
                            <%--<input type="checkbox" value="None" id="squaredThree" name="check" />--%>&nbsp;
                            <label for="squaredThree">
                            </label>
                        </div>
                    </td>
                    <td class="italic" align="right">
                        OPT-IN
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        UNIQUE ID
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtUnique" ReadOnly="true" />
                        <asp:RequiredFieldValidator ErrorMessage="Unique Code required" ControlToValidate="txtUnique"
                            runat="server" ID="reqtxtUnique" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="italic">
                        COMMENTS
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Width="100%" Rows="5" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="grow" style="text-align: center">
                <asp:ImageButton ImageUrl="~/images/button_update.png" runat="server" OnClick="btnSubmit_clicked"
                    ID="btnSubmit" />
            </div>
            <br />
            <br />
            <div id="invitationbox">
                <div id="invitationbox2">
                    <br />
                    <span class="normal" style="color: #9B2346">SEND INVITATION BY EMAIL</span>
                    <br />
                    <br />
                    <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC;
                        width: 100%">
                    </div>
                    <br />
                    <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left;
                        margin-left: auto; margin-right: auto">
                        <tr>
                            <td>
                                <input type="text" placeholder="Physician's Email" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC;
                        width: 100%">
                    </div>
                    <br />
                    <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left;
                        margin-left: auto; margin-right: auto">
                        <tr>
                            <td>
                                <input type="text" placeholder="Your Email" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC;
                        width: 100%">
                    </div>
                    <br />
                    <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left;
                        margin-left: auto; margin-right: auto">
                        <tr>
                            <td>
                                <textarea placeholder="Message"></textarea>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC;
                        width: 100%">
                    </div>
                    <br />
                    <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left;
                        margin-left: auto; margin-right: auto">
                        <tr>
                            <td>
                                <table width="100%" border="0">
                                    <tr>
                                        <td width="50%" class="italic">
                                            SEND INVITATION IN:
                                        </td>
                                        <td width="30%">
                                            <div class="squaredThree">
                                                <input type="checkbox" value="None" id="squaredThree2" name="check" />
                                                <label for="squaredThree2">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="20%" class="italic">
                                            ENGLISH
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <div class="squaredThree">
                                                <input type="checkbox" value="None" id="squaredThree3" name="check" />
                                                <label for="squaredThree3">
                                                </label>
                                            </div>
                                        </td>
                                        <td class="italic">
                                            FRANÇIAS
                                        </td>
                                    </tr>
                                </table>
                        </tr>
                    </table>
                    <br />
                </div>
                <!--end of invitation box2-->
                <div class="grow" style="text-align: center">
                    <img src="../images/button_send.png" /></div>
            </div>
            <!--end of invitation box-->
            <br />
            <br />
        </div>
        <!--end of main-->
        <div id="footer">
        </div>
        <!--end of footer-->
    </div>
    </form>
</body>
</html>
