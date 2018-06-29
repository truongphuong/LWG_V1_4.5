<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="DealerDetails.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.DealerDetails" %>
<%@ Register src="Modules/DealerDetails.ascx" tagname="DealerDetails" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <uc1:DealerDetails ID="DealerDetails1" runat="server" />
</asp:Content>
