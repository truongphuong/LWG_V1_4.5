<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComposerDetails.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ComposerDetailsControl" %>
<%@ Register TagPrefix="nopCommerce" TagName="ComposerInfo" Src="ComposerInfo.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>
<div class="section-header">
    <div class="title">
        <img src="Common/ico-configuration.png" alt="<%=GetLocaleResourceString("Admin.ComposerDetails.Title")%>" />
        <%=GetLocaleResourceString("Admin.ComposerDetails.Title")%>
        <a href="Composers.aspx" title="<%=GetLocaleResourceString("Admin.ComposerDetails.BackToComposers")%>">
            (<%=GetLocaleResourceString("Admin.ComposerDetails.BackToComposers")%>)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="<% $NopResources:Admin.ComposerDetails.SaveButton.Text %>"
            OnClick="SaveButton_Click" ToolTip="<% $NopResources:Admin.ComposerDetails.SaveButton.Tooltip %>" />
        <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="<% $NopResources:Admin.ComposerDetails.DeleteButton.Text %>"
            OnClick="DeleteButton_Click" CausesValidation="false" ToolTip="<% $NopResources:Admin.ComposerDetails.DeleteButton.Tooltip %>" />
    </div>
</div>
<nopCommerce:ComposerInfo ID="ctrlComposerInfo" runat="server" />
<nopCommerce:ConfirmationBox runat="server" ID="cbDelete" TargetControlID="DeleteButton"
    YesText="<% $NopResources:Admin.Common.Yes %>" NoText="<% $NopResources:Admin.Common.No %>"
    ConfirmText="<% $NopResources:Admin.Common.AreYouSure %>" />
