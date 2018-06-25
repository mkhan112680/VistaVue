<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RemunerationCntrl.ascx.cs" Inherits="VistaDM.Admin.Controls.RemunerationCntrl" %>

<script type="text/javascript">

    $(document).ready(function () {

        $('#<%=imgBtn.ClientID %>').datepicker({

            altField: $('#<%=txt_PAF1_Date.ClientID %>'),

            numberOfMonths: 1,
            changeMonth: true,
            changeYear: true,
            dateFormat: "dd/mm/yy",
            yearRange: "2000:2016"

        });

    });
    //function pageLoad() { }

</script>


<tr>
    <td style="width: 50%;">
        <span class="bolditalic">Remuneration Status:</span>
    </td>
    <td style="width: 50%;" align="right">
        <span bgcolor="#FCFCFC" class="green" style="padding: 3px 3px 3px 3px; text-align: right;">
            <asp:Label ID="renStatus" runat="server" />
        </span>
    </td>
</tr>
<tr>
    <td colspan="2" bgcolor="#CCCCCC" style="padding: 3px;">
        <div style="max-height: 100px; overflow: auto; margin: 0 auto; margin-top: 20px; margin-bottom: 20px;">
            <asp:GridView runat="server" AutoGenerateColumns="false" ID="gvPAF1" HorizontalAlign="Center" CssClass="body" Font-Bold="true"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Cheque" HeaderText="Cheque" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" Text='<%#Eval("Comments") %>' />
                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <table width="100%" border="0">
                <tr>
                    <%--<td width="7%">
                                                    <div class="squaredThree">
                                                        <asp:CheckBox   runat="server" id="chk_paf1_remit" ClientIDMode="Static"/>
                                                        <label for="chk_paf1_remit"></label>
                                                    </div>
                                                </td>--%>
                    <td width="14%" class="body" style="color: #000; font-weight: bold">DATE:</td>
                    <td width="14%" class="body" style="color: #000; font-weight: bold;">
                        <asp:TextBox runat="server" ID="txt_PAF1_Date" Style="width: 75px; vertical-align: middle;" />
                        <asp:RequiredFieldValidator ID="req1" Display="Dynamic" Text="*" ErrorMessage="Date Required" ControlToValidate="txt_PAF1_Date" runat="server" CssClass="missing" />
                    </td>
                    <td width="14%">
                        <asp:ImageButton ImageUrl="../images/calendar_icon.png" runat="server" ID="imgBtn" OnClientClick="return false;"
                            Style="vertical-align: middle;" Width="25" />
                    </td>
                    <td width="14%" class="body" style="color: #000; font-weight: bold">CHEQUE #:
                                                    
                    </td>
                    <td width="14%">
                        <asp:TextBox runat="server" ID="txt_PAF1_chk" Style="width: 40px" />
                        <asp:RequiredFieldValidator ID="req2" Display="Dynamic" Text="*" ErrorMessage="Check # Required" ControlToValidate="txt_PAF1_chk" runat="server" CssClass="missing" />
                    </td>
                    <td width="14%" class="body" style="color: #000; font-weight: bold">AMOUNT:</td>
                    <td width="14%" class="body" style="color: #000; font-weight: bold">$
                                                    <asp:TextBox runat="server" ID="txt_PAF_amount" Style="width: 40px" />
                        <asp:RequiredFieldValidator ID="req3" Display="Dynamic" Text="*" ErrorMessage="Amount Required" ControlToValidate="txt_PAF_amount" runat="server" CssClass="missing" />
                        <asp:CompareValidator ID="compPAF1" Display="Dynamic" runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="txt_PAF_amount" ErrorMessage="Value must be a valid number" CssClass="missing"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" class="body" style="color: #000; font-weight: bold; padding-left: 0px">COMMENTS
                                                    <asp:TextBox runat="server" Rows="3" TextMode="MultiLine" ID="txt_PAF_Comments" Width="82%" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: center;" class="body">
            <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" CssClass="noList" />
            <asp:Label runat="server" ID="lbl_PAF_Result" CssClass="missing" />
        </div>
        <div style="border-top-width: thin; border-top-style: solid; border-top-color: #999; padding-left: 10px; margin-top: 10px; margin-bottom: 10px; padding-top: 5px">
            <asp:ImageButton CausesValidation="true" ImageUrl="../images/button_add.png" Width="22" border="0" runat="server" ID="img" OnClick="img_clicked" />
            <span class="body" style="color: #000; font-weight: bold; font-size: 18px">ADD PAYMENT INFO</span>
        </div>
    </td>
</tr>
