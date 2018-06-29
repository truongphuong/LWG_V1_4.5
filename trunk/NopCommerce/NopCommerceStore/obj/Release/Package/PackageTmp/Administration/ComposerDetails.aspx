<%@ Page Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="ComposerDetails.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Administration_ComposerDetails" %>

<%@ Register TagPrefix="nopCommerce" TagName="ComposerDetails" Src="Modules/ComposerDetails.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <nopCommerce:ComposerDetails runat="server" ID="ctrlComposerDetails" />
</asp:Content>
