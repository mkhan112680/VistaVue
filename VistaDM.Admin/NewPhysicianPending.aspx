<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPhysicianPending.aspx.cs"
    Inherits="VistaDM.Admin.NewPhysicianPending" %>

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
            width: 602px;
            margin: 0 auto;
        }
        #header
        {
            background-image: url(images/form_header.png);
            background-repeat: no-repeat;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #FFF;
            font-size: 24px;
            padding-top: 15px;
            padding-bottom: 50px;
            text-align: center;
            line-height: 25px;
        }
        #main
        {
            background-color: #DEDFE0;
        }
        #footer
        {
            background-image: url(images/form_footer.png);
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
            font-size: 22px;
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
        .ValText
        {
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 18px;
            color: #9B2346;
            font-style: italic;
        }
    </style>
</head>
<body>
    <form runat="server" id="Form1">
    <div id="wrapper">
        <div id="header">
            NEW PHYSICIAN
            <br />
            REQUEST
        </div>
        <!--end of header-->
        <div id="main">
            <div id="center">
                <span class="normal">Please complete the fields below.</span><br />
                <span class="redsmallitalic">* Required Field</span><br />
                <span class="normal">The CHRC will provide a status update<br />
                    within 1-2 business days</span>
            </div>
            <!--end of center-->
            <br />
            <br />
            <table width="70%" border="0" cellspacing="0" cellpadding="0" style="margin-left: auto;
                margin-right: auto">
                <tr>
                    <td class="italic">
                        FIRST NAME <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtFirstName" />
                        <asp:RequiredFieldValidator ErrorMessage="First Name required" ControlToValidate="txtFirstName"
                            runat="server" ID="reqtxtFirstName" CssClass="ValText" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        LAST NAME <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtLastName" />
                        <asp:RequiredFieldValidator ErrorMessage="Last Name required" ControlToValidate="txtLastName"
                            runat="server" ID="reqtxtLastName" CssClass="ValText" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        CLINIC NAME
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtClinic" />
                        <asp:RequiredFieldValidator ErrorMessage="Clinic required" ControlToValidate="txtClinic"
                            runat="server" ID="reqtxtClinic" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        ADDRESS
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtAddress" />
                        <asp:RequiredFieldValidator ErrorMessage="Address required" ControlToValidate="txtAddress"
                            runat="server" ID="reqtxtAddress" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        CITY <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtCity" />
                        <asp:RequiredFieldValidator ErrorMessage="City required" ControlToValidate="txtCity"
                            runat="server" ID="reqtxtCity" CssClass="ValText" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        PROVINCE <span style="color: #9B2346">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
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
                </tr>
                <tr>
                    <td class="italic">
                        POSTAL CODE
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtPostalCode" />
                        <asp:RequiredFieldValidator ErrorMessage="Postal Code required" ControlToValidate="txtPostalCode"
                            runat="server" ID="reqtxtPostalCode" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        PHONE
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtPhone" />
                        <asp:RequiredFieldValidator ErrorMessage="Phone required" ControlToValidate="txtPhone"
                            runat="server" ID="reqtxtPhone" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        FAX
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtFax" />
                        <asp:RequiredFieldValidator ErrorMessage="Fax required" ControlToValidate="txtFax"
                            runat="server" ID="reqtxtFax" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        EMAIL
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" />
                        <asp:RequiredFieldValidator ErrorMessage="Email required" ControlToValidate="txtEmail"
                            runat="server" ID="reqtxtEmail" CssClass="ValText" Enabled="false" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="italic">
                        COMMENTS
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Width="100%" Rows="5" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="grow" style="text-align: center">
                <asp:ImageButton ImageUrl="~/images/button_submit.png" runat="server" OnClick="imgSubmit_clicked"
                    ID="imgSubmit" />
            </div>
        </div>
        <!--end of main-->
        <div id="footer">
        </div>
        <!--end of footer-->
    </div>
    </form>
</body>
</html>
