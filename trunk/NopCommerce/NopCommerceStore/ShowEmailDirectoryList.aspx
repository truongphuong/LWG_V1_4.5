<%@ Page Language="C#" MasterPageFile="~/MasterPages/OneColumn.master" AutoEventWireup="true" CodeBehind="ShowEmailDirectoryList.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.ShowEmailDirectoryList" %>
<%@ Register src="Modules/ShowEmailDirectoryList.ascx" tagname="ShowEmailDirectoryList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <uc1:ShowEmailDirectoryList ID="ShowEmailDirectoryList1" runat="server" />
    <div class="clear"></div>
</asp:Content>
