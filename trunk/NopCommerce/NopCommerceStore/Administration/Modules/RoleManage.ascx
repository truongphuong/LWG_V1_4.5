<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.RoleManageControl" %>

<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>

<div class="section-header">
    <div class="title">
        <img src="Common/ico-configuration.png" alt="<%=GetLocaleResourceString("Admin.ProductRole.Title")%>" />
        <%=GetLocaleResourceString("Admin.ProductRole.Title")%>
    </div>
    <div class="options">
        <input type="button" onclick="location.href='ProductRoleDetail.aspx'" value="<%=GetLocaleResourceString("Admin.ProductRole.AddButton.Text")%>"
            id="btnAddNew" class="adminButtonBlue" title="<%=GetLocaleResourceString("Admin.ProductRolw.AddButton.Tooltip")%>" />       
    </div>
</div>

<asp:GridView ID="gvProductRole" runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvProductRole_PageIndexChanging" AllowPaging="true" PageSize="15">
    <Columns>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductRole.RoleId %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Server.HtmlEncode(Eval("RoleId").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductRole.Name %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Server.HtmlEncode(Eval("Name").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>        

        <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductRole.Edit %>" HeaderStyle-HorizontalAlign="Center"
            ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href="ProductRoleDetail.aspx?ProductRoleId=<%#Eval("RoleId")%>"
                    title="<%#GetLocaleResourceString("Admin.ProductRole.Edit.Tooltip")%>">
                    <%#GetLocaleResourceString("Admin.ProductRole.Edit")%>
                </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>