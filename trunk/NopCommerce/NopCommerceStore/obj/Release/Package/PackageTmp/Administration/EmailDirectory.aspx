<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="EmailDirectory.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.EmailDirectory" %>
<%@ Register src="Modules/EmailDirectories.ascx" tagname="EmailDirectories" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <uc1:EmailDirectories ID="EmailDirectories1" runat="server" />
</asp:Content>
