﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SelectProgram.aspx.cs" Inherits="VistaDM.Admin.SelectProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic' rel='stylesheet'
        type='text/css'>
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
            padding-bottom: 30px;
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
        <div style="background-image: url(images/select_program_background.png); background-repeat: no-repeat;
            width: 710px; height: 200px; margin-left: auto; margin-right: auto; padding-top: 150px">
            <table width="80%" border="0" cellpadding="3" style="margin-left: auto; margin-right: auto;">
                <tr>
                    <td class="grow">
                        <asp:HyperLink NavigateUrl="~/SelectRegion.aspx?IS_PCP=1" runat="server" ID="hlPCP">
                            <img src="images/button_program_PCP.png" border="0" />
                        </asp:HyperLink>
                    </td>
                    <td class="grow">
                        <asp:HyperLink NavigateUrl="~/SelectRegion.aspx?IS_PCP=0" runat="server" ID="hlCS">
                            <img src="images/button_program_CS.png" border="0" />
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
