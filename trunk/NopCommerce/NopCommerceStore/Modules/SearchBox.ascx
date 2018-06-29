<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.SearchBoxControl"
    CodeBehind="SearchBox.ascx.cs" %>
<div style="background-image: url(../App_Themes/darkOrange/images/bg_menu_search.jpg);
    width: 182px; height: 24px; padding-left: 4px; padding-top: 3px; float: left;
    margin-right: 9px; margin-left: 21px;">
    <asp:TextBox ID="txtSearchTerms" runat="server" SkinID="SearchBoxText" Text="<% $NopResources:Search.SearchStoreTooltip %>" />
</div>
<div style=" float:left; width:27px; margin-right: 9px;">
<asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" CssClass="searchboxbutton"
    CausesValidation="false" BorderColor="Transparent" BackColor="Transparent" /></div>
<div style="float: left; width: 54px; font-size: 10px; line-height: 13px; text-align: center;
    font-weight: bold;">
    <a href="../advance_search.aspx" style="text-decoration: none;"><span style="color: #000000; font-weight: normal;
        font-size: 12px;">advanced<br />
        search</span></a>
</div>
<%--
<asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="<% $NopResources:Search.SearchButton %>"
    CssClass="searchboxbutton" CausesValidation="false" BorderColor="Transparent" BackColor="Transparent" />--%>
