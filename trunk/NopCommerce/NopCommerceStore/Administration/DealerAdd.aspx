<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="DealerAdd.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.DealerAdd" %>
<%@ Register src="Modules/DealerAdd.ascx" tagname="DealerAdd" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <uc1:DealerAdd ID="DealerAdd1" runat="server" />
</asp:Content>
