﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductRequireTitleType.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ProductRequireTitleTypeControl" %>
<center>
    <div>
        <asp:UpdatePanel ID="updatepnTitleType" runat="server">
            <ContentTemplate>
                <div id="divTitleType" runat="server">
                    <asp:Panel ID="pnListTitleType" runat="server">
                        <div style="width: 880px; float: left; padding: 20px; text-align: left; font-family: Times New Roman;
                            font-size: 18pt; color: #127ed7; font-weight: bold;">
                            Manage Title Type
                            <div style="float: right;">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                                <%--<asp:LinkButton ID="lnkbtnInstrTitle" runat="server" Text="Manager Instrumental Title" OnClick="lnkbtnInstrTitle_Click"></asp:LinkButton>--%>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <table cellpadding="0" cellspacing="0" style="line-height: 25px; font-family: Tahoma;
                            font-size: 12px;">
                            <asp:Repeater ID="rptTitleType" runat="server" OnItemCommand="rptTitleType_ItemCommand">
                                <HeaderTemplate>
                                    <tr>
                                        <td width="50px" align="center" valign="top" style="font-size: 13px; font-weight: bold;
                                            color: red;">
                                            ID
                                        </td>
                                        <td align="center" valign="top" style="font-size: 13px; font-weight: bold; color: red;">
                                            Name
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
                    <asp:Panel ID="pnEditTitleType" runat="server" DefaultButton="btnAdd" Visible="false">
                        <div style="width: 880px; float: left; padding: 20px; text-align: left; font-family: Times New Roman;
                            font-size: 18pt; color: #127ed7; font-weight: bold;">
                            <asp:Label ID="txtTitle" runat="server"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        <table>
                            <tr>
                                <td width="100px">
                                    Title Type Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" Width="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="required1" runat="server" Display="Dynamic" ValidationGroup="AddEdit"
                                        ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="70px" ValidationGroup="AddEdit"
                                        OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="70px" OnClick="btnCancel_Click" />
                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <br />
                                    <asp:Label ID="lblNote" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>               
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</center>
