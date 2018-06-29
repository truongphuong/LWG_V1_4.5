<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductRequireInstrTitle.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ProductRequireInstrTitleControl" %>
<center>
    <asp:UpdatePanel ID="pnUpdateInstrTitle" runat="server">
        <ContentTemplate>
            <div id="divInstrTitle" runat="server">
                <asp:Panel ID="pnListInstrTitle" runat="server">
                    <div style="width: 880px; float: left; padding: 20px; text-align: left; font-family: Times New Roman;
                        font-size: 18pt; color: #127ed7; font-weight: bold;">
                        Manage Instrumental Title
                        <div style="float: right;">
                            <asp:Button ID="btnAddInstrTitle" runat="server" Text="Add New" OnClick="btnAddInstrTitle_Click" />
                            <%--<asp:LinkButton ID="lnkbtnTitleTypeManage" runat="server" Text="Manager Title Type" OnClick="lnkbtnTitleTypeManage_Click"></asp:LinkButton>--%>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <table cellpadding="0" cellspacing="0" style="line-height: 25px; font-family: Tahoma;
                        font-size: 12px;">
                        <asp:Repeater ID="rptListrInstrTitle" runat="server" OnItemDataBound="rptListrInstrTitle_ItemDataBound"
                            OnItemCommand="rptListrInstrTitle_ItemCommand">
                            <HeaderTemplate>
                                <tr>
                                    <td width="50px" align="center" valign="top" style="font-size: 13px; font-weight: bold;
                                        color: red;">
                                        ID
                                    </td>
                                    <td align="center" valign="top" style="font-size: 13px; font-weight: bold; color: red;">
                                        Name
                                    </td>
                                    <td align="center" valign="top" style="font-size: 13px; font-weight: bold; color: red;">
                                        TitleType
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="border-bottom: 5px solid #ffba19;">
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="center" valign="top">
                                        <asp:Literal ID="ltrID" runat="server" Text='<%# Eval("Id") %>'></asp:Literal>
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Literal ID="ltrName" runat="server" Text='<%#  Eval("Name") %>'></asp:Literal>
                                    </td>
                                    <td align="center" valign="top">
                                        <asp:Literal ID="ltrTitleType" runat="server" Text='<%#  Eval("TitleTypeId") %>'></asp:Literal>
                                    </td>
                                    <td align="center" valign="top" width="50px">
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" Text="Edit" CommandName="EDIT" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                    </td>
                                    <td align="center" valign="top" width="50px">
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you wish to delete this record?');"
                                            CommandName="DELETE" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="border-bottom: 1px solid #d0d0d0; border-bottom-style: dotted;">
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnEditInstrTitle" runat="server" Visible="false">
                    <div style="width: 880px; float: left; padding: 20px; text-align: left; font-family: Times New Roman;
                        font-size: 18pt; color: #127ed7; font-weight: bold;">
                        <asp:Label ID="lblTitleInstrTitle" runat="server"></asp:Label>
                    </div>
                    <div class="clear">
                    </div>
                    <table>
                        <tr>
                            <td width="100px">
                                Instrumental Title Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtInstrTitleName" runat="server" Width="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                    ValidationGroup="InstrTitle" ControlToValidate="txtInstrTitleName" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px">
                                Title Type:
                            </td>
                            <td>
                                <asp:DropDownList ID="drpTitleType" runat="server" DataTextField="Name" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <asp:Button ID="btnAddEditInstrTitle" runat="server" Text="Add" Width="70px" ValidationGroup="InstrTitle"
                                    OnClick="btnAddEditInstrTitle_Click" />
                                <asp:Button ID="btnCancelAddEditInstrTitle" runat="server" Text="Cancel" Width="70px"
                                    OnClick="btnCancelAddEditInstrTitle_Click" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <br />
                                <asp:Label ID="lblNoteAddeditInstrTitle" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</center>
