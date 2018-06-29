<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="Dealer.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Dealer" %>

<%@ Register src="Modules/Dealers.ascx" tagname="Dealers" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <uc1:Dealers ID="Dealers1" runat="server" />
    </asp:Content>
