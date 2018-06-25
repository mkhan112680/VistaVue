﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdminLogin.aspx.cs" Inherits="VistaDM.Admin.AdminLogin" %>

<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,700,300italic'
        rel='stylesheet' type='text/css'>
    <style type="text/css">
        html
        {
            font-family: 'Open Sans' , sans-serif;
            background: url(images/gray_background.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }
        *
        {
            margin: 0;
            padding: 0;
        }
        #centerbox
        {
            width: 1100px;
            margin-right: auto;
            margin-left: auto;
        }
        #header
        {
            background-color: #FFF;
            width: 100%;
            padding-top: 20px;
        }
        #redbar
        {
            background-image: url(images/redbar_sides.png);
            background-repeat: repeat-x;
            width: 100%;
            text-align: center;
        }
        #maincontent
        {
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
        #leftbox
        {
            margin: 10px;
            float: left;
            width: 350px;
        }
        #navcontainer
        {
            background-image: url(images/nav_background.png);
            padding-top: 80px;
            background-repeat: no-repeat;
            padding-bottom: 30px;
        }
        #navcontainer2
        {
            background-image: url(images/nav_background2.png);
            padding-top: 80px;
            background-repeat: no-repeat;
            padding-bottom: 30px;
        }
        #navcontainer3
        {
            background-image: url(images/nav_background3.png);
            padding-top: 80px;
            background-repeat: no-repeat;
            padding-bottom: 30px;
        }
        #navboxes
        {
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
        #rightbox
        {
            float: right;
            width: 660px;
            margin-top: 10px;
            margin-right: 20px;
        }
        #footer
        {
            background-color: #9B2346;
            padding-top: 20px;
            padding-bottom: 40px;
        }
        .welcometext
        {
            color: #9B2346;
            font-weight: 700;
            font-size: 20px;
        }
        .smallgrey
        {
            color: #666;
            font-size: 12px;
            font-style: italic;
            vertical-align: top;
        }
        .smallgrey a:link
        {
            color: #666;
            font-size: 12px;
            font-style: italic;
            vertical-align: top;
        }
        .smallgrey a:visited
        {
            color: #666;
            font-size: 12px;
            font-style: italic;
            vertical-align: top;
        }
        .smallgrey a:hover
        {
            text-decoration: underline;
            color: #333;
            vertical-align: top;
        }
        .smallgrey a:active
        {
            color: #666;
            font-size: 12px;
            font-style: italic;
            vertical-align: top;
        }
        .smallwhite
        {
            color: #FFF;
            font-size: 10px;
            vertical-align: top;
            text-decoration: none;
        }
        .smallwhite a:link
        {
            color: #FFF;
            font-size: 10px;
            vertical-align: top;
            text-decoration: none;
        }
        .smallwhite a:visited
        {
            color: #FFF;
            font-size: 10px;
            vertical-align: top;
            text-decoration: none;
        }
        .smallwhite a:hover
        {
            text-decoration: underline;
            color: #FFF;
            vertical-align: top;
        }
        .smallwhite a:active
        {
            color: #FFF;
            font-size: 10px;
            vertical-align: top;
            text-decoration: none;
        }
        .white
        {
            color: #FFF;
        }
        .condensedfont
        {
            font-family: 'Open Sans Condensed' , sans-serif;
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
        .greycondensed
        {
            font-size: 12px;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #333;
        }
        .greycondensed a:link
        {
            font-size: 12px;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #333;
            text-decoration: underline;
        }
        .greycondensed a:visted
        {
            font-size: 12px;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #333;
            text-decoration: underline;
        }
        .greycondensed a:hover
        {
            font-size: 12px;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #9B2346;
            text-decoration: underline;
        }
        .greycondensed a:active
        {
            font-size: 12px;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #333;
            text-decoration: underline;
        }
        #loginwrapper
        {
            width: 620px;
            margin-left: auto;
            margin-right: auto;
        }
        #loginheader
        {
            background-image: url(images/form_header.png);
            background-repeat: no-repeat;
            font-family: 'Open Sans Condensed' , sans-serif;
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
        #loginmain
        {
            background-color: #DEDFE0;
            width: 602px;
            margin-right: auto;
            margin-left: auto;
        }
        #loginfooter
        {
            background-image: url(images/form_footer.png);
            background-repeat: no-repeat;
            height: 50px;
            width: 602px;
            margin-right: auto;
            margin-left: auto;
        }
        select
        {
            width: 100%;
            height: 32px;
            padding-left: 20px;
            border: 1px solid #aaa;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }
        .username input
        {
            width: 100%;
            height: 32px;
            background: #fcfcfc;
            background-image: url(images/input_username.png);
            background-size: 30px 30px;
            background-repeat: no-repeat;
            padding-left: 20px;
            border: 1px solid #aaa;
            border-radius: 5px;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }
        .username input
        {
            text-indent: 15px;
        }
        .password input
        {
            width: 100%;
            height: 32px;
            background: #fcfcfc;
            background-image: url(images/input_password.png);
            background-size: 30px 30px;
            background-repeat: no-repeat;
            padding-left: 20px;
            border: 1px solid #aaa;
            border-radius: 5px;
            box-shadow: 0 0 3px #ccc, 0 10px 15px #ebebeb inset;
        }
        .password input
        {
            text-indent: 15px;
        }
        ::-webkit-input-placeholder
        {
            /* WebKit browsers */
            color: #2E4C58;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 15px;
            font-weight: 700;
            line-height: 10px;
        }
        :-moz-placeholder
        {
            /* Mozilla Firefox 4 to 18 */
            color: #2E4C58;
            opacity: 1;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 15px;
            font-weight: 700;
        }
        ::-moz-placeholder
        {
            /* Mozilla Firefox 19+ */
            color: #2E4C58;
            opacity: 1;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 15px;
            font-weight: 700;
        }
        :-ms-input-placeholder
        {
            /* Internet Explorer 10+ */
            color: #2E4C58;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 15px;
            font-weight: 700;
        }
        .radialtext
        {
            color: #2E4C58;
            font-family: 'Open Sans Condensed' , sans-serif;
            font-size: 24px;
            font-weight: 700;
            line-height: 10px;
        }
        .whitetext
        {
            font-family: 'Open Sans Condensed' , sans-serif;
            font-weight: 700;
            color: #FFF;
            font-size: 24px;
        }
        input[type=checkbox]
        {
            visibility: hidden;
        }
        /* SQUARED THREE */.squaredThree
        {
            width: 20px;
            margin: 7px auto;
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
        .ValText
        {
            font-family: 'Open Sans Condensed' , sans-serif;
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
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
</script>
    <div id="maincontent">
        <br />
        <br />
        <br />
        <br />
        <asp:Panel runat="server" DefaultButton="lbtnLogin">
            <div id="loginwrapper">
                <div id="loginheader">
                    CHRC LOGIN
                </div>
                <!--end of header-->
                <div id="loginmain">
                    <table width="70%" border="0" style="margin-left: auto; margin-right: auto">
                        <tr>
                            <td>
                                <div class="username">
                                    <asp:TextBox runat="server" placeholder="Username" ID="txtUsername" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Username Required"
                                        ControlToValidate="txtUsername" runat="server" CssClass="ValText" Display="Dynamic" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="password">
                                    <asp:TextBox runat="server" ID="txtPass" placeholder="Password" TextMode="Password" />
                                    <asp:RequiredFieldValidator ID="reqtxtPass" ErrorMessage="Password Required" ControlToValidate="txtPass"
                                        runat="server" CssClass="ValText" Display="Dynamic" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="password">
                                    <asp:Label Text="Invalid Username/Password" runat="server" ID="lblResult" CssClass="ValText"
                                        Visible="false" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="grow" style="padding-top: 30px; padding-bottom: 30px; text-align: center">
                        <asp:LinkButton Text="text" runat="server" OnClick="imgLogin_clicked" ID="lbtnLogin">
                    <img src="images/button_login.png" />
                        </asp:LinkButton>
                    </div>
                </div>
                <!--end of main-->
                <div id="loginfooter">
                </div>
                <!--end of footer-->
            </div>
        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
