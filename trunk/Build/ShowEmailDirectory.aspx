<%@ Page Language="C#" MasterPageFile="~/MasterPages/OneColumn.master" AutoEventWireup="true" CodeBehind="ShowEmailDirectory.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.ShowEmailDirectory" %>
<%@ Register src="Modules/ShowEmailDirectoryDetail.ascx" tagname="ShowEmailDirectoryDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <uc1:ShowEmailDirectoryDetail ID="ShowEmailDirectoryDetail1" runat="server" />
    <div class="clear"></div>
</asp:Content>
