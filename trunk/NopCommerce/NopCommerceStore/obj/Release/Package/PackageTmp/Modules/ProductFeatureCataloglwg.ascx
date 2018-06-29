<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductFeatureCataloglwg.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Modules.ProductFeatureCataloglwgControl" %>
<div class="clear">
</div>
<div class="body">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="sm1" ScriptMode="Release" CompositeScript-ScriptMode="Release" />
    <ajaxToolkit:TabContainer runat="server" ID="ProductFeatureTabs" CssClass="ProductFeatureCataloglwg"
        ActiveTabIndex="0" Height="240px" Width="722px">
        <ajaxToolkit:TabPanel runat="server" ID="pnlBrand" HeaderText="Band">
            <ContentTemplate>
                <asp:DataList ID="dlBrand" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlBrand_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                                <asp:HyperLink ID="hlCatalogNo" runat ="server">
                                </asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" />
                            </div>
                            <table style="width: 100%">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="http://sandbox165.vinasource.com/category/54-band.aspx">See Complete Band Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlFullorchestra" HeaderText="Full Orchestra">
            <ContentTemplate>
                <asp:DataList ID="dlFullOrchestra" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlFullOrchestra_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="http://sandbox165.vinasource.com/category/62-full-orchestra.aspx">See Complete
                        Full Orchestra Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlStringOrchestra" HeaderText="String Orchestra">
            <ContentTemplate>
                <asp:DataList ID="dlStringOrchestra" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlStringOrchestra_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="http://sandbox165.vinasource.com/category/55-string-orchestra.aspx">See Complete
                        String Orchestra Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlkeyboards" HeaderText="Keyboards">
            <ContentTemplate>
                <asp:DataList ID="dlKeyboards" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlKeyboards_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="">See Complete Keyboards Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlVoice" HeaderText="Voice">
            <ContentTemplate>
                <asp:DataList ID="dlVoice" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlVoice_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="">See Complete Voice Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlPercussion" HeaderText="Percussion">
            <ContentTemplate>
                <asp:DataList ID="dlPercussion" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlPercussion_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="">See Complete Percussion Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlBrass" HeaderText="Brass">
            <ContentTemplate>
                <asp:DataList ID="dlBrass" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlBrass_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="">See Complete Brass Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlWoodwinds" HeaderText="Woodwinds">
            <ContentTemplate>
                <asp:DataList ID="dlWoodwinds" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlWoodwinds_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="">See Complete Woodwinds Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="pnlString" HeaderText="String">
            <ContentTemplate>
                <asp:DataList ID="dlString" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    RepeatLayout="Table" OnItemDataBound="dlString_ItemDataBound" ItemStyle-CssClass="item-box1">
                    <ItemTemplate>
                        <div class="product-item">
                            <div class="picture">
                            
                                <asp:HyperLink ID="hlImageLink" runat="server" />
                            </div>
                            <div class="product-title">
                            <asp:HyperLink ID="hlCatalogNo" runat ="server"></asp:HyperLink><br />
                                <asp:HyperLink ID="hlProduct" runat="server" /></div>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="price">
                                        <asp:Literal ID="lblPrice" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplImageBuyNow" ImageUrl="~/images/btn_buyNow.PNG" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div style="text-align: right; padding-right: 10px;">
                    <a href="">See Complete String Catalog</a></div>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    <div class="clear">
    </div>
    <div style="height: 7px;">
        <div class="ftb_bot1">
        </div>
        <div class="ftb_bot2" style="width: 708px;">
        </div>
        <div class="ftb_bot3">
        </div>
    </div>
</div>
