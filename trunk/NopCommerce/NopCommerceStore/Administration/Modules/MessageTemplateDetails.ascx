<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.MessageTemplateDetailsControl"
    CodeBehind="MessageTemplateDetails.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>
<%@ Register Assembly="NopCommerceStore" Namespace="NopSolutions.NopCommerce.Web.Controls"
    TagPrefix="nopCommerce" %>
    
<div class="section-header">
    <div class="title">
        <img src="Common/ico-content.png" alt="<%=GetLocaleResourceString("Admin.MessageTemplateDetails.Title")%>" />
        <%=GetLocaleResourceString("Admin.MessageTemplateDetails.Title")%>
        <a href="MessageTemplates.aspx" title="<%=GetLocaleResourceString("Admin.MessageTemplateDetails.BackToTemplates")%>">
            (<%=GetLocaleResourceString("Admin.MessageTemplateDetails.BackToTemplates")%>)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="<% $NopResources:Admin.MessageTemplateDetails.SaveButton.Text %>"
            OnClick="SaveButton_Click" ToolTip="<% $NopResources:Admin.MessageTemplateDetails.SaveButton.Tooltip %>" />
        <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="<% $NopResources:Admin.MessageTemplateDetails.DeleteButton.Text %>"
            OnClick="DeleteButton_Click" CausesValidation="false" ToolTip="<% $NopResources:Admin.MessageTemplateDetails.DeleteButton.Tooltip %>" />
    </div>
</div>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            <strong>
                <nopCommerce:ToolTipLabel runat="server" ID="lblAllowedTokensTitle" Text="<% $NopResources:Admin.MessageTemplateDetails.AllowedTokens %>"
                    ToolTip="<% $NopResources:Admin.MessageTemplateDetails.AllowedTokens.Tooltip %>"
                    ToolTipImage="~/Administration/Common/ico-help.gif" />
            </strong>
        </td>
        <td class="adminData">
            <br />
            <asp:Label ID="lblAllowedTokens" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblLanguageTitle" Text="<% $NopResources:Admin.MessageTemplateDetails.Language %>"
                ToolTip="<% $NopResources:Admin.MessageTemplateDetails.Language.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:Label ID="lblLanguage" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblName" Text="<% $NopResources:Admin.MessageTemplateDetails.Name %>"
                ToolTip="<% $NopResources:Admin.MessageTemplateDetails.Name.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:Label ID="lblTemplate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblBCCEmailAddresses" Text="<% $NopResources:Admin.MessageTemplateDetails.BCCEmailAddresses %>"
                ToolTip="<% $NopResources:Admin.MessageTemplateDetails.BCCEmailAddresses.Tooltip %>"
                ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtBCCEmailAddresses" CssClass="adminInput" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblSubject" Text="<% $NopResources:Admin.MessageTemplateDetails.Subject %>"
                ToolTip="<% $NopResources:Admin.MessageTemplateDetails.Subject.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:SimpleTextBox runat="server" CssClass="adminInput" ID="txtSubject" ErrorMessage="<% $NopResources:Admin.MessageTemplateDetails.Subject.ErrorMessage %>">
            </nopCommerce:SimpleTextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblBody" Text="<% $NopResources:Admin.MessageTemplateDetails.Body %>"
                ToolTip="<% $NopResources:Admin.MessageTemplateDetails.Body.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <nopCommerce:NopHTMLEditor ID="txtBody" runat="server" Height="350" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblActive" Text="<% $NopResources:Admin.MessageTemplateDetails.Active %>"
                ToolTip="<% $NopResources:Admin.MessageTemplateDetails.Active.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:CheckBox ID="cbActive" runat="server" Checked="true" />
        </td>
    </tr>
</table>
<nopCommerce:ConfirmationBox runat="server" ID="cbDelete" TargetControlID="DeleteButton"
    YesText="<% $NopResources:Admin.Common.Yes %>" NoText="<% $NopResources:Admin.Common.No %>"
    ConfirmText="<% $NopResources:Admin.Common.AreYouSure %>" />
