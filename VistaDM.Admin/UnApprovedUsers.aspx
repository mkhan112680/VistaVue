<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UnApprovedUsers.aspx.cs" Inherits="VistaDM.Admin.UnApprovedUsers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="margin: 0 auto;">
        <div>
            <div style="width: 960px; margin-left: auto; margin-right: auto">
                <div class="grow float padding">
                    <asp:HyperLink NavigateUrl="~/SelectProgram.aspx" runat="server" ImageUrl="~/images/button_changeprogram.png"
                        ID="hlChangeProgram" border="0" Width="110" />
                </div>
                <div class="grow float padding">
                    <asp:HyperLink NavigateUrl="~/SelectRegion.aspx" runat="server" ImageUrl="~/images/button_changeregion.png"
                        ID="hlChangeRegion" border="0" Width="110" />
                </div>
                <div class="grow float padding">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='NewPhysician.aspx' runat="server" ImageUrl="~/images/button_new_physician.png"
                        class="add_open btn btn-success fancybox1" />
                </div>
                <div class="grow float padding">
                    <img src="images/button_manual.png" border="0" width="110" />
                </div>
                <div class="grow float padding">
                    <img src="images/button_document.png" border="0" width="110" />
                </div>
                <div class="grow float padding">
                    <img src="images/button_resource.png" border="0" width="110" />
                </div>
                <div class="grow float padding">
                    <img src="images/button_report.png" border="0" width="110" />
                </div>
                <div style="clear: both">
                </div>
                <a href="AdminDefault.aspx">
                    <div class="grow float padding">
                        <img src="images/icon_enter.png" border="31" width="31" style="vertical-align: middle;" />
                        <span style="font-family: Arial; font-size: 11px; color: Black; font-weight: bold; vertical-align: middle;">All Users</span>
                    </div>
                </a>
            </div>
            <br />
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="UPCardiologists" runat="server">
                <ContentTemplate>
                    <dx:ASPxGridView ID="gvCardiologists" runat="server" AutoGenerateColumns="False"
                        CssClass="centerTbl" KeyFieldName="PhysicianID" OnHtmlRowCreated="gvCardiologists_HtmlRowCreated"
                        OnHtmlDataCellPrepared="gvCardiologists_HtmlDataCellPrepared" OnHtmlCommandCellPrepared="gvCardiologists_HtmlCommandCellPrepared">
                        <Settings ShowFilterRow="True" />
                        <Styles>
                            <Header CssClass="smallboldwhite">
                            </Header>
                        </Styles>
                        <Columns>
                            <dx:GridViewBandColumn VisibleIndex="0" HeaderStyle-Border-BorderWidth="0">
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Font-Bold="False" VerticalAlign="Middle"
                                    BackColor="#9B2346" CssClass="smallboldwhite" Font-Size="28px">
                                    <Border BorderWidth="0px" />
                                </HeaderStyle>
                                <HeaderTemplate>
                                    <div class="whitelarge" style="font-size: 28px; font-weight: 700; color: #fff;">
                                        <asp:Literal ID="Literal1" runat="server" Text="Physician List"></asp:Literal>
                                    </div>
                                </HeaderTemplate>
                                <Columns>
                                    <dx:GridViewDataHyperLinkColumn FieldName="UniqueID" Width="70px" Caption="Physician<br>Info"
                                        VisibleIndex="0">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="smallboldwhite">
                                        </CellStyle>
                                        <DataItemTemplate>
                                            <a href='DocInfo.aspx?ID=<%# Eval("PhysicianID") %>' target="_blank" class="fancybox1">
                                                <img src="images/icon_pencil.png" width="36px" height="36px"></img></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataHyperLinkColumn>
                                    <dx:GridViewDataColumn FieldName="FirstName" Caption="First Name" Width="100px" VisibleIndex="2">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings FilterMode="DisplayText" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="True" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn FieldName="LastName" Caption="Last Name" Width="100px" VisibleIndex="3">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings FilterMode="DisplayText" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="True" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn FieldName="Province.Name" Caption="Province" Width="50px"
                                        VisibleIndex="4">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings FilterMode="DisplayText" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="True" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>


                                    <dx:GridViewDataColumn FieldName="Province.Name" Caption="Province" Width="50px"
                                        VisibleIndex="4">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings FilterMode="DisplayText" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="True" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn FieldName="YourFirstName" Caption="Adder FirstName" Width="50px"
                                        VisibleIndex="4">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings FilterMode="DisplayText" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="True" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn FieldName="YourLastName" Caption="Adder LastName" Width="50px"
                                        VisibleIndex="4">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings FilterMode="DisplayText" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="True" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>

                                    <dx:GridViewDataColumn FieldName="YourEmail" Caption="Adder Email" Width="50px"
                                        VisibleIndex="4">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" Border-BorderColor="Black">
                                            <Border BorderColor="Black" />
                                        </HeaderStyle>
                                        <Settings FilterMode="DisplayText" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="True" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                        
                                    </dx:GridViewDataColumn>


                                </Columns>
                            </dx:GridViewBandColumn>
                            <dx:GridViewBandColumn VisibleIndex="5" Visible="False" HeaderStyle-Border-BorderWidth="0">
                                <HeaderStyle HorizontalAlign="Left" ForeColor="Black" Font-Bold="True" VerticalAlign="Middle"
                                    BackColor="#CCCCCC">
                                    <Border BorderWidth="0px" />
                                </HeaderStyle>
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="" Width="50px" VisibleIndex="7">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#B54340"
                                            ForeColor="Black" />
                                        <Settings AllowAutoFilter="False" />
                                        <CellStyle BackColor="White" VerticalAlign="Middle" HorizontalAlign="Center">
                                        </CellStyle>
                                        <Settings AllowAutoFilter="False" />
                                        <DataItemTemplate>
                                            <asp:Button Visible="False" ID="dummyInvitedCheckbox" runat="server" CommandName='<%# Eval("PhysicianID") %>' />
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:GridViewBandColumn>
                            <dx:GridViewBandColumn Name="PreProgInv" VisibleIndex="7" Visible="False" HeaderStyle-Border-BorderWidth="0">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="#CCCCCC">
                                    <Border BorderWidth="0px" />
                                </HeaderStyle>
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Caption="Select" VisibleIndex="1"
                                        Width="100px" ButtonType="Button">
                                        <ClearFilterButton Visible="True">
                                        </ClearFilterButton>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#B54340" />
                                        <CellStyle BackColor="White" VerticalAlign="Middle">
                                        </CellStyle>
                                        <HeaderTemplate>
                                            <dx:ASPxCheckBox ID="SelectAllCheckBox" runat="server" ToolTip="Select/Unselect all rows on the page"
                                                TextAlign="Left" CheckState="Unchecked">
                                                <ClientSideEvents CheckedChanged="function(s, e) { gvCardiologists.SelectAllRowsOnPage(s.GetChecked()); }" />
                                            </dx:ASPxCheckBox>
                                        </HeaderTemplate>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="InvitationSentDate" VisibleIndex="1" Caption="Generate Invitation"
                                        Width="160px">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#B54340"
                                            Font-Bold="True" ForeColor="White" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <DataItemTemplate>
                                        </DataItemTemplate>
                                        <CellStyle BackColor="White" VerticalAlign="Middle" HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn FieldName="MOU" Caption="MOU<br>Status" Width="200px" VisibleIndex="1">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn FieldName="MOUDate" Caption="MOU Date" Width="200px" VisibleIndex="1"
                                        Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataHyperLinkColumn FieldName="UniqueID" Width="70px" Caption="Enrollment<br>Summary"
                                        VisibleIndex="1">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="Black" BackColor="Black" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <Settings AllowAutoFilter="False" />
                                        <DataItemTemplate>
                                            <a href='PhysicianInfo.aspx?ID=<%# Eval("PhysicianID") %>' target="_blank" class="fancybox1">
                                                <img src="images/icon_magnify.png" width="27px"></img></a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataHyperLinkColumn>
                                    <dx:GridViewDataColumn FieldName="AssesmentSurvey" Caption="Assesment Survey" Width="200px"
                                        VisibleIndex="0" ShowInCustomizationForm="False">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn FieldName="AssesmentSurveyDate" Caption="Assesment Survey Date"
                                        Width="200px" VisibleIndex="1" ShowInCustomizationForm="False" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn FieldName="PayeeInformation" Caption="Payee Information" Width="200px"
                                        VisibleIndex="1" ShowInCustomizationForm="False">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn FieldName="PayeeInformationDate" Caption="Payee Date" Width="200px"
                                        VisibleIndex="1" ShowInCustomizationForm="False" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Black" />
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                        </CellStyle>
                                    </dx:GridViewDataColumn>
                                </Columns>
                            </dx:GridViewBandColumn>
                            <dx:GridViewBandColumn VisibleIndex="1" HeaderStyle-Border-BorderWidth="0">
                                <Columns>
                                    <dx:GridViewDataCheckColumn Caption="Approve" Name="colInvitedByCHRC"
                                        Width="50px" FieldName="Invited" HeaderStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-Border-BorderColor="#999999" HeaderStyle-BackColor="#999999">
                                        <Settings FilterMode="Value" AllowAutoFilter="True" AllowSort="True" AllowHeaderFilter="False"
                                            ShowInFilterControl="False" />
                                        <DataItemTemplate>
                                            <dx:ASPxCheckBox runat="server" ID="chkCHRC" PhysicianID='<%# Eval("PhysicianID") %>'
                                                OnCheckedChanged="chkCHRC_OnCheckedChanged" ClientInstanceName="cbEnable" AutoPostBack="true">
                                            </dx:ASPxCheckBox>
                                            <asp:Button Visible="False" ID="dummyInv2" runat="server" CommandName='<%# Eval("PhysicianID") %>' />
                                            <asp:Button Visible="False" ID="dummyFN" runat="server" CommandName='<%# Eval("YourFirstName") %>' />
                                            <asp:Button Visible="False" ID="dummyLN" runat="server" CommandName='<%# Eval("YourLastName") %>' />
                                            <asp:Button Visible="False" ID="dummyEmail" runat="server" CommandName='<%# Eval("YourEmail") %>' />
                                        </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center">
                                            <Border BorderColor="#999999" />
                                        </HeaderStyle>
                                    </dx:GridViewDataCheckColumn>
                                </Columns>
                                <HeaderStyle>
                                    <Border BorderWidth="0px" />
                                </HeaderStyle>
                            </dx:GridViewBandColumn>
                        </Columns>
                        <Settings ShowFilterRow="True" />
                    </dx:ASPxGridView>
                    <div>
                        <asp:Label runat="server" ID="lblResult" ForeColor="Red" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
