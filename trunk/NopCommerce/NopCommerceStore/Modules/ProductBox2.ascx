<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.ProductBox2Control"
    CodeBehind="ProductBox2.ascx.cs" %>
    <%@ Register TagPrefix="nopCommerce" TagName="ProductAttributes" Src="~/Modules/ProductAttributes.ascx" %>
<div>
    <div style="float: left; width: 150px; text-align: center;">
        <asp:HyperLink ID="hlImageLink" runat="server" />
       
    </div>
    <div style="float: left; width: 500px;">
        <b> <asp:HyperLink ID="hlCatalogNo" runat="server"></asp:HyperLink></b><br />
        <b><asp:HyperLink ID="hlProduct" runat="server" /></b><br />
        <div style="clear:both;">
        <asp:Label ID="lblOldPrice" runat="server" CssClass="oldproductPrice" />
        </div>
        <div style="clear:both;">
        <asp:Literal runat="server" ID="lShortDescription"></asp:Literal>
        </div>
        <div style="clear:both;">
        <asp:Label ID="lblPrice" runat="server" CssClass="productPrice" />
        </div>
        <div style="width: 70px;padding-top:10px;">
            <%--<div class="div_bntBuynow1" style="width: 5px;">
            </div>
            <div class="div_bntBuynow2" style="width: 60px;">--%>
                <asp:ImageButton runat="server" ID="btnAddToCart" OnCommand="btnAddToCart_Click" 
                    ValidationGroup="ProductDetails" CommandArgument='<%# Eval("ProductId") %>' ImageUrl="~/images/btn_buyNow.PNG" />
            <%--</div>
            <div class="div_bntBuynow3" style="width: 5px;">
            </div>--%>
        </div>
        <div style="width:250px"> 
    <asp:DataList ID="ddlVariantPrice" RepeatColumns="1" runat="server" CssClass="none"
                Width="100%" style="border-collapse:separate;"
                onitemcommand="ddlVariantPrice_ItemCommand" 
                onitemdatabound="ddlVariantPrice_ItemDataBound">
            <ItemTemplate>
            
                <div style="float:left;width: 50%;font-size:11px;"><asp:Label ID="lblPriceDisplay" CssClass="productPrice"  runat="server" /></div>
                <div style="float:left;width: 50%;">
                <asp:ImageButton ID="imgBuyNow" CommandName="AddToCart" CommandArgument='<%#Eval("ProductVariantId")%>' ImageUrl="~/images/btn_buyNow.PNG" runat="server"  /></div>
                <asp:Label ID="lblPrice" Visible="false"  runat="server" />
                <nopCommerce:ProductAttributes ID="ctrlProductAttributes" Visible="false" runat="server" ProductVariantId='<%#Eval("ProductVariantId") %>'>
                    </nopCommerce:ProductAttributes>
                
            </ItemTemplate>
        </asp:DataList>
    </div>
    </div>
</div>
