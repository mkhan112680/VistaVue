<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="VistaDM.Admin.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,700,300italic'
        rel='stylesheet' type='text/css'>
    <style type="text/css">
        html {
            font-family: 'Open Sans', sans-serif;
            background: url(images/gray_background.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        * {
            margin: 0;
            padding: 0;
        }

        #centerbox {
            width: 1100px;
            margin-right: auto;
            margin-left: auto;
        }

        #header {
            background-color: #FFF;
            width: 100%;
            padding-top: 20px;
        }

        #redbar {
            background-image: url(images/redbar_sides.png);
            background-repeat: repeat-x;
            width: 100%;
            text-align: center;
        }

        #maincontent {
            width: 1100px;
            margin-right: auto;
            margin-left: auto;
            border-right-width: thin;
            border-left-width: thin;
            border-right-style: solid;
            border-left-style: solid;
            border-right-color: #CCC;
            border-left-color: #CCC;
            box-shadow: 0px 5px 10px #CCC;
            text-align: center;
            background-color: #FFF;
        }

        #leftbox {
            margin: 10px;
            float: left;
            width: 350px;
        }

        #navcontainer {
            background-image: url(images/nav_background.png);
            padding-top: 80px;
            background-repeat: no-repeat;
            padding-bottom: 30px;
        }

        #navcontainer2 {
            background-image: url(images/nav_background2.png);
            padding-top: 80px;
            background-repeat: no-repeat;
            padding-bottom: 30px;
        }

        #navcontainer3 {
            background-image: url(images/nav_background3.png);
            padding-top: 80px;
            background-repeat: no-repeat;
            padding-bottom: 30px;
        }

        #navboxes {
            border-bottom-width: thin;
            border-bottom-style: dashed;
            border-bottom-color: #999;
            margin-right: 20px;
            margin-left: 20px;
            margin-top: 10px;
            margin-bottom: 10px;
            padding: 10px;
            font-weight: 700;
        }

        #rightbox {
            float: right;
            width: 660px;
            margin-top: 10px;
            margin-right: 20px;
        }

        #footer {
            background-color: #9B2346;
            padding-top: 20px;
            padding-bottom: 30px;
        }

        .welcometext {
            color: #9B2346;
            font-weight: 700;
            font-size: 20px;
        }

        .smallgrey {
            color: #666;
            font-size: 12px;
            font-style: italic;
            vertical-align: top;
        }

            .smallgrey a:link {
                color: #666;
                font-size: 12px;
                font-style: italic;
                vertical-align: top;
            }

            .smallgrey a:visited {
                color: #666;
                font-size: 12px;
                font-style: italic;
                vertical-align: top;
            }

            .smallgrey a:hover {
                text-decoration: underline;
                color: #333;
                vertical-align: top;
            }

            .smallgrey a:active {
                color: #666;
                font-size: 12px;
                font-style: italic;
                vertical-align: top;
            }

        .smallwhite {
            color: #FFF;
            font-size: 10px;
            vertical-align: top;
            text-decoration: none;
        }

            .smallwhite a:link {
                color: #FFF;
                font-size: 10px;
                vertical-align: top;
                text-decoration: none;
            }

            .smallwhite a:visited {
                color: #FFF;
                font-size: 10px;
                vertical-align: top;
                text-decoration: none;
            }

            .smallwhite a:hover {
                text-decoration: underline;
                color: #FFF;
                vertical-align: top;
            }

            .smallwhite a:active {
                color: #FFF;
                font-size: 10px;
                vertical-align: top;
                text-decoration: none;
            }

        .white {
            color: #FFF;
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

        #loginwrapper {
            width: 620px;
            margin-left: auto;
            margin-right: auto;
        }

        #loginheader {
            background-image: url(images/form_header.png);
            background-repeat: no-repeat;
            font-family: 'Open Sans Condensed', sans-serif;
            font-weight: 700;
            color: #FFF;
            font-size: 24px;
            padding-top: 25px;
            padding-bottom: 60px;
            text-align: center;
            margin-right: auto;
            margin-left: auto;
            width: 602px;
        }

        #loginmain {
            background-color: #DEDFE0;
            width: 602px;
            margin-right: auto;
            margin-left: auto;
            text-align: left;
        }

        #loginfooter {
            background-image: url(images/form_footer.png);
            background-repeat: no-repeat;
            height: 50px;
            width: 602px;
            margin-right: auto;
            margin-left: auto;
        }

        select {
            width: 100%;
            height: 32px;
            padding-left: 20px;
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
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


        input[type=password] {
            width: 96%;
            height: 32px;
            padding-left: 20px;
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }

            input[type=password]:focus {
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

        .italic {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 19px;
            font-style: italic;
            color: #666;
        }

        .italicred {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 19px;
            font-style: italic;
            color: #861B3B;
        }

        .normal {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 22px;
            font-weight: 700;
            color: #414042;
        }

        .redsmallitalic {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 18px;
            color: #9B2346;
            font-style: italic;
        }

        input[type=checkbox] {
            visibility: hidden;
        }
        /* SQUARED THREE */ .squaredThree {
            width: 17px;
            height: 17px;
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

        .smallbold {
            font-family: 'Open Sans', sans-serif;
            font-size: 14px;
            font-weight: 700;
            color: #2E4C58;
        }

        .smallestbold {
            font-family: 'Open Sans', sans-serif;
            font-size: 10px;
            font-weight: 700;
            color: #2E4C58;
        }

        .ValText {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 18px;
            color: #9B2346;
            font-style: italic;
        }
    </style>
    <script type="text/javascript">
        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }
        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }

        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2) ; i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
</script>
    <script type="text/javascript">


        var UnCheckAll = function () {

            $('#chkAll').attr('checked', false);
            
        }

        var UnCheckAllExceptAll = function(){

            $('#chkMB').attr('checked', false);
            $('#chkNB').attr('checked', false);
            $('#chkBC').attr('checked', false);
            $('#chkBC').attr('checked', false);
            $('#chkNL').attr('checked', false);
            $('#chkAB').attr('checked', false);
            $('#chkQC').attr('checked', false);
            $('#chkPEI').attr('checked', false);
            $('#chkSK').attr('checked', false);
            $('#chkNS').attr('checked', false);
            $('#chkON').attr('checked', false);
        }

        var EnableDisableExceptAll = function (enable) {


            if (enable) {

                $('#chkMB').removeAttr("disabled");
                $('#chkNB').removeAttr("disabled");
                $('#chkBC').removeAttr("disabled");
                $('#chkNL').removeAttr("disabled");
                $('#chkAB').removeAttr("disabled");
                $('#chkQC').removeAttr("disabled");
                $('#chkPEI').removeAttr("disabled");
                $('#chkSK').removeAttr("disabled");
                $('#chkNS').removeAttr("disabled");
                $('#chkON').removeAttr("disabled");
            }
            else {

                $('#chkMB').attr("disabled", true);
                $('#chkNB').attr("disabled", true);
                $('#chkBC').attr("disabled", true);
                $('#chkNL').attr("disabled", true);
                $('#chkAB').attr("disabled", true);
                $('#chkQC').attr("disabled", true);
                $('#chkPEI').attr("disabled", true);
                $('#chkSK').attr("disabled", true);
                $('#chkNS').attr("disabled", true);
                $('#chkON').attr("disabled", true);

            }

            
        }

        var HideControl = function (hide) {

            if (hide) {
                $('#chkAll').attr("disabled", true);
                $('#chkAll').attr('checked', false);

            }
            else {

                $('#chkAll').removeAttr("disabled");
                $('#chkAll').attr('checked', false);
            }

        };

        $(document).ready(function () {

            var selText = $('#<%=ddRole.ClientID %>').val();
            if (selText != '5') {
                $('#chkAll').attr("disabled", true);
            }
           


            $('#chkAll').change(function () {

                UnCheckAllExceptAll();
                
            });

            $('#chkMB').change(function () {

                UnCheckAll();

            });

            $('#chkNB').change(function () {

                UnCheckAll();

            });

            $('#chkBC').change(function () {

                UnCheckAll();

            });

            $('#chkNL').change(function () {

                UnCheckAll();

            });

            $('#chkAB').change(function () {

                UnCheckAll();

            });

            $('#chkQC').change(function () {

                UnCheckAll();

            });

            $('#chkPEI').change(function () {

                UnCheckAll();

            });

            $('#chkSK').change(function () {

                UnCheckAll();

            });

            $('#chkNS').change(function () {

                UnCheckAll();

            });

            $('#chkON').change(function () {

                UnCheckAll();

            });


            $('#<%=ddRole.ClientID %>').change(function () {

                UnCheckAllExceptAll();

                var selText = $('option:selected', this).text();

                if (selText == 'Head Office') {
                    
                    //EnableDisableExceptAll(false);
                    HideControl(false);
                    
                }
                else {
                    //EnableDisableExceptAll(true);
                    HideControl(true);
                }
            });

        });
    </script>

    <asp:Panel runat="server" DefaultButton="imgSubmit">
        <div id="maincontent">
            <br />
            <br />
            <br />
            <br />
            <div id="loginwrapper">
                <div id="loginheader">
                    REGISTRATION
                </div>
                <!--end of loginheader-->
                <div id="loginmain">
                    <table width="70%" border="0" cellspacing="0" cellpadding="0" style="margin-left: auto; margin-right: auto">
                        <tr>
                            <td class="italic">FIRST NAME <span style="color: #9B2346">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="txtFirst" />
                                <asp:RequiredFieldValidator CssClass="ValText" ErrorMessage="First Name Required"
                                    ControlToValidate="txtFirst" runat="server" Display="Dynamic" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="italic">LAST NAME <span style="color: #9B2346">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="txtLastname" />
                                <asp:RequiredFieldValidator CssClass="ValText" ID="reqtxtLastname" ErrorMessage="Last Name Required"
                                    ControlToValidate="txtLastname" runat="server" Display="Dynamic" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="italic">COMPANY <span style="color: #9B2346">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<select name="company">
                                <option value="Boehringer-Ingelheim">Boehringer-Ingelheim</option>
                                <option value="Eli Lilly">Eli Lilly</option>
                                <option value="Alliance">Alliance</option>
                            </select>--%>
                                <asp:DropDownList runat="server" ID="ddCompany">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cmpddCompany" runat="server" ControlToValidate="ddCompany"
                                    ValueToCompare="-1" ErrorMessage="error" Text="Company Required" Type="String"
                                    Operator="NotEqual" Display="Dynamic" CssClass="ValText">
                                </asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="italic">ROLE <span style="color: #9B2346">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<select name="role">
                                <option value="Specialty Representative">Specialty Representative</option>
                                <option value="Primary Care Representative">Primary Care Representative</option>
                                <option value="Specialty Sales Manager">Specialty Sales Manager</option>
                                <option value="Primary Care Sales Manager">Primary Care Sales Manager</option>
                                <option value="Head Office">Head Office</option>
                            </select>--%>
                                <asp:DropDownList runat="server" ID="ddRole">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cmpddRole" runat="server" ControlToValidate="ddRole" ValueToCompare="-1"
                                    ErrorMessage="error" Text="Role Required" Type="String" Operator="NotEqual" Display="Dynamic"
                                    CssClass="ValText">
                                </asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="italic">TERRITORY COVERAGE <span style="color: #9B2346">*</span> (CHECK ALL THAT APPLY)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0">
                                    <tr>
                                        <td width="9%" height="20px">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkAll" ClientIDMode="Static" />
                                                <label for="chkAll"></label>

                                            </div>
                                        </td>
                                        <td width="25%" height="20px">
                                            <span class="smallbold">ALL</span> <span class="smallestbold">(HEAD OFFICE)</span>
                                        </td>
                                        <td width="9%">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkMB" ClientIDMode="Static" />
                                                <label for="chkMB">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="24%" class="smallbold">MB
                                        </td>
                                        <td width="9%">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkNB" ClientIDMode="Static" />
                                                <label for="chkNB">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="24%" class="smallbold">NB
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" height="10px"></td>
                                    </tr>
                                    <tr>
                                        <td width="9%" height="20px">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkBC" ClientIDMode="Static" />
                                                <label for="chkBC">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="25%" height="20px">
                                            <span class="smallbold">BC</span>
                                        </td>
                                        <td width="9%">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkON" ClientIDMode="Static" />
                                                <label for="chkON">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="24%" class="smallbold">ON
                                        </td>
                                        <td width="9%">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkNL" ClientIDMode="Static" />
                                                <label for="chkNL">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="24%" class="smallbold">NL
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" height="10px"></td>
                                    </tr>
                                    <tr>
                                        <td width="9%" height="20px">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkAB" ClientIDMode="Static" />
                                                <label for="chkAB">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="25%" height="20px">
                                            <span class="smallbold">AB</span>
                                        </td>
                                        <td width="9%">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkQC" ClientIDMode="Static" />
                                                <label for="chkQC">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="24%" class="smallbold">QC
                                        </td>
                                        <td width="9%">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkPEI" ClientIDMode="Static" />
                                                <label for="chkPEI">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="24%" class="smallbold">PEI
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" height="10px"></td>
                                    </tr>
                                    <tr>
                                        <td width="9%" height="20px">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkSK" ClientIDMode="Static" />
                                                <label for="chkSK">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="25%" height="20px">
                                            <span class="smallbold">SK</span>
                                        </td>
                                        <td width="9%">
                                            <div class="squaredThree">
                                                <asp:CheckBox runat="server" ID="chkNS" ClientIDMode="Static" />
                                                <label for="chkNS">
                                                </label>
                                            </div>
                                        </td>
                                        <td width="24%" class="smallbold">NS
                                        </td>
                                        <td width="9%">&nbsp;
                                        </td>
                                        <td width="24%" class="smallbold">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center">
                                            <asp:Label ID="lblProReq" Text="At least one province required" runat="server" CssClass="ValText" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <div style="background-color: rgba(134, 27, 59, 0.2); width: 80%; margin-left: auto; margin-right: auto; padding-bottom: 20px; padding-top: 20px">
                        <table width="88%" border="0" cellspacing="0" cellpadding="0" style="margin-left: auto; margin-right: auto">
                            <tr>
                                <td class="italicred">USERNAME (YOUR EMAIL ADDRESS) <span style="color: #9B2346">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtUsername" />
                                    <asp:RequiredFieldValidator CssClass="ValText" ID="reqtxtUsername" ErrorMessage="User Name Required"
                                        ControlToValidate="txtUsername" runat="server" Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="italicred">PASSWORD <span style="color: #9B2346">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPass" TextMode="Password" Width="100%" Height="32px" />
                                    <asp:RequiredFieldValidator CssClass="ValText" ID="reqtxtPass" ErrorMessage="Password Required"
                                        ControlToValidate="txtPass" runat="server" Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="italicred">CONFIRM PASSWORD <span style="color: #9B2346">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPass2" TextMode="Password" Width="100%" Height="32px" />
                                    <asp:RequiredFieldValidator CssClass="ValText" ID="reqtxtPass2" ErrorMessage="Password Required"
                                        ControlToValidate="txtPass2" runat="server" Display="Dynamic" />
                                    <asp:CompareValidator CssClass="ValText" ID="PasswordCompare" runat="server" ControlToCompare="txtPass"
                                        ControlToValidate="txtPass2" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="grow" style="text-align: center">
                                        <asp:CustomValidator ErrorMessage="" ID="customVal" OnServerValidate="customVal_OnServerValidate"
                                            runat="server" Display="Dynamic" EnableClientScript="true" CssClass="ValText" />
                                        <asp:Label runat="server" ID="lblResult" CssClass="ValText" />
                                        <asp:LinkButton Text="text" runat="server" OnClick="imgSubmit_clicked" ID="imgSubmit">
                                <img src="images/button_completeRegistration.png" border="0"/>
                                        </asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                </div>
                <!--end of loginmain-->
                <div id="loginfooter">
                    <br />
                    <br />
                </div>
                <!--end of loginfooter-->
            </div>
            <!--end of loginwrapper-->
            <br />
            <br />
            <br />
            <br />
        </div>
    </asp:Panel>
</asp:Content>
