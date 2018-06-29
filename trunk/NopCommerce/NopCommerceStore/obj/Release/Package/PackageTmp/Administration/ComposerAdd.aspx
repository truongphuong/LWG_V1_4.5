<%@ Page Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="ComposerAdd.aspx.cs" 
Inherits="NopSolutions.NopCommerce.Web.Administration.Administration_ComposerAdd" %>

<%@ Register TagPrefix="nopCommerce" TagName="ComposerAdd" Src="Modules/ComposerAdd.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <nopCommerce:ComposerAdd runat="server" ID="ctrlComposerAdd" />
</asp:Content>

