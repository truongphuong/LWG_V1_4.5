<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.ProductInfoControl"
    CodeBehind="ProductInfo.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductShareButton" Src="~/Modules/ProductShareButton.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductEmailAFriendButton" Src="~/Modules/ProductEmailAFriendButton.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductVariantsInGrid" Src="~/Modules/ProductVariantsInGrid.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductAddToCompareList" Src="~/Modules/ProductAddToCompareList.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductRating" Src="~/Modules/ProductRating.ascx" %>
<script language="javascript" type="text/javascript">
    function UpdateMainImage(url) {
        var imgMain = document.getElementById('<%=defaultImage.ClientID%>');
        imgMain.src = url;
    }
</script>
<div>
    <div style="font-size: 20px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
        border-bottom: solid 1px #000000; float: left">
        <div style="float: left; width: 780px;">
            <asp:Literal ID="lProductName" runat="server" />
            <div>
                <span style="color: #f37032; font-weight: bold; font-size: 14px;">
                    <asp:Literal runat="server" ID="ltrSubtitle"></asp:Literal>
                </span>
            </div>
            <span style="color: #aaaaaa; font-size: 15px;">
                <asp:Literal runat="server" ID="ltrComposer"></asp:Literal>
            </span>
        </div>
        <div style="float: left; width: 142px;">
            <nopCommerce:ProductEmailAFriendButton ID="ctrlProductEmailAFriendButton" runat="server">
            </nopCommerce:ProductEmailAFriendButton>
        </div>
    </div>
</div>
<div>
    <div style="width: 300px; float: left; padding-top: 15px;">
        <asp:Image ID="defaultImage" runat="server" />
        <br />
        <div>
            <asp:ListView ID="lvProductPictures" runat="server" GroupItemCount="3">
                <LayoutTemplate>
                    <table>
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
    </div>
    <div style="width: 610px; float: left; margin-left: 10px">
        <div>
            <div>
                <div style="width: 460px; float: left; padding-top: 15px;">
                    <div>
                        <div style="color: #ff0000; font-size: 24px;">
                            <asp:Literal runat="server" Visible="false" ID="ltrPrice"></asp:Literal>
                        </div>
                        <asp:DataList ID="productVariantRepeater" runat="server" RepeatColumns="1">
                            <ItemTemplate>
                                <div>
                                    <div style="float: left; font-size: 20px;">
                                        <asp:Literal ID="variantName" Text='<%#Server.HtmlEncode(Eval("Name").ToString())%>'
                                            runat="server"></asp:Literal><asp:Literal ID="separate" runat="server" Text='<%# Eval("Name").ToString()==""?"":" -  " %>'></asp:Literal></div>
                                    <div style="float: left; padding-left: 5px; color: #ff0000; font-size: 20px;">
                                        <asp:Literal ID="variantPrice" Text='<%#string.Format("{0:c}",Eval("Price"))%>' runat="server"></asp:Literal></div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <div class="clear-10">
                    </div>
                    <div style="padding-right: 40px;">
                        <div style="color: #f37032; font-weight: bold;">
                            About
                            <asp:Literal ID="lProductName1" runat="server" />
                        </div>
                        <div style="color: #58595b">
                            <div class="clear-5">
                            </div>
                            <asp:Literal ID="lShortDescription" runat="server" Visible="false" />
                            <div class="clear-5">
                            </div>
                            <asp:Literal ID="lFullDescription" runat="server" />
                            <div class="clear-10">
                            </div>
                            <asp:Literal ID="lTableofContents" runat="server" />
                        </div>
                        <%--//\--%>
                    </div>
                    <div style="text-align: left; padding-top: 15px; color: #f37032; font-weight: bold;">
                        Quick Facts
                    </div>
                    <div class="clear-10">
                    </div>
                    <div style="text-align: left; font-weight: bold;">
                        <table>
                            <tr>
                                <td>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblYear" Text="Year" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrYear"></asp:Literal></div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblOrig" Text="Orig. Imprint" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrOrigPrint"></asp:Literal>
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblPeriod" Text="Period" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrPeriod"></asp:Literal></div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblCategory" Text="Category" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrCategory"></asp:Literal></div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblGenre" Text="Genre" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrGenre"></asp:Literal></div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblSeries" Text="Series" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrSeries"></asp:Literal>
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblGrade" runat="server" Text="Grade"></asp:Label></div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="lGrade"></asp:Literal></div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblTextLang" Text="Text Lang" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrText"></asp:Literal></div>
                                    </div>
                                    <div style="clear: both">
                                        <div style="float: left; width: 100px;">
                                            <asp:Label ID="lblCopyrightYear" Text="Copyright Year" runat="server"></asp:Label>
                                        </div>
                                        <div style="color: #58595B; width: 350px; float: left;">
                                            <asp:Literal runat="server" ID="ltrCopyrightYear"></asp:Literal></div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                    <div style="font-weight: bold; padding-top: 10px;">
                        <div>
                            <asp:Label ID="lblDuration" runat="server" Text="Duration -"></asp:Label>
                            <asp:Literal runat="server" ID="ltrDuration"></asp:Literal>
                        </div>
                        <div>
                            <asp:Label ID="lblInstrument" runat="server" Text="Instrumentation –"></asp:Label>
                            <span style="color: #0068a2">
                                <asp:Literal runat="server" ID="ltrInstrumention"></asp:Literal></span>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div style="padding-top: 10px;">
                        <%-- <table>
                            <tr>
                                <td style="width: 200px">--%>
                        <div style="float: left;">
                            <div id="divListenToTheSample" runat="server" style="display: none;">
                                <%--<div style="float: left;">
                                    <img src="../App_Themes/darkOrange/images/icon_headphone.png" align="middle" />
                                </div>
                                <div style="float: left; padding-top: 5px; color: #0068a2;">
                                    Listen to the sample
                                </div>--%>
                                <div style="margin-right: 30px; padding-top: 5px">
                                    <asp:DataList ID="dlListenMusics" runat="server" RepeatDirection="Vertical"
                                        OnItemDataBound="dlListenMusics_ItemDataBound">
                                        <ItemTemplate>
                                            <div style="float: left;">
                                                <asp:HyperLink ID="hpIconListenSampleMusic" runat="server" Target="_blank">
                                                    <img src="../App_Themes/darkOrange/images/icon_headphone.png" align="middle" />
                                               </asp:HyperLink>
                                            </div>
                                            <div style="float: left; padding-top: 5px; color: #0068a2;">
                                                &nbsp;<asp:HyperLink ID="hpListenSampleMusic" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                            <div style="clear:both"></div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <%-- </td>
                                <td>--%>
                        <div style="float: left;">
                            <asp:HyperLink ID="hplPreviewMusic" runat="server" Target="_blank">
                                <div id="divPreviewMusic" runat="server" style="display: none;">
                                    <div style="float: left;">
                                        <img src="../App_Themes/darkOrange/images/icon_music.png" align="middle" />
                                    </div>
                                    <div style="float: left; padding-top: 5px; color: #0068a2;">
                                        <%--<a href=""><span style="color: #0068a2">&nbsp;Preview music</span></a>--%>
                                        &nbsp;Preview music
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </asp:HyperLink>
                        </div>
                        <%-- </td>
                            </tr>
                        </table>--%>
                    </div>
                    <div class="clear">
                    </div>
                    <div>
                        <div style="text-align: left; padding-top: 15px; color: rgb(243, 112, 50); font-weight: bold;">
                            Rating</div>
                        <nopCommerce:ProductRating ID="ctrlProductRating" runat="server"></nopCommerce:ProductRating>
                    </div>
                </div>
                <div style="width: 147px; float: right; padding-top: 7px;">
                    <div>
                        <div>
                            <div class="Box5_top1" style="">
                            </div>
                            <div class="Box5_top2" style="width: 131px;">
                            </div>
                            <div class="Box5_top3" style="">
                            </div>
                        </div>
                        <div style="background-color: #e5eff9; width: 147px; float: left; text-align: center;
                            padding: 10x 0px 0px 0px">
                            <nopCommerce:ProductVariantsInGrid ID="ctrlProductVariantsInGrid" runat="server">
                            </nopCommerce:ProductVariantsInGrid>
                            <div class="clear-10">
                            </div>
                            <nopCommerce:ProductAddToCompareList ID="ctrlProductAddToCompareList" runat="server">
                            </nopCommerce:ProductAddToCompareList>
                            <div class="clear">
                            </div>
                            <nopCommerce:ProductShareButton ID="ctrlProductShareButton" runat="server" />
                        </div>
                        <div>
                            <div class="Box5_bot1" style="">
                            </div>
                            <div class="Box5_bot2" style="width: 131px;">
                            </div>
                            <div class="Box5_bot3" style="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear-10">
            </div>
        </div>
    </div>
</div>
<%--<div class="product-details-info">
    <div class="picture">
        <asp:Image ID="defaultImage" runat="server" />
    </div>
    <div class="overview">
        <h3 class="productname">
            <asp:Literal ID="lProductName" runat="server" />
        </h3>
        <br />
        <div class="shortdescription">
            <asp:Literal ID="lShortDescription" runat="server" />
        </div>
        <asp:ListView ID="lvProductPictures" runat="server" GroupItemCount="3">
            <LayoutTemplate>
                <table>
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
        <div class="clear">
        </div>
        <nopCommerce:ProductShareButton ID="ctrlProductShareButton" runat="server" />
    </div>
    <div class="fulldescription">
        <asp:Literal ID="lFullDescription" runat="server" />
    </div>
</div>--%>