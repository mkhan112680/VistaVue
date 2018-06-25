<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="VistaDM.Admin.Account.Login" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,700,300italic'
        rel='stylesheet' type='text/css'>
    <style type="text/css">
        #wrapper
        {
            width: 620px;
            margin: 0 auto;
        }
        
        #main
        {
            background-color: #DEDFE0;
            width: 602px;
            margin-right: auto;
            margin-left: auto;
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
        #footer
        {
            background-image: url(images/form_footer.png);
            background-repeat: no-repeat;
            height: 50px;
            width: 602px;
            margin-right: auto;
            margin-left: auto;
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
            margin: 20px auto;
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
    </style>
    <div id="wrapper">
        <div id="loginheader">
            ALLIANCE LOGIN
        </div>
        <!--end of header-->
        <div id="main">
            <table width="70%" border="0" style="margin-left: auto; margin-right: auto">
                <tr>
                    <td>
                        <div class="username">
                            <asp:TextBox runat="server" placeholder="Username" ID="txtUsername" />
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
                            <asp:TextBox runat="server" ID="txtPass" placeholder="Password" />
                        </div>
                    </td>
                </tr>
            </table>
            <div class="grow" style="padding-left: 80px; padding-top: 30px; padding-bottom: 30px">
                <asp:ImageButton ImageUrl="~/images/button_login.png" runat="server" ID="imgLogin"
                    OnClick="imgLogin_clicked" />
            </div>
            <table width="85%" border="0" style="margin-left: auto; margin-right: auto">
                <tr>
                    <td width="17%">
                        <div class="squaredThree">
                            <input type="checkbox" value="None" id="squaredThree" name="check" />
                            <label for="squaredThree">
                            </label>
                        </div>
                    </td>
                    <td width="83%" class="radialtext">
                        Remember Me
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="squaredThree">
                            <input type="checkbox" value="None" id="squaredThree" name="check" />
                            <label for="squaredThree">
                            </label>
                        </div>
                    </td>
                    <td class="radialtext">
                        Forgot Your Password?
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
        </div>
        <!--end of main-->
        <div class="whitetext" style="background-image: url(images/redbar3.png); background-repeat: no-repeat;
            padding-top: 20px; text-align: center; height: 40px">
            NEW REGISTRATION</div>
        <div id="main">
            <br />
            <br />
            <div class="grow" style="text-align: center">
                <img src="images/button_registernow_large.png" /></div>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
