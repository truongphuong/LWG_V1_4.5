<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Templates.Categories.ProductsInGrid"
    CodeBehind="ProductsInGrid.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductBox1" Src="~/Modules/ProductBox1.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="PriceRangeFilter" Src="~/Modules/PriceRangeFilter.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductSpecificationFilter" Src="~/Modules/ProductSpecificationFilter.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="CategoryNavigation" Src="~/Modules/CategoryNavigation.ascx" %>
<style type="text/css">
    .plist tr
    {
        border-bottom: 1px solid #BEBDBD;
    }
  </style>
<div class="category-page">
    <div style="width: 220px; float: left;">
        <nopCommerce:CategoryNavigation EnableViewState="true" ID="ctrlCategoryNavigation"
            runat="server" />
        <div class="clear">
        </div>
    </div>
    <div style="width: 728px; float: left; padding-left: 10px;">
        <div>
            <div class="Box4_top1" style="">
            </div>
            <div class="Box4_top2" style="width: 718px;">
            </div>
            <div class="Box4_top3" style="">
            </div>
        </div>
        <div style="background-color: #ffffff; padding-left: 9px; padding-right: 9px; color: #000000">
            <div style="float: right; height: 830px; width: 1px">
            </div>
            <div style="float: left; width: 699px">
                <div class="breadcrumb">
                    <a href='<%=CommonHelper.GetStoreLocation()%>'>
                        <%=GetLocaleResourceString("Breadcrumb.Top")%></a> /
                    <asp:Repeater ID="rptrCategoryBreadcrumb" EnableViewState="true" runat="server">
                        <ItemTemplate>
                            <a href='<%#SEOHelper.GetCategoryUrl(Convert.ToInt32(Eval("CategoryId"))) %>'>
                                <%#Server.HtmlEncode(Eval("Name").ToString()) %></a>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            /
                        </SeparatorTemplate>
                    </asp:Repeater>
                    <div style="float: right; width: 150px;text-align:right;">
                        <asp:LinkButton EnableViewState="true" ID="ibtnGalleryView" runat="server" OnClick="ibtnGalleryView_Click">Gallery</asp:LinkButton>
                        <span>&nbsp;|&nbsp;</span>
                        <asp:LinkButton EnableViewState="true" ID="ibtnListView" 
                            runat="server" OnClick="ibtnListView_Click">List</asp:LinkButton>
                    </div>
                </div>
                <div style="border-bottom: 1px solid black; margin-bottom: 5px;">
                </div>
                <div class="clear">
                </div>
                <div style="float: right; width: 182px;text-align:right;">
                    <asp:Panel runat="server" ID="pnlSorting" CssClass="product-sorting">
                        <b>
                            <%=GetLocaleResourceString("ProductSorting.SortBy")%>:</b> &nbsp;
                        <asp:DropDownList ID="ddlSorting" runat="server" OnSelectedIndexChanged="ddlSorting_SelectedIndexChanged"
                            AutoPostBack="true" />
                    </asp:Panel>
                </div>
                <div class="Cat_header">
                    <asp:Literal runat="server" EnableViewState="true" ID="lDescription"></asp:Literal>
                </div>
                <div class="clear">
                </div>
                <div class="sub-category-grid" style="width: 100%">
                    <asp:DataList ID="dlSubCategories" EnableViewState="true" runat="server" RepeatColumns="4"
                        RepeatDirection="Horizontal" RepeatLayout="Table" OnItemDataBound="dlSubCategories_ItemDataBound"
                        ItemStyle-CssClass="item-box">
                        <ItemTemplate>
                            <div class="sub-category-item">
                                <h2 class="category-title">
                                    <asp:HyperLink ID="hlCategory" runat="server" />
                                </h2>
                                <div class="picture">
                                    <asp:HyperLink ID="hlImageLink" runat="server" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="clear">
                </div>
                <div style="text-align: left">
                    <asp:Panel runat="server" ID="pnlFeaturedProducts" EnableViewState="true">
                        <div class="Cat_header">
                            <%=GetLocaleResourceString("Products.FeaturedProducts")%> 
                        </div>
                        <div class="clear-10">
                        </div>
                        <div>
                            <asp:DataList  CssClass="plist" ID="dlFeaturedProducts" runat="server"
                                RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Table" ItemStyle-CssClass="ProductCategory"
                                ItemStyle-VerticalAlign="Top" CellPadding="5">
                                <ItemTemplate>
                                    <nopCommerce:ProductBox1 ID="ctrlProductBox" Product='<%# Container.DataItem %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </asp:Panel>
                </div>
                <div class="clear">
                </div>
                <div class="clear">
                </div>
                <%--//\--%>
                <div style="display: none;">
                    <asp:Panel runat="server" ID="pnlFilters" EnableViewState="true" CssClass="product-filters">
                        <div class="filter-title">
                            <asp:Label runat="server" ID="lblProductFilterTitle" EnableViewState="true">
                <%=GetLocaleResourceString("Products.FilterOptionsTitle")%>
                            </asp:Label>
                        </div>
                        <div class="filter-item">
                            <nopCommerce:PriceRangeFilter EnableViewState="true" ID="ctrlPriceRangeFilter" runat="server" />
                        </div>
                        <div class="filter-item">
                            <nopCommerce:ProductSpecificationFilter EnableViewState="true" ID="ctrlProductSpecificationFilter"
                                runat="server" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="clear">
                </div>
                <div>
                    <asp:DataList EnableViewState="true" CssClass="plist" ID="dlProducts" runat="server"
                        RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Table" ItemStyle-CssClass="ProductCategory"
                        ItemStyle-VerticalAlign="Top" CellPadding="5" 
                        >
                        <ItemTemplate>
                            <div style="padding: 10px 0px 10px 0px;">
                                <nopCommerce:ProductBox1 ID="ctrlProductBox" Product='<%# Container.DataItem %>'
                                    runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="product-pager" style="padding-top: 10px;">
                    <nopCommerce:Pager runat="server" EnableViewState="true" ID="productsPager" FirstButtonText="<% $NopResources:Pager.First %>"
                        LastButtonText="<% $NopResources:Pager.Last %>" NextButtonText="<% $NopResources:Pager.Next %>"
                        PreviousButtonText="<% $NopResources:Pager.Previous %>" CurrentPageText="Pager.CurrentPage"
                        PageSize="12" />
                </div>
                <div class="clear-20">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div>
            <div class="Box4_bot1" style="">
            </div>
            <div class="Box4_bot2" style="width: 718px;">
            </div>
            <div class="Box4_bot3" style="">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
</div>
<div style="clear: both;">
</div>
<div style="text-align: left;">
    <div style="padding-top: 20px;">
        <div>
            <div class="Box3_top1" style="">
            </div>
            <div class="Box3_top2" style="width: 950px;">
            </div>
            <div class="Box3_top3" style="">
            </div>
        </div>
        <div class="Box3_header" style="">
            <span style="">Distributors of</span>
        </div>
        <div style="background-color: #222121; color: Black; height: 252px; text-align: center;">
            <div style="float: left; width: 820px;">
                <div style="float: left; padding-top: 20px; padding-left: 15px;">
                    <img src="../App_Themes/darkOrange/images/distributors_item10.png" style="padding-right: 10px;" />
                    <img src="../App_Themes/darkOrange/images/distributors_item9.png" style="padding-right: 10px;" />
                    <img src="../App_Themes/darkOrange/images/distributors_item8.png" style="padding-right: 10px;" />
                    <img src="../App_Themes/darkOrange/images/distributors_item7.png" style="padding-right: 10px;" />
                    <img src="../App_Themes/darkOrange/images/distributors_item2.png" style="padding-right: 10px;" />
                </div>
                <div style="float: left; padding-top: 20px; padding-left: 15px;">
                    <img src="../App_Themes/darkOrange/images/distributors_item6.png" style="padding-right: 20px;" />
                    <img src="../App_Themes/darkOrange/images/distributors_item5.png" style="padding-right: 20px;
                        padding-bottom: 20px;" />
                    <img src="../App_Themes/darkOrange/images/distributors_item4.png" style="padding-right: 30px;
                        padding-bottom: 20px;" />
                    <img src="../App_Themes/darkOrange/images/distributors_item3.png" style="padding-right: 30px;
                        padding-bottom: 25px;" />
                    <img src="../App_Themes/darkOrange/images/Distributors_item11.jpg" style="padding-right: 20px;" />
                </div>
            </div>
            <div style="float: right; padding-top: 20px;">
                <img src="../App_Themes/darkOrange/images/distributors_item1.png" style="padding-right: 20px;" />
            </div>
        </div>
    </div>
</div>
