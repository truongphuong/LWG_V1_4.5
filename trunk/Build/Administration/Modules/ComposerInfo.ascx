<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComposerInfo.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ComposerInfoControl" %>

<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="DatePicker" Src="DatePicker.ascx" %>
<%@ Register Assembly="NopCommerceStore" Namespace="NopSolutions.NopCommerce.Web.Controls" TagPrefix="nopCommerce" %>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblNameDisplay" Text="<% $NopResources:Admin.ComposerInfo.NameDisplay %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.NameDisplay.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:SimpleTextBox runat="server" ID="txtNameDisplay" CssClass="adminInput" ErrorMessage="<% $NopResources:Admin.ComposerInfo.NameDisplay.ErrorMessage %>">
            </nopCommerce:SimpleTextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblNameList" Text="<% $NopResources:Admin.ComposerInfo.NameList %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.NameList.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:SimpleTextBox runat="server" ID="txtNameList" CssClass="adminInput" ErrorMessage="<% $NopResources:Admin.ComposerInfo.NameList.ErrorMessage %>">
            </nopCommerce:SimpleTextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblNameSort" Text="<% $NopResources:Admin.ComposerInfo.NameSort %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.NameSort.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtNameSort" CssClass="adminInput">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblFirstName" Text="<% $NopResources:Admin.ComposerInfo.FirstName %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.FirstName.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:SimpleTextBox runat="server" ID="txtFirstName" CssClass="adminInput" ErrorMessage="<% $NopResources:Admin.ComposerInfo.FirstName.ErrorMessage %>">
            </nopCommerce:SimpleTextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblLastName" Text="<% $NopResources:Admin.ComposerInfo.LastName %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.LastName.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:SimpleTextBox runat="server" ID="txtLastName" CssClass="adminInput" ErrorMessage="<% $NopResources:Admin.ComposerInfo.LastName.ErrorMessage %>">
            </nopCommerce:SimpleTextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblDOB" Text="<% $NopResources:Admin.ComposerInfo.DOB %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.DOB.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblDOD" Text="<% $NopResources:Admin.ComposerInfo.DOD %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.DOD.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtDOD" runat="server"></asp:TextBox>
            
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
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblBiography" Text="<% $NopResources:Admin.ComposerInfo.Biography %>"
                ToolTip="<% $NopResources:Admin.ComposerInfo.Biography.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:NopHTMLEditor ID="txtBiography" runat="server" Height="350" />
        </td>
    </tr>
</table>