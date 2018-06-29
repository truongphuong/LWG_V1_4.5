<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.GlobalSettingsControl"
    CodeBehind="GlobalSettings.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="NumericTextBox" Src="NumericTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="DecimalTextBox" Src="DecimalTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="EmailTextBox" Src="EmailTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ThemeSelector" Src="ThemeSelectorControl.ascx" %>
<div class="section-header">
    <div class="title">
        <img src="Common/ico-configuration.png" alt="<%=GetLocaleResourceString("Admin.GlobalSettings.Title")%>" />
        <%=GetLocaleResourceString("Admin.GlobalSettings.Title")%>
    </div>
    <div class="options">
        <asp:Button runat="server" Text="<% $NopResources:Admin.GlobalSettings.SaveButton.Text %>"
            CssClass="adminButtonBlue" ID="btnSave" OnClick="btnSave_Click" ToolTip="<% $NopResources:Admin.GlobalSettings.SaveButton.Tooltip %>" />
    </div>
</div>
<div>

    <script type="text/javascript">
        $(document).ready(function() {
            toggleCustomersAllowedToUploadAvatars();
            toggleProductsAlsoPurchased();
            toggleRecentlyViewedProducts();
            toggleRecentlyAddedProducts();
            toggleShowBestsellersOnHomePage();
            toggleSMSAlerts();
            toggleLiveChat();
        });

        function toggleCustomersAllowedToUploadAvatars() {
            if (getE('<%=cbCustomersAllowedToUploadAvatars.ClientID %>').checked) {
                $('#pnlDefaultAvatarEnabled').show();
            }
            else {
                $('#pnlDefaultAvatarEnabled').hide();
            }
        }

        function toggleLiveChat() {
            if (getE('<%=cbLiveChatEnabled.ClientID %>').checked) {
                $('#pnlLiveChatBtnCode').show();
                $('#pnlLiveChatMonCode').show();
            }
            else {
                $('#pnlLiveChatBtnCode').hide();
                $('#pnlLiveChatMonCode').hide();
            }
        }

        function toggleSMSAlerts() {
            if (getE('<%=cbIsSMSAlertsEnabled.ClientID %>').checked) {
                $('#pnlSMSAlertsPhoneNumber').show();
                $('#pnlSMSAlertsClickatellAPIId').show();
                $('#pnlSMSAlertsClickatellUsername').show();
                $('#pnlSMSAlertsClickatellPassword').show();
                $('#pnlSMSAlertsTest_0').show();
                $('#pnlSMSAlertsTest_1').show();
                $('#pnlSMSAlertsTest_2').show();
                $('#pnlSMSAlertsTest_3').show();
                $('#pnlSMSAlertsTest_4').show();
            }
            else {
                $('#pnlSMSAlertsPhoneNumber').hide();
                $('#pnlSMSAlertsClickatellAPIId').hide();
                $('#pnlSMSAlertsClickatellUsername').hide();
                $('#pnlSMSAlertsClickatellPassword').hide();
                $('#pnlSMSAlertsTest_0').hide();
                $('#pnlSMSAlertsTest_1').hide();
                $('#pnlSMSAlertsTest_2').hide();
                $('#pnlSMSAlertsTest_3').hide();
                $('#pnlSMSAlertsTest_4').hide();
            }
        }

        function toggleProductsAlsoPurchased() {
            if (getE('<%=cbProductsAlsoPurchased.ClientID %>').checked) {
                $('#pnlProductsAlsoPurchasedNumber').show();
            }
            else {
                $('#pnlProductsAlsoPurchasedNumber').hide();
            }
        }

        function toggleRecentlyViewedProducts() {
            if (getE('<%=cbRecentlyViewedProductsEnabled.ClientID %>').checked) {
                $('#pnlRecentlyViewedProductsNumber').show();
            }
            else {
                $('#pnlRecentlyViewedProductsNumber').hide();
            }
        }

        function toggleRecentlyAddedProducts() {
            if (getE('<%=cbRecentlyAddedProductsEnabled.ClientID %>').checked) {
                $('#pnlRecentlyAddedProductsNumber').show();
            }
            else {
                $('#pnlRecentlyAddedProductsNumber').hide();
            }
        }

        function toggleShowBestsellersOnHomePage() {
            if (getE('<%=cbShowBestsellersOnHomePage.ClientID %>').checked) {
                $('#pnlShowBestsellersOnHomePageNumber').show();
            }
            else {
                $('#pnlShowBestsellersOnHomePageNumber').hide();
            }
        }
    </script>

    <ajaxToolkit:TabContainer runat="server" ID="CommonSettingsTabs" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" ID="pnlGeneral" HeaderText="<% $NopResources:Admin.GlobalSettings.General.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblStoreName" Text="<% $NopResources:Admin.GlobalSettings.General.StoreName %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.General.StoreName.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtStoreName" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.General.ErrorMessage %>">
                            </nopCommerce:SimpleTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblStoreUrl" Text="<% $NopResources:Admin.GlobalSettings.General.StoreUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.General.StoreUrl.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtStoreURL" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.General.StoreUrl.ErrorMessage %>">
                            </nopCommerce:SimpleTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblStoreClosed" Text="<% $NopResources:Admin.GlobalSettings.General.StoreClosed %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.General.StoreClosed.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbStoreClosed"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAnonymousCheckout" Text="<% $NopResources:Admin.GlobalSettings.General.AnonymousCheckout %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.General.AnonymousCheckout.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbAnonymousCheckoutAllowed"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblUseOnePageCheckout" Text="<% $NopResources:Admin.GlobalSettings.General.UseOnePageCheckout %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.General.UseOnePageCheckout.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbUseOnePageCheckout"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblCheckoutTermsOfService" Text="<% $NopResources:Admin.GlobalSettings.General.TermsOfService %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.General.TermsOfService.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbCheckoutTermsOfService"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlSEODisplay" HeaderText="<% $NopResources:Admin.GlobalSettings.SEODisplay.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblStoreNamePrefix" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.StoreNamePrefix %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.StoreNamePrefix.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbStoreNameInTitle"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblDefaultTitle" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.DefaultTitle %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.DefaultTitle.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtDefaulSEOTitle" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.ErrorMessage %>">
                            </nopCommerce:SimpleTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblDefaultMetaDescription" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.MetaDescription %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.MetaDescription.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtDefaulSEODescription" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.MetaDescription.ErrorMessage %>">
                            </nopCommerce:SimpleTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblDefaultMetaKeywords" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.MetaKeywords %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.MetaKeywords.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtDefaulSEOKeywords" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.MetaKeywords.ErrorMessage %>">
                            </nopCommerce:SimpleTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblPublicStoreTheme" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.PublicStoreTheme %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.PublicStoreTheme.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:ThemeSelector runat="server" ID="ctrlThemeSelector" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel ID="lblFavicon" runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.Favicon %>" ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.Favicon.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:Image runat="server" ID="imgFavicon" AlternateText="favicon" />
                            <asp:FileUpload runat="server" ID="fileFavicon" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowWelcomeMessage" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.ShowWelcomeMessage %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.ShowWelcomeMessage.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowWelcomeMessage" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblNewsRssLink" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.NewsRssLink %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.NewsRssLink.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowNewsHeaderRssURL" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblBlogRssLink" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.BlogRssLink %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.BlogRssLink.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowBlogHeaderRssURL" />
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                </table>
                <p>
                    <strong>
                        <%=GetLocaleResourceString("Admin.GlobalSettings.SEODisplay.UrlRewriting")%></strong>
                </p>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblProductUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.ProductUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.ProductUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtProductUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.ProductUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblCategoryUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.CategoryUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.CategoryUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtCategoryUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.CategoryUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblManufacturerUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.ManufacturerUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.ManufacturerUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtManufacturerUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.ManufacturerUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblNewsUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.NewsUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.NewsUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtNewsUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.NewsUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblBlogUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.BlogUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.BlogUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtBlogUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.BlogUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblTopicUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.TopicUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.TopicUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtTopicUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.TopicUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblForumUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtForumUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblForumGroupUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumGroupUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumGroupUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtForumGroupUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumGroupUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblForumTopicUrlRewriteFormat" Text="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumTopicUrl %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumTopicUrl.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:SimpleTextBox runat="server" ID="txtForumTopicUrlRewriteFormat" CssClass="adminInput"
                                ErrorMessage="<% $NopResources:Admin.GlobalSettings.SEODisplay.ForumTopicUrl.ErrorMessage %>" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlMedia" HeaderText="<% $NopResources:Admin.GlobalSettings.Media.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblMaxImageSize" Text="<% $NopResources:Admin.GlobalSettings.Media.MaxImageSize %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.MaxImageSize.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtMaxImageSize"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.MaxImageSize.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.MaxImageSize.RangeErrorMessage %>"
                                Width="50px" />
                            pixels
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblProductThumbSize" Text="<% $NopResources:Admin.GlobalSettings.Media.ProductThumbSize %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.ProductThumbSize.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductThumbSize"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ProductThumbSize.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ProductThumbSize.RangeErrorMessage %>"
                                Width="50px" />
                            pixels
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblProductDetailSize" Text="<% $NopResources:Admin.GlobalSettings.Media.ProductDetailSize %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.ProductDetailSize.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductDetailSize"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ProductDetailSize.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ProductDetailSize.RangeErrorMessage %>"
                                Width="50px" />
                            pixels
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblProductVariantSize" Text="<% $NopResources:Admin.GlobalSettings.Media.ProductVariantSize %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.ProductVariantSize.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductVariantSize"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ProductVariantSize.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ProductVariantSize.RangeErrorMessage %>"
                                Width="50px" />
                            pixels
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblCategoryThumbSize" Text="<% $NopResources:Admin.GlobalSettings.Media.CategoryThumbSize %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.CategoryThumbSize.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtCategoryThumbSize"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.CategoryThumbSize.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.CategoryThumbSize.RangeErrorMessage %>"
                                Width="50px" />
                            pixels
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblManufacturerThumbSize" Text="<% $NopResources:Admin.GlobalSettings.Media.ManufacturerThumbSize %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.ManufacturerThumbSize.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtManufacturerThumbSize"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ManufacturerThumbSize.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.ManufacturerThumbSize.RangeErrorMessage %>"
                                Width="50px" />
                            pixels
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowCartImages" Text="<% $NopResources:Admin.GlobalSettings.Media.ShowCartImages %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.ShowCartImages.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowCartImages" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowWishListImages" Text="<% $NopResources:Admin.GlobalSettings.Media.ShowWishListImages %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.ShowWishListImages.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowWishListImages" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowAdminProductImages" Text="<% $NopResources:Admin.GlobalSettings.Media.ShowAdminProductImages %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.ShowAdminProductImages.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowAdminProductImages" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShoppingCartThumbnailSize" Text="<% $NopResources:Admin.GlobalSettings.Media.CartThumbSize %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.CartThumbSize.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtShoppingCartThumbSize"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.CartThumbSize.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Media.CartThumbSize.RangeErrorMessage %>"
                                Width="50px" />
                            pixels
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblPdfLogo" Text="<% $NopResources:Admin.GlobalSettings.Media.PdfLogo %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Media.PdfLogo.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:Image runat="server" ID="imgPdfLogoPreview" AlternateText="Logo preview" />
                            <br />
                            <asp:Button ID="btnPdfLogoRemove" CssClass="adminInput" CausesValidation="false"
                                runat="server" Text="<% $NopResources:Admin.GlobalSettings.Media.PdfLogoRemove %>"
                                OnClick="BtnPdfLogoRemove_OnClick" Visible="false" ToolTip="<% $NopResources:Admin.GlobalSettings.Media.PdfLogoRemove.Tooltip %>" />
                            <br />
                            <asp:FileUpload runat="server" ID="uplPdfLogo" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlMailSettings" HeaderText="<% $NopResources:Admin.GlobalSettings.MailSettings.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblStoreAdminEmail" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.Email %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.Email.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:EmailTextBox runat="server" CssClass="adminInput" ID="txtAdminEmailAddress">
                            </nopCommerce:EmailTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblStoreAdminEmailDisplayName" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.EmailDisplayName %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.EmailDisplayName.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox ID="txtAdminEmailDisplayName" CssClass="adminInput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblHost" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.EmailHost %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.EmailHost.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox ID="txtAdminEmailHost" CssClass="adminInput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblPort" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.EmailPort %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.EmailPort.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox ID="txtAdminEmailPort" CssClass="adminInput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblUser" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.User %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.User.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox ID="txtAdminEmailUser" CssClass="adminInput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblPassword" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.Password %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.Password.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox ID="txtAdminEmailPassword" CssClass="adminInput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblMailSSL" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.SSL %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.SSL.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbAdminEmailEnableSsl" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblUseDefaultCredentials" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.DefaultCredentials %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.DefaultCredentials.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbAdminEmailUseDefaultCredentials" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p>
                                <strong>
                                    <%=GetLocaleResourceString("Admin.GlobalSettings.MailSettings.SendTestEmail")%></strong>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblTestEmailTo" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.TestEmailTo %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.TestEmailTo.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:EmailTextBox runat="server" CssClass="adminInput" ID="txtSendEmailTo"
                                ValidationGroup="SendTestEmail"></nopCommerce:EmailTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                        </td>
                        <td class="adminData">
                            <asp:Button ID="btnSendTestEmail" runat="server" Text="<% $NopResources:Admin.GlobalSettings.MailSettings.SendTestEmailButton.Text %>"
                                CssClass="adminButton" OnClick="btnSendTestEmail_Click" ValidationGroup="SendTestEmail"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.MailSettings.SendTestEmailButton.Tooltip %>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                        </td>
                        <td class="adminData" style="color: red">
                            <asp:Label ID="lblSendTestEmailResult" runat="server" EnableViewState="false">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlSMSAlerts" HeaderText="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle" colspan="2">
                            To receive an SMS notification when an order is placed from your store you need
                            to follow a few simple steps, which are shown below:
                            <ul>
                                <li><a href="http://www.clickatell.com" target='_blank'>Register for a Clickatell account
                                    here</a></li>
                                <li>Clickatell works with all countries and includes 10 free messages so you can test
                                    SMS notifications</li>
                                <li>Fill in the form below with your Clickatell account details, including the number
                                    you want the notification messages to be sent to</li>
                                <li>Click 'Save' button</li>
                                <li>Now when you receive a new order, an SMS text message will be sent to the number
                                    you enter below automatically</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblIsSMSAlertsEnabled" Text="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Enabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Enabled.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbIsSMSAlertsEnabled" Checked="false" />
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsPhoneNumber">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblSMSAlertsPhoneNumber" Text="<% $NopResources:Admin.GlobalSettings.SMSAlerts.PhoneNumber %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SMSAlerts.PhoneNumber.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox runat="server" ID="txtSMSAlertsPhoneNumber" />
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsClickatellAPIId">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblSMSAlertsClickatellAPIId" Text="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Clickatell.APIID %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Clickatell.APIID.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox runat="server" ID="txtSMSAlertsClickatellAPIId" />
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsClickatellUsername">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblSMSAlertsClickatellUsername" Text="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Clickatell.Username %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Clickatell.Username.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox runat="server" ID="txtSMSAlertsClickatellUsername" />
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsClickatellPassword">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblSMSAlertsClickatellPassword" Text="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Clickatell.Password %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SMSAlerts.Clickatell.Password.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox runat="server" ID="txtSMSAlertsClickatellPassword" />
                        </td>
                    </tr>
                    <tr class="adminSeparator" id="pnlSMSAlertsTest_0">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsTest_1">
                        <td colspan="2">
                            <p>
                                <strong>
                                    <%=GetLocaleResourceString("Admin.GlobalSettings.SMSAlerts.SendTestSMS")%>
                                </strong>
                            </p>
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsTest_2">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblTestPhone" Text="<% $NopResources:Admin.GlobalSettings.SMSAlerts.TestPhone %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SMSAlerts.TestPhone.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox runat="server" CssClass="adminInput" ID="txtTestPhone" ValidationGroup="SendTestSMS" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTestPhone" ErrorMessage="*"
                                ValidationGroup="SendTestSMS" />
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsTest_3">
                        <td class="adminTitle">
                        </td>
                        <td class="adminData">
                            <asp:Button ID="btnSendTestSMS" runat="server" Text="<% $NopResources:Admin.GlobalSettings.SMSAlerts.SendTestSMSButton %>"
                                CssClass="adminButton" OnClick="BtnSendTestSMS_OnClick" ValidationGroup="SendTestSMS"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.SMSAlerts.SendTestSMSButton.Tooltip %>" />
                        </td>
                    </tr>
                    <tr id="pnlSMSAlertsTest_4">
                        <td class="adminTitle">
                        </td>
                        <td class="adminData" style="color: red">
                            <asp:Label ID="lblSendTestSmsResult" runat="server" EnableViewState="false" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlLiveChat" HeaderText="<% $NopResources:Admin.GlobalSettings.LiveChat.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle" colspan="2">
                            Please find our step by step set up guide detailed below:
                            <ul>
                                <li><b>Download</b>. Download the software here: <a href="http://solutions.liveperson.com/help/download.asp"
                                    target='_blank'>http://solutions.liveperson.com/help/download.asp</a> </li>
                                <li><b>Learn how to setup</b>. Getting started for Pro Administrators: <a href="http://solutions.liveperson.com/training/gettingstarted_pro_admin.asp"
                                    target='_blank'>http://solutions.liveperson.com/training/gettingstarted_pro_admin.asp</a>
                                </li>
                                <li><b>Apply Knowledge</b>. Login in your Admin Console, configure your account and
                                    embed your pages: <a href="https://server.iad.liveperson.net/hc/web/public/pub/ma/lp/login.jsp"
                                        target='_blank'>https://server.iad.liveperson.net/hc/web/public/pub/ma/lp/login.jsp</a>
                                    <ul>
                                        <li>Click on the 'Admin Console' button on the toolbar. </li>
                                        <li>Click on 'Account Setup' and then 'Page Code Builder'. </li>
                                        <li>Follow the wizard to generate the monitor code and button tag code you wish to use
                                            on your store. </li>
                                        <li>Paste the provided values from the 'Button Tag' and 'Monitor Tag' text boxes in
                                            to the appropriate boxes below. </li>
                                    </ul>
                                </li>
                                <li><b>Learn how to use the Operator Console (Agent)</b>. Getting started for Pro Operators:
                                    <a href="http://solutions.liveperson.com/training/gettingstarted_pro_op.asp" target='_blank'>
                                        http://solutions.liveperson.com/training/gettingstarted_pro_op.asp</a> </li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblLiveChatEnabled" Text="<% $NopResources:Admin.GlobalSettings.LiveChat.Enabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.LiveChat.Enabled.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbLiveChatEnabled" Checked="false" TextAlign="Left" />
                        </td>
                    </tr>
                    <tr id="pnlLiveChatBtnCode">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblLiveChatBtnCode" Text="<% $NopResources:Admin.GlobalSettings.LiveChat.BtnCode %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.LiveChat.BtnCode.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox runat="server" ID="txtLiveChatBtnCode" TextMode="MultiLine" Rows="5"
                                CssClass="adminInput" />
                        </td>
                    </tr>
                    <tr id="pnlLiveChatMonCode">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblLiveChatMonCode" Text="<% $NopResources:Admin.GlobalSettings.LiveChat.MonCode %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.LiveChat.MonCode.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox runat="server" ID="txtLiveChatMonCode" TextMode="MultiLine" Rows="5"
                                CssClass="adminInput" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlRewardPoints" HeaderText="<% $NopResources:Admin.GlobalSettings.RewardPoints.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle" colspan="2">
                            The Reward Points Program allows customers to earn points for certain actions they
                            take on the site. Points are awarded based on making purchases and customer actions
                            such as registration.
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRewardPointsEnabled" Text="<% $NopResources:Admin.GlobalSettings.RewardPoints.Enabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.RewardPoints.Enabled.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbRewardPointsEnabled" Checked="false" TextAlign="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRewardPointsRate" Text="<% $NopResources:Admin.GlobalSettings.RewardPoints.Rate %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.RewardPoints.Rate.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <%=GetLocaleResourceString("Admin.GlobalSettings.RewardPoints.Rate.Tooltip2")%>
                            <nopCommerce:DecimalTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtRewardPointsRate"
                                RequiredErrorMessage="Reward points rate is required" MinimumValue="0" MaximumValue="999999"
                                RangeErrorMessage="The value must be from 0 to 999999"></nopCommerce:DecimalTextBox>
                            <%=CurrencyManager.PrimaryStoreCurrency.CurrencyCode%>
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                            <%=GetLocaleResourceString("Admin.GlobalSettings.RewardPoints.EarningRewardPoints")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRewardPointsForRegistration" Text="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForRegistration %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForRegistration.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtRewardPointsForRegistration"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForRegistration.RequiredErrorMessage %>"
                                MinimumValue="0" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForRegistration.RangeErrorMessage %>"
                                Width="50px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRewardPointsForPurchases" Text="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            Each
                            <nopCommerce:DecimalTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtRewardPointsForPurchases_Amount"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases_Amount.RequiredErrorMessage %>"
                                MinimumValue="0" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases_Amount.RangeErrorMessage %>">
                            </nopCommerce:DecimalTextBox>
                            <%=CurrencyManager.PrimaryStoreCurrency.CurrencyCode%>
                            spent will earn
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtRewardPointsForPurchases_Points"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases_Points.RequiredErrorMessage %>"
                                MinimumValue="0" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases_Points.RangeErrorMessage %>"
                                Width="50px" />
                            reward points.
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblRewardPointsAwardedOrderStatus" Text="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases.Awarded %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases.Awarded.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:DropDownList ID="ddlRewardPointsAwardedOrderStatus" runat="server" CssClass="adminInput">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblRewardPointsCanceledOrderStatus"
                                Text="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases.Canceled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.RewardPoints.PointsForPurchases.Canceled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:DropDownList ID="ddlRewardPointsCanceledOrderStatus" runat="server" CssClass="adminInput">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlSecurity" HeaderText="<% $NopResources:Admin.GlobalSettings.Security.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblAllowedIPList" Text="<% $NopResources:Admin.GlobalSettings.Security.AllowedIPList %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Security.AllowedIPList.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox ID="txtAllowedIPList" CssClass="adminInput" runat="server" />
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblEncryptionPrivateKey" Text="<% $NopResources:Admin.GlobalSettings.Security.PrivateKey %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Security.PrivateKey.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:TextBox ID="txtEncryptionPrivateKey" CssClass="adminInput" runat="server" ValidationGroup="EncryptionPrivateKey"></asp:TextBox>
                            <asp:Button ID="btnChangeEncryptionPrivateKey" runat="server" Text="<% $NopResources:Admin.GlobalSettings.Security.PrivateKeyButton %>"
                                CssClass="adminButton" OnClick="btnChangeEncryptionPrivateKey_Click" ValidationGroup="EncryptionPrivateKey">
                            </asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                        </td>
                        <td class="adminData" style="color: red">
                            <asp:Label ID="lblChangeEncryptionPrivateKeyResult" runat="server" EnableViewState="false">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblLoginCaptcha" Text="<% $NopResources:Admin.GlobalSettings.Security.LoginCaptcha %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Security.LoginCaptcha.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbEnableLoginCaptchaImage"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRegistrationCaptcha" Text="<% $NopResources:Admin.GlobalSettings.Security.RegistrationCaptcha %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Security.RegistrationCaptcha.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbEnableRegisterCaptchaImage"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlCustomerProfiles" HeaderText="<% $NopResources:Admin.GlobalSettings.Profiles.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblCustomerNameFormat" Text="<% $NopResources:Admin.GlobalSettings.Profiles.NameFormat %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.NameFormat.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:DropDownList ID="ddlCustomerNameFormat" runat="server" CssClass="adminInput">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblCustomersAllowedToUploadAvatars"
                                Text="<% $NopResources:Admin.GlobalSettings.Profiles.AllowedAvatars %>" ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.AllowedAvatars.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbCustomersAllowedToUploadAvatars" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr id="pnlDefaultAvatarEnabled">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblDefaultAvatarEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.DefaultAvatar %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.DefaultAvatar.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbDefaultAvatarEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowViewingProfiles" Text="<% $NopResources:Admin.GlobalSettings.Profiles.ViewingProfiles %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.ViewingProfiles.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbAllowViewingProfiles" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblShowCustomersLocation" Text="<% $NopResources:Admin.GlobalSettings.Profiles.ShowLocation %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.ShowLocation.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbShowCustomersLocation" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblShowCustomersJoinDate" Text="<% $NopResources:Admin.GlobalSettings.Profiles.ShowJoinDate %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.ShowJoinDate.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbShowCustomersJoinDate" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowPM" Text="<% $NopResources:Admin.GlobalSettings.Profiles.AllowPM %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.AllowPM.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbAllowPM" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowCustomersToSetTimeZone" Text="<% $NopResources:Admin.GlobalSettings.Profiles.AllowToSetTimeZone %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.AllowToSetTimeZone.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbAllowCustomersToSetTimeZone"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblCurrentTimeZoneInfo" Text="<% $NopResources:Admin.GlobalSettings.Profiles.CurrentTimeZone %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.CurrentTimeZone.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:Label runat="server" ID="lblCurrentTimeZone">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblDefaultStoreTimeZone" Text="<% $NopResources:Admin.GlobalSettings.Profiles.DefaultTimeZone %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.DefaultTimeZone.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:DropDownList runat="server" ID="ddlDefaultStoreTimeZone" CssClass="adminInputNoWidth">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                            <strong><%=GetLocaleResourceString("Admin.GlobalSettings.Profiles.FormFields.Title")%></strong>
                            <br />
                            <i><%=GetLocaleResourceString("Admin.GlobalSettings.Profiles.FormFields.Description")%></i>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffGenderEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.GenderEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.GenderEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffGenderEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffDateOfBirthEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.DateOfBirthEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.DateOfBirthEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffDateOfBirthEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffCompanyEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CompanyEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CompanyEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffCompanyEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffCompanyRequired" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CompanyRequired %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CompanyRequired.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffCompanyRequired" runat="server"></asp:CheckBox>
                        </td>
                    </tr>                  
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffStreetAddressEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddressEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddressEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffStreetAddressEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffStreetAddressRequired" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddressRequired %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddressRequired.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffStreetAddressRequired" runat="server"></asp:CheckBox>
                        </td>
                    </tr>        
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffStreetAddress2Enabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddress2Enabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddress2Enabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffStreetAddress2Enabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffStreetAddress2Required" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddress2Required %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StreetAddress2Required.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffStreetAddress2Required" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffPostCodeEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PostCodeEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PostCodeEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffPostCodeEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffPostCodeRequired" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PostCodeRequired %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PostCodeRequired.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffPostCodeRequired" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffCityEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CityEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CityEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffCityEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffCityRequired" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CityRequired %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CityRequired.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffCityRequired" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffCountryEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CountryEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.CountryEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffCountryEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffStateEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StateEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.StateEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffStateEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffPhoneEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PhoneEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PhoneEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffPhoneEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffPhoneRequired" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PhoneRequired %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.PhoneRequired.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffPhoneRequired" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffFaxEnabled" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.FaxEnabled %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.FaxEnabled.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffFaxEnabled" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblffFaxRequired" Text="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.FaxRequired %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Profiles.FormFields.FaxRequired.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox ID="cbffFaxRequired" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlOther" HeaderText="<% $NopResources:Admin.GlobalSettings.Other.Title %>">
            <ContentTemplate>
                <table class="adminContent">
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblUsernamesEnabled" Text="<% $NopResources:Admin.GlobalSettings.Other.Usernames %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.Usernames.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbUsernamesEnabled"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblTaxDisplayType" Text="<% $NopResources:Admin.GlobalSettings.Other.RegistrationMethod %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.RegistrationMethod.Other.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:DropDownList ID="ddlRegistrationMethod" runat="server" CssClass="adminInput">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowNavigationOnlyRegisteredCustomers"
                                Text="<% $NopResources:Admin.GlobalSettings.Other.NavigationOnlyRegisteredCustomers %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.NavigationOnlyRegisteredCustomers.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbAllowNavigationOnlyRegisteredCustomers"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblHidePricesForNonRegistered" Text="<% $NopResources:Admin.GlobalSettings.Other.HidePricesForNonRegistered %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.HidePricesForNonRegistered.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbHidePricesForNonRegistered"></asp:CheckBox>
                        </td>
                    </tr>                    
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblEnableDynamicPriceUpdate" Text="<% $NopResources:Admin.GlobalSettings.Other.EnableDynamicPriceUpdate %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.EnableDynamicPriceUpdate.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbEnableDynamicPriceUpdate"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowProductSorting" Text="<% $NopResources:Admin.GlobalSettings.Other.AllowProductSorting %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.AllowProductSorting.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbAllowProductSorting"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowShareButton" Text="<% $NopResources:Admin.GlobalSettings.Other.ShowShareButton %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.ShowShareButton.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowShareButton"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblUseImagesForLanguageSelection" Text="<% $NopResources:Admin.GlobalSettings.Other.UseImagesForLanguageSelection %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.UseImagesForLanguageSelection.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbUseImagesForLanguageSelection" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblCompareProducts" Text="<% $NopResources:Admin.GlobalSettings.Other.CompareProducts %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.CompareProducts.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbEnableCompareProducts"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblWishList" Text="<% $NopResources:Admin.GlobalSettings.Other.WishList %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.WishList.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbEnableWishlist"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblReOrderAllowed" Text="<% $NopResources:Admin.GlobalSettings.Other.ReOrderAllowed %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.ReOrderAllowed.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbIsReOrderAllowed" />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblEmailAFriend" Text="<% $NopResources:Admin.GlobalSettings.Other.EmailAFriend %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.EmailAFriend.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbEnableEmailAFriend"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowMiniShoppingCart" Text="<% $NopResources:Admin.GlobalSettings.Other.ShowMiniShoppingCart %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.ShowMiniShoppingCart.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowMiniShoppingCart"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblNotifyAboutNewProductReviews" Text="<% $NopResources:Admin.GlobalSettings.Other.NotifyNewProductReviews %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.NotifyNewProductReviews.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbNotifyAboutNewProductReviews"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblProductReviewsMustBeApproved" Text="<% $NopResources:Admin.GlobalSettings.Other.ProductReviewsMustBeApproved %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.ProductReviewsMustBeApproved.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbProductReviewsMustBeApproved"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowAnonymousUsersToReviewProduct"
                                Text="<% $NopResources:Admin.GlobalSettings.Other.AllowAnonymousUsersToReviewProduct %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.AllowAnonymousUsersToReviewProduct.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbAllowAnonymousUsersToReviewProduct"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowAnonymousUsersToEmailAFriend"
                                Text="<% $NopResources:Admin.GlobalSettings.Other.AllowAnonymousUsersToEmailAFriend %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.AllowAnonymousUsersToEmailAFriend.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbAllowAnonymousUsersToEmailAFriend"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ID="lblAllowAnonymousUsersToSetProductRatings"
                                Text="<% $NopResources:Admin.GlobalSettings.Other.AllowAnonymousUsersToSetProductRatings %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.AllowAnonymousUsersToSetProductRatings.Tooltip %>"
                                ToolTipImage="~/Administration/Common/ico-help.gif" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbAllowAnonymousUsersToSetProductRatings"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRecentlyViewedProductsEnabled" Text="<% $NopResources:Admin.GlobalSettings.Other.RecentlyViewedProducts %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.RecentlyViewedProducts.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbRecentlyViewedProductsEnabled"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr id="pnlRecentlyViewedProductsNumber">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRecentlyViewedProductsNumber" Text="<% $NopResources:Admin.GlobalSettings.Other.RecentlyViewedProductsNumber %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.RecentlyViewedProductsNumber.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtRecentlyViewedProductsNumber"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.RecentlyViewedProductsNumber.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.RecentlyViewedProductsNumber.RangeErrorMessage %>"
                                Width="50px" />
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRecentlyAddedProductsEnabled" Text="<% $NopResources:Admin.GlobalSettings.Other.RecentlyAddedProducts %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.RecentlyAddedProducts.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbRecentlyAddedProductsEnabled"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr id="pnlRecentlyAddedProductsNumber">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblRecentlyAddedProductsNumber" Text="<% $NopResources:Admin.GlobalSettings.Other.RecentlyAddedProductsNumber %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.RecentlyAddedProductsNumber.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtRecentlyAddedProductsNumber"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.RecentlyAddedProductsNumber.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.RecentlyAddedProductsNumber.RangeErrorMessage %>"
                                Width="50px" />
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowBestsellersOnHomePage" Text="<% $NopResources:Admin.GlobalSettings.Other.ShowBestsellersOnHomePage %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.ShowBestsellersOnHomePage.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbShowBestsellersOnHomePage"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr id="pnlShowBestsellersOnHomePageNumber">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblShowBestsellersOnHomePageNumber" Text="<% $NopResources:Admin.GlobalSettings.Other.ShowBestsellersOnHomePageNumber %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.ShowBestsellersOnHomePageNumber.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtShowBestsellersOnHomePageNumber"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.ShowBestsellersOnHomePageNumber.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.ShowBestsellersOnHomePageNumber.RangeErrorMessage %>"
                                Width="50px" />
                        </td>
                    </tr>
                    <tr class="adminSeparator">
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblProductsAlsoPurchased" Text="<% $NopResources:Admin.GlobalSettings.Other.AlsoPurchased %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.AlsoPurchased.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <asp:CheckBox runat="server" ID="cbProductsAlsoPurchased"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr id="pnlProductsAlsoPurchasedNumber">
                        <td class="adminTitle">
                            <nopCommerce:ToolTipLabel runat="server" ToolTipImage="~/Administration/Common/ico-help.gif"
                                ID="lblProductsAlsoPurchasedNumber" Text="<% $NopResources:Admin.GlobalSettings.Other.AlsoPurchasedNumber %>"
                                ToolTip="<% $NopResources:Admin.GlobalSettings.Other.AlsoPurchasedNumber.Tooltip %>" />
                        </td>
                        <td class="adminData">
                            <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductsAlsoPurchasedNumber"
                                RequiredErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.AlsoPurchasedNumber.RequiredErrorMessage %>"
                                MinimumValue="1" MaximumValue="999999" RangeErrorMessage="<% $NopResources:Admin.GlobalSettings.Other.AlsoPurchasedNumber.RangeErrorMessage %>"
                                Width="50px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</div>
