<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailDirectoryDetail.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.EmailDirectoryDetail" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="EmailTextBox" Src="EmailTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>
<%@ Register Assembly="NopCommerceStore" Namespace="NopSolutions.NopCommerce.Web.Controls"
    TagPrefix="nopCommerce" %>

<div class="section-header">
    <div class="title">
        <img src="Common/ico-catalog.png" alt="" />
        Email Directory
        <a href="EmailDirectory.aspx" title="back to EmailDirectory List">
            back to EmailDirectory List</a></div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="Save"
             ToolTip="Save" onclick="SaveButton_Click" />
    </div>
    
    
</div>

<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblFirstName" Text="First Name"
                ToolTip="First Name" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:SimpleTextBox runat="server" ID="txtFirstName" CssClass="adminInput" ErrorMessage="First Name is required">
            </nopCommerce:SimpleTextBox>
        </td>
    </tr>
      <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblLastName" Text="Last Name"
                ToolTip="Last Name" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:SimpleTextBox runat="server" ID="txtLastName" CssClass="adminInput" ErrorMessage="Last Name is required">
            </nopCommerce:SimpleTextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblJobTitle" Text="Job Title"
                ToolTip="Job Title" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID = "txtJobTitle" CssClass="adminInput" runat="server"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblPhoneNumber" Text="Phone Number"
                ToolTip="Phone Number" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID = "txtPhoneNumber" CssClass="adminInput" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblEmailAddress" Text="Email Address"
                ToolTip="Email Address" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:EmailTextBox ID="txtEmailAddress" runat="server" />
        </td>
    </tr>
     <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblDescription" Text="Description"
                ToolTip="Description" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:NopHTMLEditor runat="server" ID="txtDescription" Height="350" />
        </td>
    </tr>
     <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblPicture" Text="Pictrure"
                ToolTip="Pictrure" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:Image ID="iPicture" runat="server" AlternateText="Pictrure" />
            <br />
            <asp:Button ID="btnRemoveImage" CssClass="adminInput" CausesValidation="false"
                runat="server" Text="Remove" 
                Visible="false" onclick="btnRemoveImage_Click"/>
            <br />
            <asp:FileUpload ID="fuPicture" CssClass="adminInput" runat="server"/>
        </td>
    </tr>
    
</table>