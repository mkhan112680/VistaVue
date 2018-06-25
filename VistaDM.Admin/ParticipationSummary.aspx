<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParticipationSummary.aspx.cs"
    Inherits="VistaDM.Admin.ParticipationSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Untitled Document</title>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,700,300italic" rel="stylesheet" type="text/css" />
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

        #contentbox {
            text-align: left;
            width: 80%;
            margin-left: auto;
            margin-right: auto;
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

        .normalshadow {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 24px;
            font-weight: 700;
            color: #000;
            text-shadow: 2px 2px #FFF;
        }

        .normalsmall {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 19px;
        }

        .redbold {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 20px;
            color: #9B2346;
            font-weight: 700;
        }

        .bolditalic {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 16px;
            font-style: italic;
            font-weight: 700;
            color: #9B2346;
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
        /* SQUARED THREE */
        .squaredThree {
            width: 20px;
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

        .green {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 14px;
            color: #393;
            font-weight: 700;
        }
    </style>
</head>
<body>
    <form id="Form" runat="server">
        <div id="wrapper">
            <div style="text-align: center;">
                <asp:Label CssClass="normalshadow" runat="server" Text="NOT completed" ID="lblNotImplemented" ForeColor="Red" Font-Bold="true" />
            </div>
            <div id="header">
                PARTICIPATION
            <br />
                SUMMARY
            </div>
            <!--end of header-->
            <div id="main">
                <div id="contentbox">
                    <span class="normalshadow">PHYSICIAN SPECIFIC REQUIREMENTS</span>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-color: #999; border-width: 1px; border-style: solid">
                        <tr>
                            <td width="70%" bgcolor="#FCFCFC" class="normal" style="padding: 3px">MOU:
                            </td>
                            <td width="30%" bgcolor="#FCFCFC" style="text-align: right; padding: 3px 10px 3px 3px"
                                class="green">
                                <asp:Label Text="text" runat="server" ID="lbl_MOU_PCP" />
                            </td>
                        </tr>
                        <tr height="8px">
                            <td bgcolor="#CCCCCC"></td>
                            <td bgcolor="#CCCCCC"></td>
                        </tr>
                        <tr>
                            <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">Payee Form:
                            </td>
                            <td width="30%" bgcolor="#FCFCFC" style="text-align: right; padding: 3px 10px 3px 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px"
                                class="green">
                                <asp:Label Text="text" runat="server" ID="lbl_Payee_PCP" />
                            </td>
                        </tr>
                        <tr height="8px">
                            <td bgcolor="#CCCCCC"></td>
                            <td bgcolor="#CCCCCC"></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel runat="server" ID="pnlPCP">

                        <span class="normalshadow">VISTA DM ACTION ITEMS</span>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-color: #999; border-width: 1px; border-style: solid">
                            <tr>
                                <td width="70%" bgcolor="#FCFCFC" class="normal" style="padding: 3px">Needs Assessment:
                                </td>
                                <td width="30%" bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">
                                    <asp:Label Text="text" runat="server" ID="lbl_Needs_PCP"  />
                                </td>
                            </tr>
                             <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">
                                    <asp:Label   runat="server" ID="lblNeedsAsses_Renum" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">PAF #1:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">
                                    <asp:Label Text="text" runat="server" ID="lbl_PAF1_PCP" />
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">
                                    <asp:Label   runat="server" ID="remun_PAF1" />
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">PAF #1 Re-Assessment:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">NOT completed
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">NOT completed
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-color: #999; border-width: 1px; border-style: solid">
                            <tr>
                                <td width="70%" bgcolor="#FCFCFC" class="normal" style="padding: 3px">Patient Survey:
                                </td>
                                <td width="30%" bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right">
                                    <asp:Label   runat="server" ID="lblPatientSurvey_Renum" />
                                    
                                </td>
                            </tr>
                            <%--<tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">
                                    <asp:Label   runat="server" ID="lblPatientSurvey" />     
                                </td>
                            </tr>--%>
                            <tr height="8px">
                                <td bgcolor="#CCCCCC"></td>
                                <td bgcolor="#CCCCCC"></td>
                            </tr>
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">PAF #2:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">NOT completed
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">NOT completed
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">PAF #2 Re-Assessment A:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">NOT completed
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">NOT completed
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">PAF #2 Re-Assessment B:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">NOT completed
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">NOT completed
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-color: #999; border-width: 1px; border-style: solid">
                            <tr>
                                <td width="70%" bgcolor="#FCFCFC" class="normal" style="padding: 3px">Evaluation:
                                </td>
                                <td width="30%" bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right">NOT completed
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">NOT completed
                                </td>
                            </tr>
                        </table>
                        <br />
                        <span class="normalshadow">VISTA DM RESOURCES</span>
                        <br />
                        <br />
                        <span class="redbold">Virtual Patient Cases:</span><br />
                        <br />
                        <span class="redbold">On-Demand Webinars:</span><br />
                        <br />
                        <span class="redbold">Townhall Meetings:</span><br />
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:Panel runat="server" ID="pnlCS">

                        <span class="normalshadow">VISTA DM ACTION ITEMS</span>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-color: #999; border-width: 1px; border-style: solid">
                            <tr>
                                <td width="70%" bgcolor="#FCFCFC" class="normal" style="padding: 3px">Needs Assessment:
                                </td>
                                <td width="30%" bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">NOT COMPLETED
                                </td>
                            </tr>
                           
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">PAF #1:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">NOT COMPLETED
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">STATUS
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-color: #999; border-width: 1px; border-style: solid">
                            <tr>
                                <td width="70%" bgcolor="#FCFCFC" class="normal" style="padding: 3px">Patient Survey:
                                </td>
                                <td width="30%" bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right">
                                
                                </td>
                            </tr>

                             <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">
                                     
                                </td>
                            </tr>

                            <tr height="8px">
                                <td bgcolor="#CCCCCC"></td>
                                <td bgcolor="#CCCCCC"></td>
                            </tr>
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">Focus Group Meeting:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">STATUS
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">STATUS
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">Newsletter:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">NOT COMPLETED
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">STATUS
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FCFCFC" class="normal" style="padding: 3px; border-top-color: #999; border-top-style: solid; border-top-width: 1px">PAF #2:
                                </td>
                                <td bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right; border-top-color: #999; border-top-style: solid; border-top-width: 1px">NOT COMPLETED
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#CCCCCC" class="bolditalic" style="padding: 3px;">Remuneration Status:
                                </td>
                                <td bgcolor="#CCCCCC" class="green" style="padding: 3px 10px 3px 3px; text-align: right;">STATUS
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-color: #999; border-width: 1px; border-style: solid">
                            <tr>
                                <td width="70%" bgcolor="#FCFCFC" class="normal" style="padding: 3px">Evaluation:
                                </td>
                                <td width="30%" bgcolor="#FCFCFC" class="green" style="padding: 3px 10px 3px 3px; text-align: right">NOT COMPLETED
                                </td>
                            </tr>
                            <tr height="8px">
                                <td bgcolor="#CCCCCC"></td>
                                <td bgcolor="#CCCCCC"></td>
                            </tr>
                        </table>
                        <br />
                        <span class="normalshadow">VISTA DM RESOURCES</span>
                        <br />
                        <br />
                        <span class="redbold">On-Demand Webinars:</span><br />
                        <br />
                        <span class="redbold">Townhall Meetings:</span>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
                <!--end of contentbox-->
            </div>
            <!--end of main-->
            <div id="footer">
            </div>
            <!--end of footer-->
        </div>
        <!--end of wrapper-->
    </form>
</body>
</html>
