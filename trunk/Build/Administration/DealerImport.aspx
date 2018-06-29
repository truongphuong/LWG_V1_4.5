<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="DealerImport.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.DealerImport" %>
<%@ Register src="Modules/DealerImport.ascx" tagname="DealerImport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    
    <uc1:DealerImport ID="DealerImport1" runat="server" />
    
</asp:Content>
