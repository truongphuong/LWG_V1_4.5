<%@ Page Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="ProductRoleDetail.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.ProductRoleDetailPage" %>
<%@ Register Src="~/Administration/Modules/ProductRoleDetail.ascx" TagName="ProductRoleDetail" TagPrefix="ctl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <ctl:ProductRoleDetail ID="ctlProductRoleDetail" runat="server" />
</asp:Content>
