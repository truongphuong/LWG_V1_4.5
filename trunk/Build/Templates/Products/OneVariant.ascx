<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OneVariant.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Templates.Products.OneVariant" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductCategoryBreadcrumb" Src="~/Modules/ProductCategoryBreadcrumb.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductRating" Src="~/Modules/ProductRating.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductEmailAFriendButton" Src="~/Modules/ProductEmailAFriendButton.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductAddToCompareList" Src="~/Modules/ProductAddToCompareList.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductSpecs" Src="~/Modules/ProductSpecifications.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="RelatedProducts" Src="~/Modules/RelatedProducts.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductReviews" Src="~/Modules/ProductReviews.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductsAlsoPurchased" Src="~/Modules/ProductsAlsoPurchased.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="~/Modules/SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="NumericTextBox" Src="~/Modules/NumericTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductAttributes" Src="~/Modules/ProductAttributes.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductPrice" Src="~/Modules/ProductPrice.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="TierPrices" Src="~/Modules/TierPrices.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductTags" Src="~/Modules/ProductTags.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductShareButton" Src="~/Modules/ProductShareButton.ascx" %>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
    EnableScriptLocalization="true" ID="sm1" ScriptMode="Release" CompositeScript-ScriptMode="Release" />
<%--<div style="width: 960px;">
    <div>
        <div class="Box4_top1" style="">
        </div>
        <div class="Box4_top2" style="width: 950px;">
        </div>
        <div class="Box4_top3" style="">
        </div>
    </div>
    <div style="background-color: #ffffff; padding-left: 9px; padding-right: 9px; color: #000000">
        <nopCommerce:ProductCategoryBreadcrumb ID="ctrlProductCategoryBreadcrumb" runat="server" />
        <div class="clear-5">
        </div>
        <div style="padding-right: 5px; padding-left: 5px;">

            <script language="javascript" type="text/javascript">
                function UpdateMainImage(url) {
                    var imgMain = document.getElementById('<%=defaultImage.ClientID%>');
                    imgMain.src = url;
                }
            </script>

            <div>
                <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                    border-bottom: solid 1px #000000; float: left">
                    <div style="float: left; width: 500px;">
                        <asp:Literal ID="lProductName" runat="server" />
                        <span style="color: #aaaaaa; font-size: 15px;">by Josh Groban</span></div>
                    <div style="float: left; width: 280px; color: #58595b; padding-top: 5px;">
                        <span style="font-size: 15px;">Grade 1</span></div>
                    <div style="float: left; width: 142px;">
                        <nopCommerce:ProductEmailAFriendButton ID="ctrlProductEmailAFriendButton" runat="server" />
                    </div>
                </div>
            </div>
            <div>
                <div style="width: 300px; float: left; padding-top: 15px;">
                    <asp:Image ID="defaultImage" runat="server" />
                </div>
                <div style="width: 620px; float: left;">
                    <div>
                        <div>
                            <div style="width: 470px; float: left; padding-top: 15px;">
                                <div>
                                    <div style="color: #ff0000; font-size: 24px;">
                                        <nopCommerce:ProductPrice ID="ctrlProductPrice2" runat="server" />
                                        <nopCommerce:NumericTextBox runat="server" ID="txtCustomerEnteredPrice" Value="1"
                                            RequiredErrorMessage="<% $NopResources:Products.CustomerEnteredPrice.EnterPrice %>"
                                            MinimumValue="0" MaximumValue="999999" Width="100"></nopCommerce:NumericTextBox>
                                    </div>
                                    <div style="font-weight: bold;">
                                        Duration - 3.5<br />
                                        Instrumentation – <span style="color: #0068a2">Beginning Band</span></div>
                                </div>
                                <div style="padding-top: 10px;">
                                    <table>
                                        <tr>
                                            <td style="width: 200px">
                                                <div style="float: left;">
                                                    <img src="../App_Themes/darkOrange/images/icon_headphone.png" align="middle" />
                                                </div>
                                                <div style="float: left; padding-top: 5px;">
                                                    <a href=""><span style="color: #0068a2">&nbsp;Listen to the sample</span></a>
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </td>
                                            <td>
                                                <div style="float: left;">
                                                    <img src="../App_Themes/darkOrange/images/icon_music.png" align="middle" />
                                                </div>
                                                <div style="float: left; padding-top: 5px;">
                                                    <a href=""><span style="color: #0068a2">&nbsp;Preview music</span></a>
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div style="width: 147px; float: right; padding-top: 7px;">
                                <div>
                                    <div>
                                        <div class="Box5_top1"  style="">
                                        </div>
                                        <div class="Box5_top2" style=" width: 131px;">
                                        </div>
                                        <div class="Box5_top3" style="">
                                        </div>
                                    </div>
                                    <div style="background-color: #e5eff9; width: 147px; float: left; text-align: center;
                                        padding-top: 10px;">
                                        <span style="font-weight: bold;">Quatity</span>&nbsp;&nbsp;&nbsp;&nbsp;
                                        <nopCommerce:NumericTextBox runat="server" ID="txtQuantity" Value="1" RequiredErrorMessage="<% $NopResources:Products.EnterQuantity %>"
                                            RangeErrorMessage="<% $NopResources:Products.QuantityRange %>" MinimumValue="1"
                                            MaximumValue="999999" Width="50" />
                                        <div class="clear-10">
                                        </div>
                                        <asp:Button ID="btnAddToCart" runat="server" OnCommand="OnCommand" Text="" CommandName="AddToCart"
                                            CommandArgument='<%#Eval("ProductVariantId")%>' CssClass="btnAddtocard" BackColor="Transparent"
                                            BorderColor="Transparent" />
                                        <div class="clear-10">
                                        </div>
                                        <asp:Button ID="btnAddToWishlist" runat="server" OnCommand="OnCommand" Text="<% $NopResources:Wishlist.AddToWishlist %>"
                                            CommandName="AddToWishlist" CommandArgument='<%#Eval("ProductVariantId")%>' CssClass="productvariantaddtowishlistbutton" />
                                        <div class="clear-10">
                                        </div>
                                        <nopCommerce:ProductAddToCompareList ID="ctrlProductAddToCompareList" runat="server" />
                                        <div class="clear">
                                        </div>
                                        <nopCommerce:ProductShareButton ID="ctrlProductShareButton" runat="server" />
                                    </div>
                                    <div>
                                        <div class="Box5_bot1" style="">
                                        </div>
                                       <div class="Box5_bot2" style=" width: 131px;">
                                        </div>
                                        <div class="Box5_bot3" style="">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clear-20">
                        </div>
                        <div style="padding-right: 40px;">
                            <div style="color: #f37032; font-weight: bold;">
                                About
                                <asp:Literal ID="lProductName1" runat="server" /></div>
                            <div style="color: #58595b">
                                <asp:Literal ID="lShortDescription" runat="server" />
                            </div>
                            <div>
                                <nopCommerce:ProductRating ID="ctrlProductRating" runat="server" />
                            </div>
                        </div>
                        <div style="text-align: left; padding-top: 15px; color: #f37032; font-weight: bold;">
                            Quick Facts
                        </div>
                        <div class="clear-20">
                        </div>
                        <div style="text-align: left; font-weight: bold;">
                            <div style="float: left; width: 240px;">
                                <div>
                                    <div style="float: left; width: 80px; color: #000000;">
                                        Year</div>
                                    <div style="float: left; width: 160px; color: #58595b">
                                        2007</div>
                                </div>
                                <div>
                                    <div style="float: left; width: 80px; color: #000000;">
                                        Period</div>
                                    <div style="float: left; width: 160px; color: #58595b">
                                        Living Composer</div>
                                </div>
                                <div>
                                    <div style="float: left; width: 80px; color: #000000;">
                                        Genre</div>
                                    <div style="float: left; width: 160px; color: #58595b">
                                        Original Works</div>
                                </div>
                            </div>
                            <div style="float: left; width: 260px;">
                                <div>
                                    <div style="float: left; width: 90px; color: #000000;">
                                        Orig. Imprint</div>
                                    <div style="float: left; width: 170px; color: #58595b">
                                        Great Works Publishing</div>
                                </div>
                                <div>
                                    <div style="float: left; width: 90px; color: #000000;">
                                        Category</div>
                                    <div style="float: left; width: 170px; color: #58595b">
                                        American</div>
                                </div>
                                <div>
                                    <div style="float: left; width: 90px; color: #000000;">
                                        Series</div>
                                    <div style="float: left; width: 170px; color: #58595b">
                                        &nbsp;</div>
                                </div>
                                <div>
                                    <div style="float: left; width: 90px; color: #000000;">
                                        Text</div>
                                    <div style="float: left; width: 170px; color: #58595b">
                                        &nbsp;</div>
                                </div>
                                <div>
                                    <div style="float: left; width: 90px; color: #000000;">
                                        Lang</div>
                                    <div style="float: left; width: 170px; color: #58595b">
                                        &nbsp;</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear-10">
        </div>
        <div class="clear">
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
            <span style="">Customers Who Bought "You Raise Me Up" Also Bought</span>
        </div>
        <div style="background-color: #fff; color: Black; height: 252px; text-align: center;">
            <div style="width: 180px; float: left; height: 223px;">
                <div style="text-align: center; padding-top: 15px;">
                    <a href="product_details.html">
                        <img src="../App_Themes/darkOrange/images/product1.jpg" style="border: 0px;" /></a>
                </div>
                <div style="font-size: 13px; color: #146fa4; font-weight: bold; text-align: center;
                    padding-top: 15px;">
                    <a href="product_details.html" style="text-decoration: underline;"><span style="color: #146fa4">
                        Michael Jackson's<br />
                        This Is It</span></a>
                </div>
                <div style="padding-top: 7px;">
                    <div style="width: 96px; float: left; color: #fd961d; font-weight: bold; text-align: center;
                        padding-top: 1px;">
                        $16.99
                    </div>
                    <div style="width: 84px; float: left;">
                        <a href="product_details.html">
                            <div class="div_bntBuynow1" style="width: 5px;">
                            </div>
                            <div class="div_bntBuynow2" style="width: 60px;">
                                Buy Now
                            </div>
                            <div class="div_bntBuynow3" style="width: 5px;">
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <div style="width: 180px; float: left; height: 223px;">
                <div style="text-align: center; padding-top: 15px;">
                    <a href="product_details.html">
                        <img src="../App_Themes/darkOrange/images/product1.jpg" style="border: 0px;" /></a>
                </div>
                <div style="font-size: 13px; color: #146fa4; font-weight: bold; text-align: center;
                    padding-top: 15px;">
                    <a href="product_details.html" style="text-decoration: underline;"><span style="color: #146fa4">
                        Michael Jackson's<br />
                        This Is It</span></a>
                </div>
                <div style="padding-top: 7px;">
                    <div style="width: 96px; float: left; color: #fd961d; font-weight: bold; text-align: center;
                        padding-top: 1px;">
                        $16.99
                    </div>
                    <div style="width: 84px; float: left;">
                        <a href="product_details.html">
                            <div class="div_bntBuynow1" style="width: 5px;">
                            </div>
                            <div class="div_bntBuynow2" style="width: 60px;">
                                Buy Now
                            </div>
                            <div class="div_bntBuynow3" style="width: 5px;">
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <div style="width: 180px; float: left; height: 223px;">
                <div style="text-align: center; padding-top: 15px;">
                    <a href="product_details.html">
                        <img src="../App_Themes/darkOrange/images/product1.jpg" style="border: 0px;" /></a>
                </div>
                <div style="font-size: 13px; color: #146fa4; font-weight: bold; text-align: center;
                    padding-top: 15px;">
                    <a href="product_details.html" style="text-decoration: underline;"><span style="color: #146fa4">
                        Michael Jackson's<br />
                        This Is It</span></a>
                </div>
                <div style="padding-top: 7px;">
                    <div style="width: 96px; float: left; color: #fd961d; font-weight: bold; text-align: center;
                        padding-top: 1px;">
                        $16.99
                    </div>
                    <div style="width: 84px; float: left;">
                        <a href="product_details.html">
                            <div class="div_bntBuynow1" style="width: 5px;">
                            </div>
                            <div class="div_bntBuynow2" style="width: 60px;">
                                Buy Now
                            </div>
                            <div class="div_bntBuynow3" style="width: 5px;">
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <div style="width: 180px; float: left; height: 223px;">
                <div style="text-align: center; padding-top: 15px;">
                    <a href="product_details.html">
                        <img src="../App_Themes/darkOrange/images/product1.jpg" style="border: 0px;" /></a>
                </div>
                <div style="font-size: 13px; color: #146fa4; font-weight: bold; text-align: center;
                    padding-top: 15px;">
                    <a href="product_details.html" style="text-decoration: underline;"><span style="color: #146fa4">
                        Michael Jackson's<br />
                        This Is It</span></a>
                </div>
                <div style="padding-top: 7px;">
                    <div style="width: 96px; float: left; color: #fd961d; font-weight: bold; text-align: center;
                        padding-top: 1px;">
                        $16.99
                    </div>
                    <div style="width: 84px; float: left;">
                        <a href="product_details.html">
                            <div class="div_bntBuynow1" style="width: 5px;">
                            </div>
                            <div class="div_bntBuynow2" style="width: 60px;">
                                Buy Now
                            </div>
                            <div class="div_bntBuynow3" style="width: 5px;">
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <div style="width: 180px; float: left; height: 223px;">
                <div style="text-align: center; padding-top: 15px;">
                    <a href="product_details.html">
                        <img src="../App_Themes/darkOrange/images/product1.jpg" style="border: 0px;" /></a>
                </div>
                <div style="font-size: 13px; color: #146fa4; font-weight: bold; text-align: center;
                    padding-top: 15px;">
                    <a href="product_details.html" style="text-decoration: underline;"><span style="color: #146fa4">
                        Michael Jackson's<br />
                        This Is It</span></a>
                </div>
                <div style="padding-top: 7px;">
                    <div style="width: 96px; float: left; color: #fd961d; font-weight: bold; text-align: center;
                        padding-top: 1px;">
                        $16.99
                    </div>
                    <div style="width: 84px; float: left;">
                        <a href="product_details.html">
                            <div class="div_bntBuynow1" style="width: 5px;">
                            </div>
                            <div class="div_bntBuynow2" style="width: 60px;">
                                Buy Now
                            </div>
                            <div class="div_bntBuynow3" style="width: 5px;">
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>--%>
<div>
    <div class="Box4_top1" style="">
    </div>
    <div class="Box4_top2" style="width: 950px;">
    </div>
    <div class="Box4_top3" style="">
    </div>
</div>
<div style="background-color: #ffffff; padding-left: 9px; padding-right: 9px; color: #000000">
    <nopCommerce:ProductCategoryBreadcrumb ID="ctrlProductCategoryBreadcrumb" runat="server" />
    <div class="clear">
    </div>
    <div class="product-details-page">
        <div class="product-essential product-details-info">

            <script language="javascript" type="text/javascript">
                function UpdateMainImage(url) {
                    var imgMain = document.getElementById('<%=defaultImage.ClientID%>');
                    imgMain.src = url;
                }
            </script>

            <div class="picture">
                <asp:Image ID="defaultImage" runat="server" />
                <asp:ListView ID="lvProductPictures" runat="server" GroupItemCount="3">
                    <LayoutTemplate>
                        <table style="margin-top: 10px;">
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td align="left">
                            <a href="<%#PictureManager.GetPictureUrl((int)Eval("PictureId"))%>" rel="lightbox-p"
                                title="<%= lProductName.Text%>">
                                <img src="<%#PictureManager.GetPictureUrl((int)Eval("PictureId"), 70)%>" alt="Product image" /></a>
                        </td>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="overview">
                <h3 class="productname">
                    <asp:Literal ID="lProductName" runat="server" />
                </h3>
                <div class="clear">
                </div>
                <div class="shortdescription">
                    <asp:Literal ID="lShortDescription" runat="server" />
                </div>
                <div class="product-collateral">
                    <nopCommerce:ProductRating ID="ctrlProductRating" runat="server" />
                    <br />
                    <div class="one-variant-price">
                        <nopCommerce:ProductPrice ID="ctrlProductPrice2" runat="server" />
                        <nopCommerce:NumericTextBox runat="server" ID="txtCustomerEnteredPrice" Value="1"
                            RequiredErrorMessage="<% $NopResources:Products.CustomerEnteredPrice.EnterPrice %>"
                            MinimumValue="0" MaximumValue="999999" Width="100"></nopCommerce:NumericTextBox>
                    </div>
                    <div class="add-info">
                        <nopCommerce:NumericTextBox runat="server" ID="txtQuantity" Value="1" RequiredErrorMessage="<% $NopResources:Products.EnterQuantity %>"
                            RangeErrorMessage="<% $NopResources:Products.QuantityRange %>" MinimumValue="1"
                            MaximumValue="999999" Width="50" />
                        <asp:Button ID="btnAddToCart" runat="server" OnCommand="OnCommand" Text="<% $NopResources:Products.AddToCart %>"
                            CommandName="AddToCart" CommandArgument='<%#Eval("ProductVariantId")%>' CssClass="productvariantaddtocartbutton" />
                        <asp:Button ID="btnAddToWishlist" runat="server" OnCommand="OnCommand" Text="<% $NopResources:Wishlist.AddToWishlist %>"
                            CommandName="AddToWishlist" CommandArgument='<%#Eval("ProductVariantId")%>' CssClass="productvariantaddtowishlistbutton" />
                    </div>
                    <asp:Panel runat="server" ID="pnlDownloadSample" Visible="false" CssClass="one-variant-download-sample">
                        <span class="downloadsamplebutton">
                            <asp:HyperLink runat="server" ID="hlDownloadSample" Text="<% $NopResources:Products.DownloadSample %>" />
                        </span>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="pnlStockAvailablity" runat="server" class="stock">
                        <asp:Label ID="lblStockAvailablity" runat="server" />
                    </asp:Panel>
                    <br />
                    <nopCommerce:ProductEmailAFriendButton ID="ctrlProductEmailAFriendButton" runat="server" />
                    <nopCommerce:ProductAddToCompareList ID="ctrlProductAddToCompareList" runat="server" />
                    <div class="clear">
                    </div>
                    <nopCommerce:ProductShareButton ID="ctrlProductShareButton" runat="server" />
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="product-collateral">
            <div class="product-variant-line">
                <asp:Label runat="server" ID="lblError" EnableViewState="false" CssClass="error" />
                <div class="clear">
                </div>
                <nopCommerce:TierPrices ID="ctrlTierPrices" runat="server" />
                <div class="clear">
                </div>
                <div class="attributes">
                    <nopCommerce:ProductAttributes ID="ctrlProductAttributes" runat="server" />
                </div>
                <div class="clear">
                </div>
                <asp:Panel ID="pnlGiftCardInfo" runat="server" class="giftCard">
                    <dl>
                        <dt>
                            <asp:Label runat="server" ID="lblRecipientName" Text="<% $NopResources:Products.GiftCard.RecipientName %>"
                                AssociatedControlID="txtRecipientName"></asp:Label></dt>
                        <dd>
                            <asp:TextBox runat="server" ID="txtRecipientName"></asp:TextBox></dd>
                        <dt>
                            <asp:Label runat="server" ID="lblRecipientEmail" Text="<% $NopResources:Products.GiftCard.RecipientEmail %>"
                                AssociatedControlID="txtRecipientEmail"></asp:Label></dt>
                        <dd>
                            <asp:TextBox runat="server" ID="txtRecipientEmail"></asp:TextBox></dd>
                        <dt>
                            <asp:Label runat="server" ID="lblSenderName" Text="<% $NopResources:Products.GiftCard.SenderName %>"
                                AssociatedControlID="txtSenderName"></asp:Label></dt>
                        <dd>
                            <asp:TextBox runat="server" ID="txtSenderName"></asp:TextBox></dd>
                        <dt>
                            <asp:Label runat="server" ID="lblSenderEmail" Text="<% $NopResources:Products.GiftCard.SenderEmail %>"
                                AssociatedControlID="txtSenderEmail"></asp:Label></dt>
                        <dd>
                            <asp:TextBox runat="server" ID="txtSenderEmail"></asp:TextBox></dd>
                        <dt>
                            <asp:Label runat="server" ID="lblGiftCardMessage" Text="<% $NopResources:Products.GiftCard.Message %>"
                                AssociatedControlID="txtGiftCardMessage"></asp:Label></dt>
                        <dd>
                            <asp:TextBox runat="server" ID="txtGiftCardMessage" TextMode="MultiLine" Height="100px"
                                Width="300px"></asp:TextBox></dd>
                    </dl>
                </asp:Panel>
                <div class="clear">
                </div>
                <div class="fulldescription">
                    <asp:Literal ID="lFullDescription" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
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
<div>
    <nopCommerce:ProductsAlsoPurchased ID="ctrlProductsAlsoPurchased" runat="server" />
</div>
<div class="clear">
</div>
<div>
    <nopCommerce:RelatedProducts ID="ctrlRelatedProducts" runat="server" />
</div>
<div class="clear-15">
</div>
<ajaxToolkit:TabContainer runat="server" ID="ProductsTabs" ActiveTabIndex="1" CssClass="grey">
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductReviews" HeaderText="<% $NopResources:Products.ProductReviews %>">
        <ContentTemplate>
            <nopCommerce:ProductReviews ID="ctrlProductReviews" runat="server" ShowWriteReview="true" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductSpecs" HeaderText="<% $NopResources:Products.ProductSpecs %>">
        <ContentTemplate>
            <nopCommerce:ProductSpecs ID="ctrlProductSpecs" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductTags" HeaderText="<% $NopResources:Products.ProductTags %>">
        <ContentTemplate>
            <nopCommerce:ProductTags ID="ctrlProductTags" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
