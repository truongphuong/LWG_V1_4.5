<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.RelatedProductsControl"
    CodeBehind="RelatedProducts.ascx.cs" %>
<div class="also-purchased-products-grid" style="text-align: left;">
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
            <span style="">
                <%=GetLocaleResourceString("Products.RelatedProducts")%></span>
        </div>
        <div style="background-color: #fff; color: Black; text-align: center;">
            <asp:DataList ID="dlRelatedProducts" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                RepeatLayout="Table" OnItemDataBound="dlRelatedProducts_ItemDataBound" ItemStyle-CssClass="item-box">
                <ItemTemplate>
                    <div class="item">
                        <div class="picture">
                            <asp:HyperLink ID="hlImageLink" runat="server" />
                        </div>
                        <div class="productTitle">
                            <asp:HyperLink ID="hlProduct" runat="server" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <div class="clear-20"></div>
        </div>
    </div>
</div>
