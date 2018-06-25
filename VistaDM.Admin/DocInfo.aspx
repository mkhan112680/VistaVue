<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocInfo.aspx.cs" Inherits="VistaDM.Admin.DocInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Untitled Document</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic' rel='stylesheet' type='text/css'/>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,700,300italic' rel='stylesheet' type='text/css'/>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.11.0.min.js" type="text/javascript"></script>
    <style type="text/css">
        #wrapper {
            width: 609px;
            margin: 0 auto;
        }

        #header {
            background-image: url(images/form_header.png);
            background-repeat: no-repeat;
            font-family: 'Open Sans Condensed', sans-serif;
            font-weight: 700;
            color: #FFF;
            font-size: 24px;
            padding-top: 15px;
            padding-bottom: 10px;
            text-align: center;
            line-height: 25px;
        }

        #main {
            background-color: #DEDFE0;
            width: 602px;
        }

        #footer {
            background-image: url(images/form_footer.png);
            background-repeat: no-repeat;
            height: 50px;
        }

        #center {
            text-align: center;
            width: 100%;
        }

        .italic {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 19px;
            font-style: italic;
            color: #666;
        }

        .normal {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 19px;
            font-weight: 700;
            color: #414042;
        }

        .redsmallitalic {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 18px;
            color: #9B2346;
            font-style: italic;
        }

        textarea {
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
            width: 89%;
            height: 80px;
            padding-left: 20px;
            padding-right: 20px;
            padding-top: 10px;
        }

        input[type=text] {
            width: 96%;
            height: 32px;
            padding-left: 20px;
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }

            input[type=text]:focus {
                border-color: #333;
            }

        input[type=submit] {
            padding: 5px 15px;
            background: #ccc;
            border: 0 none;
            cursor: pointer;
            -webkit-border-radius: 5px;
            border-radius: 5px;
        }

        .grow img {
            transition: .5s ease;
        }

            .grow img:hover {
                -webkit-transform: scale(1.1);
                -ms-transform: scale(1.1);
                transform: scale(1.1);
                transition: .5s ease;
            }

        select {
            width: 100%;
            height: 32px;
            padding-left: 20px;
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }

        input[type=checkbox] {
            visibility: hidden;
        }

        input[type=radio] {
            visibility: hidden;
        }

        /* SQUARED THREE */
        .squaredThree {
            /*
            width: 20px;
            */
            margin: auto;
            position: relative;
        }

            .squaredThree label {
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

                .squaredThree label:after {
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

                .squaredThree label:hover::after {
                    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=30)";
                    filter: alpha(opacity=30);
                    opacity: 0.3;
                }

            .squaredThree input[type=checkbox]:checked + label:after {
                -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
                filter: alpha(opacity=100);
                opacity: 1;
            }

            .squaredThree input[type=radio]:checked + label:after {
                -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
                filter: alpha(opacity=100);
                opacity: 1;
            }

        #invitationbox {
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

        #invitationbox2 {
            background: #EDEDED;
            -moz-box-shadow: inset 0px 0px 5px 0px rgb(128,128,128);
            -webkit-box-shadow: inset 0px 0px 5px 0px rgb(128,128,128);
            box-shadow: inset 0px 0px 5px 0px rgb(128,128,128);
            margin: 10px;
            border-radius: 14px;
            border: 1px #999 solid;
            text-align: center;
        }

        .ValText {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 18px;
            color: #9B2346;
            font-style: italic;
        }
    </style>
</head>
<body>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#chkEnglish').change(function () {

                if ($(this).is(':checked')) {

                    $('#<%=chkFrench.ClientID %>').prop('checked', false);

                }

            });

            $('#chkFrench').change(function () {

                if ($(this).is(':checked')) {

                    $('#<%=chkEnglish.ClientID %>').prop('checked', false);

                }
            });

        });
    </script>
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
                <table width="70%" border="0" cellspacing="0" cellpadding="0" style="margin-left: auto; margin-right: auto">

                    <tr>
                        <td colspan="6" class="italic">Physician Type 
                        <asp:Label runat="server" ID="lblType" ForeColor="Green" Font-Bold="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" class="italic">&nbsp;
                        </td>
                    </tr>

                     <tr runat="server" id="trUserName">
                        <td colspan="6" class="italic">UserName
                        <asp:Label runat="server" ID="lblUserName" ForeColor="Green" Font-Bold="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" class="italic">&nbsp;
                        </td>
                    </tr>


                    <tr>
                        <td colspan="3" class="italic">FIRST NAME <span style="color: #9B2346">*</span>
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
                        <td width="78%">&nbsp;
                        </td>
                        <td width="11%">&nbsp;
                        </td>
                        <td width="11%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">LAST NAME <span style="color: #9B2346">*</span>
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">CLINIC NAME
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">ADDRESS
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">CITY <span style="color: #9B2346">*</span>
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">PROVINCE <span style="color: #9B2346">*</span>
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">POSTAL CODE
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">PHONE
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">FAX
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">EMAIL
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
                                <asp:CheckBox Text="" runat="server" ID="squaredThree" Enabled="false" />
                                <%--<input type="checkbox" value="None" id="squaredThree" name="check" />--%>&nbsp;
                            <label for="squaredThree">
                            </label>
                            </div>
                        </td>
                        <td class="italic" align="right">OPT-IN
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="italic">UNIQUE ID
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
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" class="italic">BI Territory ID
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtBI" />
                            <asp:CompareValidator ID="comptxtBI" runat="server" Operator="DataTypeCheck" Type="Integer"
                                ControlToValidate="txtBI" ForeColor="Red" Display="Dynamic"
                                ErrorMessage="Must be number" CssClass="ValText"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>


                    <tr>
                        <td colspan="3" class="italic">Lilly ID
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtLilly" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>

                     

                    <tr>
                        <td colspan="3" class="italic">COMMENTS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Width="100%" Rows="5" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <fieldset>
                                <legend class="ValText">Added By :
                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td class="italic">Your FirstName</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblFN" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="italic">Your LastName</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblLN" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="italic">Your Email</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblAdderEmail" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>



                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
                <div class="grow" style="text-align: center">
                    <asp:ImageButton ImageUrl="~/images/button_update.png" runat="server" OnClick="btnSubmit_clicked"
                        ID="btnSubmit" />
                </div>
                <br />
                <br />
                <asp:Panel runat="server" ID="pnlEmail">
                    <div id="invitationbox">

                        <div id="invitationbox2">
                            <br />
                            <span class="normal" style="color: #9B2346">SEND INVITATION BY EMAIL</span>
                            <br />
                            <br />
                            <%-- <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC; width: 100%">
                        </div>
                        <br />
                        <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left; margin-left: auto; margin-right: auto">
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmailFrom_Send" placeholder="Physician's Email" />
                                    <asp:RequiredFieldValidator ID="reqtxtEmailFrom_Send" ErrorMessage="Physician Email Required"
                                        ControlToValidate="txtEmailFrom_Send" runat="server" ValidationGroup="SendEmail"
                                        Display="Dynamic" CssClass="ValText" />
                                </td>
                            </tr>
                        </table>--%>
                            <br />
                            <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC; width: 100%">
                            </div>
                            <br />
                            <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left; margin-left: auto; margin-right: auto">
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtEmailTo_Send" placeholder="Physician's Email" />
                                        <asp:RequiredFieldValidator ID="reqtxtEmailTo_Send" ErrorMessage="Physician Email Required"
                                            ControlToValidate="txtEmailTo_Send" runat="server" ValidationGroup="SendEmail"
                                            Display="Dynamic" CssClass="ValText" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left; margin-left: auto; margin-right: auto">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblInvResult" />
                                    </td>
                                </tr>
                            </table>
                            <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC; width: 100%">
                            </div>
                            <br />
                            <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left; margin-left: auto; margin-right: auto">
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtEmailMssg_Send" placeholder="Message" Rows="3"
                                            TextMode="MultiLine" />
                                        <asp:RequiredFieldValidator ID="reqtxtEmailMssg_Send" ErrorMessage="Comments Required"
                                            ControlToValidate="txtEmailMssg_Send" runat="server" ValidationGroup="SendEmail"
                                            Display="Dynamic" CssClass="ValText" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <div style="border-top-style: solid; border-top-width: 1px; border-top-color: #CCC; width: 100%">
                            </div>
                            <br />
                            <table width="70%" border="0" cellpadding="0" cellspacing="0" style="text-align: left; margin-left: auto; margin-right: auto">
                                <tr>
                                    <td>
                                        <table width="100%" border="0">
                                            <tr>
                                                <td width="50%" class="italic">SEND INVITATION IN:
                                                </td>
                                                <td width="30%">
                                                    <div class="squaredThree">
                                                        <asp:CheckBox runat="server" ID="chkEnglish" ClientIDMode="Static" />
                                                        <label for="chkEnglish">
                                                        </label>
                                                    </div>
                                                </td>
                                                <td width="20%" class="italic">ENGLISH
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td>
                                                    <div class="squaredThree">
                                                        <asp:CheckBox runat="server" ID="chkFrench" ClientIDMode="Static" />
                                                        <label for="chkFrench">
                                                        </label>
                                                    </div>
                                                </td>
                                                <td class="italic">FRANÇAIS
                                                </td>
                                            </tr>
                                        </table>
                                </tr>
                            </table>
                            <br />
                        </div>
                        <!--end of invitation box2-->

                        <div class="grow" style="text-align: center">
                            <asp:Label runat="server" ID="lblResult" CssClass="ValText" />
                        </div>

                        <div class="grow" style="text-align: center">
                            <asp:LinkButton runat="server" ID="lbtnSendEmail" OnClick="lbtnSendEmail_clicked"
                                ValidationGroup="SendEmail">
                        <img src="images/button_send.png" />
                            </asp:LinkButton>
                        </div>


                    </div>
                </asp:Panel>
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
