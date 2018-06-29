<%@ Page Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="Composers.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Administration_Composers" %>

<%@ Register TagPrefix="nopCommerce" TagName="Composers" Src="Modules/Composers.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <nopCommerce:Composers runat="server" ID="ctrlComposers" />
</asp:Content>