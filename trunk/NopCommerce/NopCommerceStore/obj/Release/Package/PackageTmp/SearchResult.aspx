<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    CodeBehind="SearchResult.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.SearchResult" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductBox2" Src="~/Modules/ProductBox2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <div class="SearchResults">
        <asp:Label runat="server" ID="lblNoResults" Text="<% $NopResources:Search.NoResultsText %>"
            Visible="false" CssClass="result" />
        <div style="width: 940px; margin: 0px auto">
            <asp:ListView ID="lvProducts" runat="server" OnPagePropertiesChanging="lvProducts_OnPagePropertiesChanging">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="item-box" style="margin: 0px">
                        <nopCommerce:ProductBox2 ID="ctrlProductBox" Product='<%# Container.DataItem %>'
                            runat="server" />
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="pager">
            <asp:DataPager ID="pagerProducts" runat="server" PagedControlID="lvProducts" PageSize="10">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"
                        FirstPageText="<% $NopResources:Search.First %>" LastPageText="<% $NopResources:Search.Last %>"
                        NextPageText="<% $NopResources:Search.Next %>" PreviousPageText="<% $NopResources:Search.Previous %>" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
