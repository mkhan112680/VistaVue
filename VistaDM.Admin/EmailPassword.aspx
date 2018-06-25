<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailPassword.aspx.cs" Inherits="VistaDM.Admin.EmailPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,400italic' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300,700,300italic' rel='stylesheet' type='text/css' />
    <style type="text/css">
        body {
            background-color: #9B2346;
        }

        #content {
            margin-right: auto;
            margin-left: auto;
            font-family: 'Open Sans', sans-serif;
            width: 620px;
            margin-top: 50px;
            margin-bottom: 50px;
            text-align: left;
            background-image: url(images/forgotpassword.png);
            height: 320px;
            padding: 0px;
            font-size: 14px;
            background-repeat: no-repeat;
        }

        a:link {
            color: #900;
            font-weight: 600;
        }

        a:visited {
            color: #900;
            font-weight: 600;
        }

        a:hover {
            color: #900;
            font-weight: 600;
        }

        a:active {
            color: #900;
            font-weight: 600;
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

        .italic {
            font-family: 'Open Sans Condensed', sans-serif;
            font-size: 19px;
            font-style: italic;
            color: #666;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div id="content">
                <br />
                <br />
                <div style="text-align: right; padding: 6px">
                    <asp:Image ImageUrl="~/images/button_close.png" runat="server" />
                </div>

                <asp:Panel runat="server" ID="pnlMain">
                    <div style="padding: 0px 50px 0px 50px">
                        <table width="100%" border="0">
                            <tr>
                                <td class="italic">PLEASE ENTER USERNAME (YOUR EMAIL)</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtusername" />
                                    <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtusername" runat="server" ForeColor="Red" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="grow">
                                        <asp:Label ID="lblResult" runat="server"   ForeColor="Red" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="grow">
                                        <asp:ImageButton ID="imgBtn" OnClick="imgBtn_clicked" runat="server" ImageUrl="~/images/button_submit2.png" />
                                    </div>
                                </td>
                            </tr>

                        </table>
                    </div>
                </asp:Panel>

                <asp:Panel runat="server" ID="pnlEmailed" Visible="false">
                    <div style="font-size: 24px; font-weight: 700; text-align: center;">
                        <p>
                            Your password has been emailed.
                        </p>
                        <p>Please check your inbox</p>
                    </div>
                </asp:Panel>

            </div>

        </div>
    </form>
</body>
</html>






