<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Templates.Products.VariantsInGrid"
    CodeBehind="VariantsInGrid.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductVariantsInGrid" Src="~/Modules/ProductVariantsInGrid.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductInfo" Src="~/Modules/ProductInfo.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductCategoryBreadcrumb" Src="~/Modules/ProductCategoryBreadcrumb.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductRating" Src="~/Modules/ProductRating.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductEmailAFriendButton" Src="~/Modules/ProductEmailAFriendButton.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductAddToCompareList" Src="~/Modules/ProductAddToCompareList.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductSpecs" Src="~/Modules/ProductSpecifications.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="RelatedProducts" Src="~/Modules/RelatedProducts.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductReviews" Src="~/Modules/ProductReviews.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductsAlsoPurchased" Src="~/Modules/ProductsAlsoPurchased.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductTags" Src="~/Modules/ProductTags.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductShareButton" Src="~/Modules/ProductShareButton.ascx" %>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
    EnableScriptLocalization="true" ID="sm1" ScriptMode="Release" CompositeScript-ScriptMode="Release" />
<div style="width: 960px;">
    <div>
        <div class="Box4_top1" style="">
        </div>
        <div class="Box4_top2" style="width: 950px;">
        </div>
        <div class="Box4_top3" style="">
        </div>
    </div>
    <div style="background-color: #ffffff; padding-left: 9px; padding-right: 9px; color: #000000">
        <nopCommerce:ProductCategoryBreadcrumb ID="ctrlProductCategoryBreadcrumb" runat="server">
        </nopCommerce:ProductCategoryBreadcrumb>
        <div class="clear-5">
        </div>
        <div style="padding-right: 5px; padding-left: 5px;">
            <nopCommerce:ProductInfo ID="ctrlProductInfo" runat="server"></nopCommerce:ProductInfo>
            <div class="clear-20">
            </div>
            <%--<nopCommerce:ProductAddToCompareList ID="ctrlProductAddToCompareList" runat="server">
            </nopCommerce:ProductAddToCompareList>--%>
            <%--<nopCommerce:ProductVariantsInGrid ID="ctrlProductVariantsInGrid" runat="server">
            </nopCommerce:ProductVariantsInGrid>--%>
        </div>
    </div>
    <div>
        <div class="Box4_bot1" style="">
        </div>
        <div class="Box4_bot2" style="width: 950px;">
        </div>
        <div class="Box4_bot3" style="">
        </div>
    </div>
    <div class="clear">
    </div>

    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent1').className = "a_mainmenuActive";
       
    </script>

</div>
<div style="clear: both;">
</div>
<nopCommerce:ProductsAlsoPurchased ID="ctrlProductsAlsoPurchased" runat="server" />
<nopCommerce:RelatedProducts ID="ctrlRelatedProducts" runat="server"></nopCommerce:RelatedProducts>
<div style="display: none">
    <ajaxToolkit:TabContainer runat="server" ID="ProductsTabs" ActiveTabIndex="2" CssClass="grey">
        <ajaxToolkit:TabPanel runat="server" ID="pnlProductReviews" HeaderText="<% $NopResources:Products.ProductReviews %>">
            <ContentTemplate>
                <nopCommerce:ProductReviews ID="ctrlProductReviews" runat="server" ShowWriteReview="true">
                </nopCommerce:ProductReviews>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlProductSpecs" HeaderText="<% $NopResources:Products.ProductSpecs %>">
            <ContentTemplate>
                <nopCommerce:ProductSpecs ID="ctrlProductSpecs" runat="server"></nopCommerce:ProductSpecs>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlProductTags" HeaderText="<% $NopResources:Products.ProductTags %>">
            <ContentTemplate>
                <nopCommerce:ProductTags ID="ctrlProductTags" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</div>
