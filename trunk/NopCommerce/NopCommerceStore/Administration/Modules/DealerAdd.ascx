<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DealerAdd.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.DealerAdd" %>

<div class="section-header">
    <div class="title">
        <img src="Common/ico-catalog.png" alt="Add a new Dealer" />
        Or add a new dealer manual <a href="Dealer.aspx" title="Back to dealer list">(Back to dealer list)</a>
    </div>
    <div class="options">
    <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
                        ToolTip="Save" OnClick="SaveButton_Click" ValidationGroup="AddDealer" />
    </div>
</div>
<div>
    <asp:Panel ID="pnlAddNew" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtCustomerID" Text="Dealer #:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerID" CssClass="dealerTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCustomerID" runat="server" Display="Dynamic" ControlToValidate="txtCustomerID"
                        ValidationGroup="AddDealer">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchName" runat="server" AssociatedControlID="txtName" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" CssClass="dealerTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="txtName" ValidationGroup="AddDealer">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtAddress1" Text="Address Line 1:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ControlToValidate="txtAddress1" ValidationGroup="AddDealer">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" AssociatedControlID="txtAddress2" Text="Address Line 2:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" AssociatedControlID="txtCity" Text="City:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                        ControlToValidate="txtCity" ValidationGroup="AddDealer">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtZip" Text="Zip Code:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtState" Text="State:"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="ddlUSState" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlUSState_SelectedIndexChanged"></asp:DropDownList>
                    <asp:TextBox ID="txtState" Visible="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" AssociatedControlID="txtPhone" Text="Phone:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" AssociatedControlID="txtFax" Text="Fax:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" AssociatedControlID="txtWebAddress" Text="Web address:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtWebAddress" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" AssociatedControlID="txtContact" Text="Contact:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContact" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" AssociatedControlID="txtNewIssue" Text="New Issue:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNewIssue" runat="server" CssClass="dealerTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblAddNewError" ForeColor="Red" runat="server"></asp:Label>
                </td>
            </tr>
            
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlAddNewMessage" runat="server" Visible="false">
        <div>
            Add dealer successfull. <a href="DealerAdd.aspx">Add another</a><span> or </span>
            <a href="Dealer.aspx">return dealer list</a>.
        </div>
    </asp:Panel>
</div>
