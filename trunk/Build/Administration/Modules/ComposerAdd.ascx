<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComposerAdd.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ComposerAddControl" %>


<%@ Register TagPrefix="nopCommerce" TagName="ComposerInfo" Src="ComposerInfo.ascx" %>
<div class="section-header">
    <div class="title">
        <img src="Common/ico-promotions.png" alt="<%=GetLocaleResourceString("Admin.ComposerAdd.Title")%>" />
        <%=GetLocaleResourceString("Admin.ComposerAdd.Title")%>
        <a href="Composers.aspx" title="<%=GetLocaleResourceString("Admin.ComposerAdd.BackToComposers")%>">
            (<%=GetLocaleResourceString("Admin.ComposerAdd.BackToComposers")%>)</a>
    </div>
    <div class="options">
        <asp:Button ID="AddButton" runat="server" Text="<% $NopResources:Admin.ComposerAdd.AddButton.Text %>"
            CssClass="adminButtonBlue" OnClick="AddButton_Click" ToolTip="<% $NopResources:Admin.ComposerAdd.AddButton.Tooltip %>" />
    </div>
</div>
<nopCommerce:ComposerInfo ID="ctrlComposerInfo" runat="server" />
