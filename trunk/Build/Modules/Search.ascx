<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.SearchControl"
    CodeBehind="Search.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductBox2" Src="~/Modules/ProductBox2.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="NumericTextBox" Src="~/Modules/NumericTextBox.ascx" %>

<script type="text/javascript">
    $(document).ready(function() {
        toggleAdvancedSearch();
    });

    function toggleAdvancedSearch() {
        if (getE('<%=cbAdvancedSearch.ClientID %>').checked) {
            $('#<%=pnlAdvancedSearch.ClientID %>').show();
        }
        else {
            $('#<%=pnlAdvancedSearch.ClientID %>').hide();
        }
    }

</script>

<div>
    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
        margin-bottom: 5px; border-bottom: solid 1px #000000;">
        <%=GetLocaleResourceString("Search.Search")%></div>
    <div class="clear">
    </div>
    <table cellpadding="4" cellspacing="0" style="color: #555555">
        <tbody>
            <tr>
                <td class="Searchtitle">
                    <%=GetLocaleResourceString("Search.SearchKeyword")%>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSearchTerm" SkinID="SearchText" CssClass="searchtext"></asp:TextBox>                    
                </td>         
                <td>
                <div><asp:HyperLink ID="hpAdvancedSearch" runat="server" NavigateUrl="~/advance_search.aspx" >advanced search</asp:HyperLink></div>
                </td>       
            </tr>
            <tr>
                <td>
                </td>
                <td class="Searchtitle">
                    <asp:CheckBox runat="server" ID="cbAdvancedSearch" Text="<% $NopResources:Search.AdvancedSearch %>" />
                </td>
                <td></td>
            </tr>
        </tbody>
    </table>
    
    <table style="color: #555555" cellpadding="4" cellspacing="0" runat="server" id="pnlAdvancedSearch">
        <tbody>
            <tr runat="server" id="trCategories">
                <td class="Searchtitle">
                    <%=GetLocaleResourceString("Search.Categories")%>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlCategories" CssClass="searchtext">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Searchtitle">
                    Series:
                </td>
                <td class="data">
                    <asp:DropDownList runat="server" ID="ddlSeries">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr runat="server" id="trManufacturers" visible="false">
                <td class="Searchtitle">
                    <%=GetLocaleResourceString("Search.Manufacturers")%>
                </td>
                <td class="data">
                    <asp:DropDownList ID="ddlManufacturers" runat="server" CssClass="searchtext">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td class="Searchtitle">
                    <%=GetLocaleResourceString("Search.PriceRange")%>
                </td>
                <td class="data">
                    <%=GetLocaleResourceString("Search.From")%>
                    <asp:TextBox runat="server" ID="txtPriceFrom" Width="170" />
                    <%=GetLocaleResourceString("Search.To")%>
                    <asp:TextBox runat="server" ID="txtPriceTo" Width="170" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="Searchtitle">
                    <asp:CheckBox runat="server" ID="cbSearchInProductDescriptions" Text="<% $NopResources:Search.SearchInProductDescriptions %>" />
                </td>
            </tr>
        </tbody>
    </table>
    <div style="margin-left: 210px">
        <asp:Label runat="server" ID="lblError" EnableViewState="false"></asp:Label>
        <div>
            <div class="div_bntBuynow1">
            </div>
            <div class="div_bntBuynow2">
                <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="<% $NopResources:Search.SearchButton %>"
                    CssClass="btnSearchBox" />
            </div>
            <div class="div_bntBuynow3">
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
     <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
        margin-bottom: 5px; border-bottom: solid 1px #000000;">
        Search Results</div>
    <div class="clear">
    </div>
    <div class="SearchResults" style=" margin:0px; text-align:left">
        <asp:Label runat="server" ID="lblNoResults" Text="<% $NopResources:Search.NoResultsText %>"
            Visible="false" CssClass="result" />
        <div style=" width:940px; margin:0px auto">
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
    <div class="clear-20"></div>
</div>
