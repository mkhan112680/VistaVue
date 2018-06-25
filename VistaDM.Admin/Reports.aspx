<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="VistaDM.Admin.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <style type="text/css">
        input[type="submit"] {
            width: 150px;
            font-weight: bold;
        }
    </style>

    <asp:ImageButton ID="btnBack" OnClick="btnBack_clicked" ImageUrl="images/button_home.png" runat="server" />
    <asp:Panel runat="server" ID="pnlAdmin" HorizontalAlign="Center" Visible="false">

        <span>Alliance Registrations </span>
        <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgAlliance" OnClick="imgAlliance_clicked" />
        <br />

        <span>VISTA DM PCP Action Items</span>
        <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgPCPRegItems" OnClick="imgPCPRegItems_clicked" />

    </asp:Panel>
    <br />
    <br />

    <asp:Panel runat="server" ID="pnlProgram">
        <table width="200" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
            <tr>
                <td width="881" align="center" bgcolor="#9B2346" class="white">Select Program</td>
            </tr>
            <tr>
                <td width="881" align="center" bgcolor="#9B2346" class="white">
                    <asp:Panel runat="server" HorizontalAlign="Center">
                        <asp:ListBox runat="server" ID="lboxProgram" Width="300" Font-Bold="true" Font-Size="Large" Rows="3">
                            <asp:ListItem Text="PCP" Value="1"></asp:ListItem>
                            <asp:ListItem Text="CS" Value="2"></asp:ListItem>
                        </asp:ListBox>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td width="881" align="center" bgcolor="#9B2346" class="white">
                    <asp:Button Text="Select" runat="server" ID="btnProgram" OnClick="btnProgram_clicked" />
                </td>
            </tr>
        </table>

    </asp:Panel>

    <br />

    <asp:Panel runat="server" ID="pnlPCP">
        <table width="95%" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
            <tr>
                <td colspan="5" align="center" bgcolor="#9B2346"><span style="font-weight: 700; font-size: 28px; color: #FFF">VISTA DM Primary Care Program at a Glance</span></td>
            </tr>
            <tr class="smallbold">
                <td width="200" bgcolor="#000000" class="smallbold2white" style="color: white">Province</td>
                <td width="200" bgcolor="#000000" class="smallbold2white" style="color: white">Invited</td>
                <td width="200" bgcolor="#000000" class="smallbold2white" style="color: white">Registered</td>
                <td width="200" bgcolor="#000000" class="smallbold2white" style="color: white">ePAF</td>
                <td width="200" bgcolor="#000000" class="smallbold2white" style="color: white">eMAF</td>
            </tr>
            <tr bgcolor="#F4F4F4" class="smallbold2">
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="smallbold2">
                <td class="mainTable">BC</td>
                <td>
                    <asp:Label ID="lbl_BC_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_BC_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_BC_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_BC_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">AB</td>
                <td>
                    <asp:Label ID="lbl_AB_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_AB_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_AB_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_AB_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">SK</td>
                <td>
                    <asp:Label ID="lbl_SK_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_SK_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_SK_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_SK_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">MB</td>
                <td>
                    <asp:Label ID="lbl_MB_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_MB_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_MB_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_MB_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">ON</td>
                <td>
                    <asp:Label ID="lbl_ON_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_ON_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_ON_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_ON_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">QC</td>
                <td>
                    <asp:Label ID="lbl_QC_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_QC_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_QC_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_QC_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">NB</td>
                <td>
                    <asp:Label ID="lbl_NB_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NB_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NB_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NB_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">NS</td>
                <td>
                    <asp:Label ID="lbl_NS_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NS_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NS_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NS_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">NL</td>
                <td>
                    <asp:Label ID="lbl_NL_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NL_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NL_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NL_eMAF" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">PEI</td>
                <td>
                    <asp:Label ID="lbl_PEI_Invited" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_PEI_Reg" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_PEI_ePAF" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_PEI_eMAF" runat="server" /></td>
            </tr>
            <tr>
                <td align="center" bgcolor="#000000" style="color: #FFF">Totals</td>
                <td align="center" bgcolor="#000000" class="white">
                    <asp:Label runat="server" ID="lblInvitedTotal" />
                </td>
                <td align="center" bgcolor="#000000" class="white">
                    <asp:Label ID="lblRegsiteredTotal" runat="server" />
                </td>
                <td align="center" bgcolor="#000000" class="white">
                    <asp:Label ID="lblePAF" runat="server" />
                </td>
                <td align="center" bgcolor="#000000" class="white">
                    <asp:Label ID="lbleMAF" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel runat="server" ID="pnlCS">
        <table width="95%" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
            <tr>
                <td colspan="4" align="center" bgcolor="#9B2346"><span style="font-weight: 700; font-size: 28px; color: #FFF">VISTA DM Community Specialist Program at a Glance</span></td>
            </tr>
            <tr class="smallbold2">
                <td width="330" bgcolor="#000000" class="smallbold2white">Province</td>
                <td width="335" bgcolor="#000000" class="smallbold2white">Invited</td>
                <td width="374" bgcolor="#000000" class="smallbold2white">Registered</td>
            </tr>
            <tr bgcolor="#F4F4F4" class="smallbold2">
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="smallbold2">
                <td class="mainTable">BC</td>
                <td>
                    <asp:Label ID="lbl_BC_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_BC_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">AB</td>
                <td>
                    <asp:Label ID="lbl_AB_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_AB_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">SK</td>
                <td>
                    <asp:Label ID="lbl_SK_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_SK_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">MB</td>
                <td>
                    <asp:Label ID="lbl_MB_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_MB_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">ON</td>
                <td>
                    <asp:Label ID="lbl_ON_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_ON_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">QC</td>
                <td>
                    <asp:Label ID="lbl_QC_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_QC_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">NB</td>
                <td>
                    <asp:Label ID="lbl_NB_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NB_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">NS</td>
                <td>
                    <asp:Label ID="lbl_NS_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NS_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">NL</td>
                <td>
                    <asp:Label ID="lbl_NL_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_NL_Reg_CS" runat="server" /></td>
            </tr>
            <tr class="smallbold2">
                <td align="center" class="smallbold2">PEI</td>
                <td>
                    <asp:Label ID="lbl_PEI_Invited_CS" runat="server" /></td>
                <td>
                    <asp:Label ID="lbl_PEI_Reg_CS" runat="server" /></td>
            </tr>
            <tr>
                <td align="center" bgcolor="#000000" style="color: #FFF">Totals</td>
                <td align="center" bgcolor="#000000" class="white">

                    <asp:Label runat="server" ID="lblInvitedTotal_2" />

                </td>
                <td align="center" bgcolor="#000000" class="white">
                    <asp:Label runat="server" ID="lblRegTotal_2" />

                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />

    <asp:Panel runat="server" ID="pnlReports">

        <table width="95%" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
            <tr>
                <td align="left">
                    <div style="padding: 10px;">
                        <span><strong>Instructions:</strong></span>
                        <div>To filter the list by FSAs, please hold down the Ctrl key and select multiple items</div>
                        <div>To download the entire list, please click the “Select All” button</div>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <br />


        <table width="95%" border="0" cellspacing="0" style="margin-left: auto; margin-right: auto" class="spacedTable">
            <tr>
                <td align="left">
                    <div style="padding: 10px;">
                        <fieldset>
                            <legend>
                                <span><strong>Please select a Filter Mode</strong></span>
                            </legend>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:RadioButtonList Font-Bold="true" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" ID="rdoSearchMode" OnSelectedIndexChanged="rdoSearchMode_SelectedIndexChanged">
                                            <asp:ListItem Text="FSA" Value="1" />
                                            <asp:ListItem Text="BI Territory ID" Value="2" />
                                            <asp:ListItem Text="Lilly Territory ID" Value="3" />
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                </td>
            </tr>
        </table>


        <table width="100%">
            <tr>
                <td  align="center" style="width: 33%;">
                    <asp:Panel runat="server" ID="pnlFSA" Enabled="false" HorizontalAlign="Center">
                        <table width="200" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">Filter by FSA</td>
                            </tr>
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">
                                    <asp:Panel runat="server" HorizontalAlign="Center">
                                        <asp:ListBox runat="server" ID="lboxFSA" Width="300" Font-Bold="true" Font-Size="Large" Rows="6" Visible="false"
                                            SelectionMode="Multiple" OnSelectedIndexChanged="lboxFSA_SelectedIndexChanged"></asp:ListBox>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">
                                    <asp:Button Text="Select All" runat="server" ID="btnAll" OnClick="btnAll_clicked" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>

                </td>
                <td align="center" style="width: 33%;">
                    <asp:Panel runat="server" ID="pnlBI" Enabled="false">
                        <table  border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">Filter by BI Territory ID</td>
                            </tr>
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">
                                    <asp:Panel runat="server" HorizontalAlign="Center">
                                        <asp:ListBox runat="server" ID="lboxBI" Width="300" Font-Bold="true" Font-Size="Large" Rows="6" Visible="false"
                                            SelectionMode="Multiple" OnSelectedIndexChanged="lboxBI_SelectedIndexChanged"></asp:ListBox>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">
                                    <asp:Button Text="Select All" runat="server" ID="btn_BI_All" OnClick="btn_BI_All_clicked" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>

                <td align="center" style="width: 33%;">
                    <asp:Panel runat="server" ID="pnlLilly" Enabled="false" HorizontalAlign="Center">
                        <table width="200" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">Filter by Lilly Territory ID</td>
                            </tr>
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">
                                    <asp:Panel runat="server" HorizontalAlign="Center">
                                        <asp:ListBox runat="server" ID="lboxLilly" Width="300" Font-Bold="true" Font-Size="Large" Rows="6" Visible="false"
                                            SelectionMode="Multiple" OnSelectedIndexChanged="lboxLilly_SelectedIndexChanged"></asp:ListBox>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td width="881" align="center" bgcolor="#9B2346" class="white">
                                    <asp:Button Text="Select All" runat="server" ID="btn_Lilly_All" OnClick="btn_Lilly_All_clicked" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>

            </tr>
        </table>


        <p>
            <br />
            <br />
        </p>


        <table width="95%" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
            <tr>
                <td align="left">
                    <div style="padding: 10px;">
                        <span><strong>Instructions:</strong></span>
                        <div>Click the download icon next to the desired report type to generate the file </div>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <br />

        <table width="300" border="0" cellspacing="0" class="mainTable" style="margin-left: auto; margin-right: auto">
            <tr>
                <td width="881" colspan="2" align="center" bgcolor="#9B2346" class="white">Reports:</td>
            </tr>
            <tr>
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>Master List</strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgMaster" OnClick="imgMaster_clicked" />
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>Participant Program Status</strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <img src="../images/icon_download.png" alt="" width="31" height="31" /></td>
            </tr>
            <tr id="trPCP" runat="server">
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>
                    <asp:Label Text="Program at a Glance PCP" runat="server" ID="lblProgramGlancePCP" />
                </strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <%--<img src="../images/icon_download.png" alt="" width="31" height="31" />--%>
                    <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgProgramGlancePCP" OnClick="imgProgramGlancePCP_clicked" />
                </td>
            </tr>
            <tr id="trCS" runat="server">
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>
                    <asp:Label Text="Program at a Glance CS" runat="server" ID="lblProgramGlanceCS" />
                </strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <%--<img src="../images/icon_download.png" alt="" width="31" height="31" />--%>
                    <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgProgramGlanceCS" OnClick="imgProgramGlanceCS_clicked" />
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>Invited Participants </strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgInvitedPar" OnClick="imgInvitedPar_clicked" />
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>Registered Participants</strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <%--<img src="../images/icon_download.png" alt="" width="31" height="31" />--%>
                    <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgRegPar" OnClick="imgRegPar_clicked" />
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>No Response</strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <%--<img src="../images/icon_download.png" alt="" width="31" height="31" />--%>
                    <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgNoResp" OnClick="imgNoResp_clicked" />
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#FFFFFF" class="mainTable"><strong>Not Invited</strong></td>
                <td align="center" bgcolor="#FFFFFF" class="white">
                    <%--<img src="../images/icon_download.png" alt="" width="31" height="31" />--%>
                    <asp:ImageButton ImageUrl="../images/icon_download.png" runat="server" Width="31" Height="31" ID="imgNotInvited" OnClick="imgNotInvited_clicked" />
                </td>
            </tr>
        </table>

    </asp:Panel>
    <p>&nbsp; </p>
    <p>
        <br />
        <br />
        <br />
    </p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
