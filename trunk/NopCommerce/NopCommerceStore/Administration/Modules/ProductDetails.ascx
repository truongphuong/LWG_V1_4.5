<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ProductDetailsControl" CodeBehind="ProductDetails.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductInfoEdit" Src="ProductInfoEdit.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductVariants" Src="ProductVariants.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductSEO" Src="ProductSEO.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductCategory" Src="ProductCategory.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductManufacturer" Src="ProductManufacturer.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="RelatedProducts" Src="RelatedProducts.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductPictures" Src="ProductPictures.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductVideos" Src="ProductVideos.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductAudios" Src="ProductAudios.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductSpecifications" Src="ProductSpecifications.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>
<%@ Register Src="~/Administration/Modules/ProductInfoAddCatalogLWG.ascx" TagName="ProductInfoAddCatalogLWG" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/CatalogComposer.ascx" TagName="CatalogComposer" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductInfoAddCatalogLWGMultiFields.ascx" TagName="ProductInfoAddCatalogLWGMultiFields" TagPrefix="ctl" %>

<div class="section-header">
    <div class="title">
        <img src="Common/ico-catalog.png" alt="<%=GetLocaleResourceString("Admin.ProductDetails.EditProductDetails")%>" />
        <%=GetLocaleResourceString("Admin.ProductDetails.EditProductDetails")%>
        <a href="Products.aspx" title="<%=GetLocaleResourceString("Admin.ProductDetails.BackToProductList")%>">
            (<%=GetLocaleResourceString("Admin.ProductDetails.BackToProductList")%>)</a>
    </div>
    <div class="options">
        <asp:Button ID="btnDuplicate" runat="server" CssClass="adminButtonBlue" Text="<% $NopResources:Admin.ProductDetails.BtnDuplicate.Text %>" OnClick="BtnDuplicate_OnClick" ToolTip="<% $NopResources:Admin.ProductDetails.BtnDuplicate.Tooltip %>" />
        <asp:Button ID="SaveButton" runat="server" CssClass="adminButtonBlue" Text="<% $NopResources:Admin.ProductDetails.SaveButton.Text %>"
            OnClick="SaveButton_Click" ToolTip="<% $NopResources:Admin.ProductDetails.SaveButton.Tooltip %>" />
        <asp:Button ID="DeleteButton" runat="server" CssClass="adminButtonBlue" Text="<% $NopResources:Admin.ProductDetails.DeleteButton.Text %>"
            OnClick="DeleteButton_Click" CausesValidation="false" ToolTip="<% $NopResources:Admin.ProductDetails.DeleteButton.Tooltip %>" />
    </div>
</div>
<ajaxToolkit:TabContainer runat="server" ID="ProductTabs" ActiveTabIndex="0">
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductInfo" HeaderText="<% $NopResources:Admin.ProductDetails.ProductInfo %>">
        <ContentTemplate>
            <nopCommerce:ProductInfoEdit ID="ctrlProductInfoEdit" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductSEO" HeaderText="<% $NopResources:Admin.ProductDetails.SEO %>">
        <ContentTemplate>
            <nopCommerce:ProductSEO ID="ctrlProductSEO" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductVariants" HeaderText="<% $NopResources:Admin.ProductDetails.ProductVariants %>">
        <ContentTemplate>
            <nopCommerce:ProductVariants ID="ctrlProductVariants" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlCategoryMappings" HeaderText="<% $NopResources:Admin.ProductDetails.CategoryMappings %>">
        <ContentTemplate>
            <nopCommerce:ProductCategory ID="ctrlProductCategory" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlManufacturerMappings" HeaderText="<% $NopResources:Admin.ProductDetails.ManufacturerMappings %>">
        <ContentTemplate>
            <nopCommerce:ProductManufacturer ID="ctrlProductManufacturer" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlRelatedProducts" HeaderText="<% $NopResources:Admin.ProductDetails.RelatedProducts %>">
        <ContentTemplate>
            <nopCommerce:RelatedProducts ID="ctrlRelatedProducts" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlPictures" HeaderText="<% $NopResources:Admin.ProductDetails.Pictures %>">
        <ContentTemplate>
            <nopCommerce:ProductPictures ID="ctrlProductPictures" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>   
    <ajaxToolkit:TabPanel runat="server" ID="pnlVideos" HeaderText="<% $NopResources:Admin.ProductDetails.Videos %>">
        <ContentTemplate>
            <nopCommerce:ProductVideos ID="ctrlProductVideos" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" ID="pnlAudios" HeaderText="<% $NopResources:Admin.ProductDetails.Audios %>">
        <ContentTemplate>
            <nopCommerce:ProductAudios ID="ctrlAudios" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductSpecification" HeaderText="<% $NopResources:Admin.ProductDetails.ProductSpecification %>">
        <ContentTemplate>
            <nopCommerce:ProductSpecifications ID="ctrlProductSpecifications" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <%--//\--%>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProdutExtend1" HeaderText="Extra Attributes 1">
        <ContentTemplate>
            <ctl:ProductInfoAddCatalogLWG ID="ctlProductInfoAddCatalogLWG" runat="server" />    
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProdutExtend2" HeaderText="Extra Attributes 2">
        <ContentTemplate>
            <ctl:ProductInfoAddCatalogLWGMultiFields ID="ctlProductInfoAddCatalogLWGMultiFields" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlComposer" HeaderText="Composer">
        <ContentTemplate>
            <ctl:CatalogComposer id="ctlCatalogComposer" runat="server"></ctl:CatalogComposer>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>

<nopCommerce:ConfirmationBox runat="server" ID="cbDelete" TargetControlID="DeleteButton" YesText="<% $NopResources:Admin.Common.Yes %>" NoText="<% $NopResources:Admin.Common.No %>" ConfirmText="<% $NopResources:Admin.Common.AreYouSure %>" />

<ajaxToolkit:ConfirmButtonExtender ID="cbeDuplicate" runat="server" DisplayModalPopupID="mpeDuplicate" TargetControlID="btnDuplicate" />
<ajaxToolkit:ModalPopupExtender ID="mpeDuplicate" runat="server" TargetControlID="btnDuplicate" PopupControlID="pnlDuplicatePopup" OkControlID="btnDuplicateOk" CancelControlID="btnDuplicateCancel" BackgroundCssClass="modalBackground" />
<asp:Panel ID="pnlDuplicatePopup" runat="server" Style="display: none; width: 250px; background-color: White;
    border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
    <div style="text-align: center;">
        <table style="text-align: left;">
            <tr>
                <td>
                    <asp:Label runat="server" Text="<% $NopResources:Admin.ProductInfo.ProductName %>" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtProductCopyName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProductCopyName" ErrorMessage="*" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="<% $NopResources:Admin.ProductInfo.Published %>" />
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="cbIsProductCopyPublished" Checked="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="<% $NopResources:Admin.ProductInfo.CopyImages %>" />
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="cbCopyImages" Checked="true" />
                </td>
            </tr>
        </table>
        <p>
        </p>
        <asp:Button ID="btnDuplicateOk" runat="server" Text="<% $NopResources:Admin.Common.Yes %>" CssClass="adminButton" CausesValidation="false" />
        <asp:Button ID="btnDuplicateCancel" runat="server" Text="<% $NopResources:Admin.Common.No %>" CssClass="adminButton" CausesValidation="false" />
    </div>
</asp:Panel>