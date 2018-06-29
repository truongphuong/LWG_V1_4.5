<%@ Page Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="ProductRole.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.ProductRolePage" %>
<%@ Register Src="~/Administration/Modules/RoleManage.ascx" TagName="RoleManage" TagPrefix="ctl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <ctl:RoleManage id="ctlRoleManage" runat="server" ></ctl:RoleManage>
</asp:Content>
